﻿using SqlSugar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace SqlSugar
{
    public class MethodCallExpressionResolve : BaseResolve
    {
        public MethodCallExpressionResolve(ExpressionParameter parameter) : base(parameter)
        {
            var express = base.Expression as MethodCallExpression;
            var isLeft = parameter.IsLeft;
            string methodName = express.Method.Name;
            var isValidNativeMethod = MethodMapping.ContainsKey(methodName) && express.Method.DeclaringType.Namespace == ("System");
            List<MethodCallExpressionArgs> appendArgs = null;
            if (MethodTimeMapping.ContainsKey(methodName))
            {
                appendArgs = new List<MethodCallExpressionArgs>();
                var dateType = MethodTimeMapping[methodName];
                string paramterName = this.Context.SqlParameterKeyWord + ExpressionConst.Const + this.Context.ParameterIndex;
                appendArgs.Add(new MethodCallExpressionArgs() { IsMember=false, MemberName= paramterName, MemberValue=dateType });
                this.Context.Parameters.Add(new SugarParameter(paramterName, dateType.ToString()));
                this.Context.ParameterIndex++;
                methodName = "DateAdd";
                isValidNativeMethod = true;
            }
            else if (methodName == "get_Item")
            {
                string paramterName = this.Context.SqlParameterKeyWord + ExpressionConst.Const + this.Context.ParameterIndex;
                this.Context.Parameters.Add(new SugarParameter(paramterName, ExpressionTool.DynamicInvoke(express)));
                this.Context.Result.Append(string.Format(" {0} ", paramterName));
                this.Context.ParameterIndex++;
                return;
            }
            else if (methodName == "NewGuid")
            {
                this.Context.Result.Append(this.Context.DbMehtods.GuidNew());
                return;
            }
            if (!isValidNativeMethod && express.Method.DeclaringType.Namespace.IsIn("System.Linq", "System.Collections.Generic") && methodName == "Contains")
            {
                methodName = "ContainsArray";
                isValidNativeMethod = true;
            }
            if (isValidNativeMethod)
            {
                NativeExtensionMethod(parameter, express, isLeft, MethodMapping[methodName],appendArgs);
            }
            else
            {
                SqlFuncMethod(parameter, express, isLeft);
            }
        }

        private void SqlFuncMethod(ExpressionParameter parameter, MethodCallExpression express, bool? isLeft)
        {
            CheckMethod(express);
            var method = express.Method;
            string name = method.Name;
            var args = express.Arguments.Cast<Expression>().ToList();
            MethodCallExpressionModel model = new MethodCallExpressionModel();
            model.Args = new List<MethodCallExpressionArgs>();
            switch (this.Context.ResolveType)
            {
                case ResolveExpressType.WhereSingle:
                case ResolveExpressType.WhereMultiple:
                    Check.Exception(name == "GetSelfAndAutoFill", "SqlFunc.GetSelfAndAutoFill can only be used in Select.");
                    Where(parameter, isLeft, name, args, model);
                    break;
                case ResolveExpressType.SelectSingle:
                case ResolveExpressType.SelectMultiple:
                case ResolveExpressType.Update:
                    Select(parameter, isLeft, name, args, model);
                    break;
                case ResolveExpressType.FieldSingle:
                case ResolveExpressType.FieldMultiple:
                default:
                    break;
            }
        }

        private void NativeExtensionMethod(ExpressionParameter parameter, MethodCallExpression express, bool? isLeft, string name, List<MethodCallExpressionArgs> appendArgs = null)
        {
            var method = express.Method;
            var args = express.Arguments.Cast<Expression>().ToList();
            MethodCallExpressionModel model = new MethodCallExpressionModel();
            model.Args = new List<MethodCallExpressionArgs>();
            switch (this.Context.ResolveType)
            {
                case ResolveExpressType.WhereSingle:
                case ResolveExpressType.WhereMultiple:
                    if (express.Object != null)
                        args.Insert(0, express.Object);
                    Where(parameter, isLeft, name, args, model, appendArgs);
                    break;
                case ResolveExpressType.SelectSingle:
                case ResolveExpressType.SelectMultiple:
                case ResolveExpressType.Update:
                    if (express.Object != null)
                        args.Insert(0, express.Object);
                    Select(parameter, isLeft, name, args, model, appendArgs);
                    break;
                case ResolveExpressType.FieldSingle:
                case ResolveExpressType.FieldMultiple:
                default:
                    break;
            }
        }

        private void Select(ExpressionParameter parameter, bool? isLeft, string name, IEnumerable<Expression> args, MethodCallExpressionModel model, List<MethodCallExpressionArgs> appendArgs = null)
        {
            if (name == "GetSelfAndAutoFill")
            {
                var memberValue = (args.First() as MemberExpression).Expression.ToString();
                model.Args.Add(new MethodCallExpressionArgs() { MemberValue= memberValue, IsMember=true, MemberName= memberValue });
            }
            else
            {
                foreach (var item in args)
                {
                    var isBinaryExpression = item is BinaryExpression || item is MethodCallExpression;
                    if (isBinaryExpression)
                    {
                        model.Args.Add(GetMethodCallArgs(parameter, item));
                    }
                    else
                    {
                        Default(parameter, model, item);
                    }
                }
                if (appendArgs != null)
                {
                    model.Args.AddRange(appendArgs);
                }
            }
            parameter.BaseParameter.CommonTempData = GetMdthodValue(name, model);
        }
        private void Where(ExpressionParameter parameter, bool? isLeft, string name, IEnumerable<Expression> args, MethodCallExpressionModel model, List<MethodCallExpressionArgs> appendArgs = null)
        {
            foreach (var item in args)
            {
                var isBinaryExpression = item is BinaryExpression || item is MethodCallExpression;
                if (isBinaryExpression)
                {
                    model.Args.Add(GetMethodCallArgs(parameter, item));
                }
                else
                {
                    Default(parameter, model, item);
                }
            }
            if (appendArgs != null)
            {
                model.Args.AddRange(appendArgs);
            }
            var methodValue = GetMdthodValue(name, model);
            base.AppendValue(parameter, isLeft, methodValue);
        }
        private void Default(ExpressionParameter parameter, MethodCallExpressionModel model, Expression item)
        {
            parameter.CommonTempData = CommonTempDataType.Result;
            base.Expression = item;
            base.Start();
            var methodCallExpressionArgs = new MethodCallExpressionArgs()
            {
                IsMember = parameter.ChildExpression is MemberExpression,
                MemberName = parameter.CommonTempData
            };
            if (methodCallExpressionArgs.IsMember && parameter.ChildExpression != null && parameter.ChildExpression.ToString() == "DateTime.Now")
            {
                methodCallExpressionArgs.IsMember = false;
            }
            var value = methodCallExpressionArgs.MemberName;
            if (methodCallExpressionArgs.IsMember)
            {
                var childExpression = parameter.ChildExpression as MemberExpression;
                if (childExpression.Expression != null && childExpression.Expression is ConstantExpression)
                {
                    methodCallExpressionArgs.IsMember = false;
                }
            }
            if (methodCallExpressionArgs.IsMember == false)
            {
                var parameterName = this.Context.SqlParameterKeyWord + ExpressionConst.MethodConst + this.Context.ParameterIndex;
                this.Context.ParameterIndex++;
                methodCallExpressionArgs.MemberName = parameterName;
                methodCallExpressionArgs.MemberValue = value;
                this.Context.Parameters.Add(new SugarParameter(parameterName, value));
            }
            model.Args.Add(methodCallExpressionArgs);
            parameter.ChildExpression = null;
        }

        private object GetMdthodValue(string name, MethodCallExpressionModel model)
        {
            switch (name)
            {
                case "IIF":
                    return this.Context.DbMehtods.IIF(model);
                case "HasNumber":
                    return this.Context.DbMehtods.HasNumber(model);
                case "HasValue":
                    return this.Context.DbMehtods.HasValue(model);
                case "IsNullOrEmpty":
                    return this.Context.DbMehtods.IsNullOrEmpty(model);
                case "ToLower":
                    return this.Context.DbMehtods.ToLower(model);
                case "ToUpper":
                    return this.Context.DbMehtods.ToUpper(model);
                case "Trim":
                    return this.Context.DbMehtods.Trim(model);
                case "Contains":
                    return this.Context.DbMehtods.Contains(model);
                case "ContainsArray":
                    var result = this.Context.DbMehtods.ContainsArray(model);
                    this.Context.Parameters.RemoveAll(it => it.ParameterName == model.Args[0].MemberName.ObjToString());
                    return result;
                case "Equals":
                    return this.Context.DbMehtods.Equals(model);
                case "DateIsSame":
                    if (model.Args.Count == 2)
                        return this.Context.DbMehtods.DateIsSameDay(model);
                    else
                        return this.Context.DbMehtods.DateIsSameByType(model);
                case "DateAdd":
                    if (model.Args.Count == 2)
                        return this.Context.DbMehtods.DateAddDay(model);
                    else
                        return this.Context.DbMehtods.DateAddByType(model);
                case "DateValue":
                    return this.Context.DbMehtods.DateValue(model);
                case "Between":
                    return this.Context.DbMehtods.Between(model);
                case "StartsWith":
                    return this.Context.DbMehtods.StartsWith(model);
                case "EndsWith":
                    return this.Context.DbMehtods.EndsWith(model);
                case "ToInt32":
                    return this.Context.DbMehtods.ToInt32(model);
                case "ToInt64":
                    return this.Context.DbMehtods.ToInt64(model);
                case "ToDate":
                    return this.Context.DbMehtods.ToDate(model);
                case "ToTime":
                    return this.Context.DbMehtods.ToTime(model);
                case "ToString":
                    return this.Context.DbMehtods.ToString(model);
                case "ToDecimal":
                    return this.Context.DbMehtods.ToDecimal(model);
                case "ToGuid":
                    return this.Context.DbMehtods.ToGuid(model);
                case "ToDouble":
                    return this.Context.DbMehtods.ToDouble(model);
                case "ToBool":
                    return this.Context.DbMehtods.ToBool(model);
                case "Substring":
                    return this.Context.DbMehtods.Substring(model);
                case "Replace":
                    return this.Context.DbMehtods.Replace(model);
                case "Length":
                    return this.Context.DbMehtods.Length(model);
                case "AggregateSum":
                    return this.Context.DbMehtods.AggregateSum(model);
                case "AggregateAvg":
                    return this.Context.DbMehtods.AggregateAvg(model);
                case "AggregateMin":
                    return this.Context.DbMehtods.AggregateMin(model);
                case "AggregateMax":
                    return this.Context.DbMehtods.AggregateMax(model);
                case "AggregateCount":
                    return this.Context.DbMehtods.AggregateCount(model);
                case "MappingColumn":
                    var mappingColumnResult = this.Context.DbMehtods.MappingColumn(model);
                    var isValid = model.Args[0].IsMember && model.Args[1].IsMember == false;
                    Check.Exception(!isValid, "SqlFunc.MappingColumn parameters error, The property name on the left, string value on the right");
                    this.Context.Parameters.RemoveAll(it => it.ParameterName == model.Args[1].MemberName.ObjToString());
                    return mappingColumnResult;
                case "GetSelfAndAutoFill":
                    this.Context.Parameters.RemoveAll(it => it.ParameterName == model.Args[0].MemberName.ObjToString());
                    return this.Context.DbMehtods.GetSelfAndAutoFill(model.Args[0].MemberValue.ObjToString(),this.Context.IsSingle);
                default:
                    break;
            }
            return null;
        }

        private static Dictionary<string, string> MethodMapping = new Dictionary<string, string>() {
            { "ToString","ToString"},
            { "ToInt32","ToInt32"},
            { "ToInt16","ToInt32"},
            { "ToInt64","ToInt64"},
            { "ToDecimal","ToDecimal"},
            { "ToDateTime","ToDate"},
            { "ToBoolean","ToBool"},
            { "ToDouble","ToDouble"},
            { "Length","Length"},
            { "Replace","Replace"},
            { "Contains","Contains"},
            { "ContainsArray","ContainsArray"},
            { "EndsWith","EndsWith"},
            { "StartsWith","StartsWith"},
            { "HasValue","HasValue"},
            { "Trim","Trim"},
            { "Equals","Equals"},
            { "ToLower","ToLower"},
            { "ToUpper","ToUpper"},
            { "Substring","Substring"},
            { "DateAdd","DateAdd"}
        };

        private static Dictionary<string, DateType> MethodTimeMapping = new Dictionary<string, DateType>() {
            { "AddYears",DateType.Year},
            { "AddMonths",DateType.Month},
            { "AddDays",DateType.Day},
            { "AddHours",DateType.Hour},
            { "AddMinutes",DateType.Minute},
            { "AddSeconds",DateType.Second},
            { "AddMilliseconds",DateType.Millisecond}
        };

        private void CheckMethod(MethodCallExpression expression)
        {
            Check.Exception(expression.Method.ReflectedType().FullName != ExpressionConst.SqlFuncFullName, string.Format(ExpressionErrorMessage.MethodError, expression.Method.Name));
        }
    }
}

using HelpYou.Net.CN.Log.Helper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HelpYou.Net.CN.App_Start
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class Log4NetFilterAttribute : ActionFilterAttribute, IExceptionFilter
    {
        #region 错误日志

        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                //记录日志
                Log4NetHelper.Log(Log4NetService.MsgLevel.ERROR,
                    filterContext.Controller.GetType().ToString(), filterContext.RequestContext.RouteData.Values["action"].ToString(),
                    filterContext.Exception.Message);
                //设置异常已经处理
                filterContext.ExceptionHandled = true;

                //错误页跳转
                filterContext.HttpContext.Response.Redirect("WebPartView/Error500");
            }
        }
        #endregion

    }
}
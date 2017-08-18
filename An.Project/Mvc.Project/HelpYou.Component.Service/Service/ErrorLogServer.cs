using HelpYou.Component.Interface.Interface;
using HelpYou.Component.Interface.Model;
using Framework.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper.Common;

namespace HelpYou.Component.Service.Service
{
    public class ErrorLogServer : BaseCommon<ErrorLogModel>, IErrorLog
    {
        public ReturnResultOption Insert(ErrorLogModel model)
        {
            try
            {
               var res= this.OpenSqlConnection().Execute(@"INSERT INTO [dbo].[Sys_ErrorLog]
           ([LogCode]
           ,[LogMessage]
           ,[CreateTime]
           ,[CreateUser]
           ,[UpdateTime]
           ,[UpdateUser]
           ,[State])
     VALUES(@LogCode,
            @LogMessage
            @CreateTime
            @CreateUser
            @UpdateTime
            @UpdateUser
            @State])", model);
                return res > 0 ? new ReturnResultOption(ReturnResultOptionType.Success, "新增成功") : new ReturnResultOption(ReturnResultOptionType.ParamError, "新增失败");
            }
            catch (Exception e)
            {
                throw new ArgumentException("新增失败,原因:" + e.Message);
            }
           
        }

        public List<ErrorLogModel> QueryList()
        {
            return this.OpenSqlConnection().Query<ErrorLogModel>(@"SELECT * FROM[dbo].[Sys_ErrorLog]").ToList();
        }
    }
}
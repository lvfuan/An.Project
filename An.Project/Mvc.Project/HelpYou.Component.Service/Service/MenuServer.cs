using HelpYou.Component.Interface.Interface;
using HelpYou.Component.Interface.Model;
using System;
using System.Collections.Generic;
using Framework.Dapper;
using Helper.Common;
using System.Linq;

namespace HelpYou.Component.Service.Service
{
    public class MenuServer : BaseCommon<MenuModel>, IMenu
    {
        public ReturnResultOption Delete(MenuModel model)
        {
            throw new NotImplementedException();
        }

        public ReturnResultOption Insert(MenuModel model)
        {
            try
            {
                if (!IsExists(model))
                {
                  var res=  this.OpenSqlConnection().Execute(@"INSERT INTO [dbo].[Sys_Menu]
           ([MenuCode]
           ,[MenuName]
           ,[MenuUrl]
           ,[MenuLevel]
           ,[MenuType]
           ,[CreateTime]
           ,[CreateUser]
           ,[UpdateTime]
           ,[UpdateUser]
           ,[state])
     VALUES(@MenuCode
           ,@MenuName
           ,@MenuUrl
           ,@MenuLevel
           ,@MenuType
           ,@CreateTime
           ,@CreateUser
           ,@UpdateTime
           ,@UpdateUser
           ,@state)", model);
                    return res > 0 ? new ReturnResultOption(ReturnResultOptionType.Success, "新增成功") : new ReturnResultOption(ReturnResultOptionType.Warning, "新增失败");
                }
                return new ReturnResultOption(ReturnResultOptionType.Warning, "菜单已经存在");
            }
            catch (Exception e)
            {
                throw new ArgumentException("新增菜单失败，原因：" + e.Message);
            }
        }

        public ReturnResultOption InsertBatch(List<MenuModel> list)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(MenuModel model)
        {
            return this.OpenSqlConnection().Query<MenuModel>("SELECT * FROM [dbo].[Sys_Menu] WHERE [MenuCode]=@MenuCode OR [MenuName]=@MenuName", model).Count() > 0;
        }

        public List<MenuModel> QuerList()
        {
            return this.OpenSqlConnection().Query<MenuModel>("SELECT * FROM [dbo].[Sys_Menu]").ToList();
        }

        public MenuModel Query(string table)
        {
            throw new NotImplementedException();
        }

        public ReturnResultOption Update(MenuModel model)
        {
            throw new NotImplementedException();
        }

    }
}

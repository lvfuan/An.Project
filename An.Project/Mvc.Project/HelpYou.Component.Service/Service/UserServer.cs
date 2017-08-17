using HelpYou.Component.Interface.Interface;
using HelpYou.Component.Interface.Model;
using System;
using System.Collections.Generic;
using Framework.Dapper;
using System.Linq;
using Helper.Common;

namespace HelpYou.Component.Service.Service
{
    public class UserServer : BaseCommon<UserModel>, IUser
    {   /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnResultOption Delete(UserModel model)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnResultOption Insert(UserModel model)
        {
            try
            {
                var t = IsExists(model);
                if (!IsExists(model))
                {
                    var res = this.OpenSqlConnection().Execute(@"INSERT INTO [dbo].[Sys_User]
           ([LoginId]
           ,[LoginPwd]
           ,[NickName]
           ,[RealName]
           ,[Age]
           ,[Gander]
           ,[Email]
           ,[Mobile]
           ,[Address]
           ,[CreateTime]
           ,[CreateUser]
           ,[UpdateTime]
           ,[UpdateUser]
           ,[State])
     VALUES(@LoginId
           ,@LoginPwd
           ,@NickName
           ,@RealName
           ,@Age
           ,@Gander
           ,@Email
           ,@Mobile
           ,@Address
           ,@CreateTime
           ,@CreateUser
           ,@UpdateTime
           ,@UpdateUser
           ,@State)", model);
                    return res > 0 ? new ReturnResultOption(ReturnResultOptionType.Success, "添加成功") : new ReturnResultOption(ReturnResultOptionType.Warning, "添加失败");
                }
                return new ReturnResultOption(ReturnResultOptionType.Warning, "用户已存在");
            }
            catch (Exception e)
            {
                throw new ArgumentException("添加用户失败，原因：" + e.Message);
            }

        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public ReturnResultOption InsertBatch(List<UserModel> list)
        {
            try
            {
                var newList = FilterUser(list);
                var res = OpenSqlConnection().Execute(@"INSERT INTO [dbo].[Sys_User]
           ([LoginId]
           ,[LoginPwd]
           ,[NickName]
           ,[RealName]
           ,[Age]
           ,[Gander]
           ,[Email]
           ,[Mobile]
           ,[Address]
           ,[CreateTime]
           ,[CreateUser]
           ,[UpdateTime]
           ,[UpdateUser]
           ,[State])
     VALUES(@LoginId
           ,@LoginPwd
           ,@NickName
           ,@RealName
           ,@Age
           ,@Gander
           ,@Email
           ,@Mobile
           ,@Address
           ,@CreateTime
           ,@CreateUser
           ,@UpdateTime
           ,@UpdateUser
           ,@State)", newList);
                return res > 0 ? new ReturnResultOption(ReturnResultOptionType.Success, "新增成功") : new ReturnResultOption(ReturnResultOptionType.Warning, "新增失败");
            }
            catch (Exception e)
            {
                throw new ArgumentException("新增失败，原因：" + e.Message);
            }
            throw new NotImplementedException();
        }
        /// <summary>
        /// 过滤已存在的用户
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<UserModel> FilterUser(List<UserModel> list)
        {
            var loginIds = list.Select(x => x.LoginId).ToArray();
            var users = OpenSqlConnection().Query<UserModel>("SELECT * FROM  [dbo].[Sys_User]").ToList();
            List<UserModel> newList = new List<UserModel>();
            if (users.Count() > 0)
            {
                foreach (var item in users)
                {
                    if (users.Where(x => !loginIds.Contains(x.LoginId)).Count() > 0)
                    {
                        newList.Add(item);
                    }
                }
            }
            else
            {
                newList = list;
            }
            return newList;
        }

        public List<UserModel> QuerList()
        {
            throw new NotImplementedException();
        }

        public UserModel Query(string loginId)
        {
            try
            {
                return OpenSqlConnection().QueryFirst<UserModel>($"SELECT * FROM [dbo].[Sys_User] WHERE [LoginId]=@loginId",new { loginId=loginId });
            }
            catch (Exception e)
            {

                throw new ArgumentException("查询失败，原因：" + e.Message);
            }
        }

        public ReturnResultOption Update(UserModel model)
        {
            throw new NotImplementedException();
        }
        public bool IsExists(string login)
        {
            return OpenSqlConnection().Query<UserModel>($"SELECT * FROM [dbo].[Sys_User] WHERE [LoginId]=@LoginId", new { LoginId = login }).Count() > 0;

        }
        public bool IsExists(UserModel model)
        {
            return OpenSqlConnection().Query<UserModel>("SELECT * FROM [dbo].[Sys_User] WHERE [LoginId]=@LoginId AND [LoginPwd]=@LoginPwd AND [State]=@State", model).Count() > 0;
        }
    }
}

using helpyou.net.cn.DB.Interface;
using helpyou.net.cn.DB.Models;
using System;
using System.Linq;
using Framework.Dapper;

namespace helpyou.net.cn.DB.Server
{
    public class CustomServer : HelpYouServe<CustomModel>, ICustom
    {
        public int Add(CustomModel model)
        {
            try
            {
                if (!IsExists(model))
                {
                    var sql = "INSERT INTO User_Custom(LoginId,Password,Email,Mobile,RealName,NickName,Gander,Age,CreateTime,CreateUser,UpdateTime,UpdateUser,State) " +
          "VALUES(@LoginId,@Password,@Email,@Mobile,@RealName,@NickName,@Gander,@Age,@CreateTime,@CreateUser,@UpdateTime,@UpdateUser,@State)";
                    return this.openSqlConnection.Execute(sql, model);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public bool IsExists(CustomModel model)
        {
            return openSqlConnection.Query<CustomModel>("SELECT * FROM User_Custom  WHERE [LoginId]=@LoginId AND [Password]=@Password", model).Count() > 0;
        }

        public CustomModel Query(string loginId)
        {
            return this.openSqlConnection.QueryFirst<CustomModel>($"SELECT * FROM User_Custom  WHERE [LoginId]=@Login", loginId);
        }
    }
}

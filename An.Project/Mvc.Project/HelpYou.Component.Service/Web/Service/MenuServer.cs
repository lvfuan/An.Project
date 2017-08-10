using Framework.Dapper;
using HelpYou.Component.Interface;
using HelpYou.Component.Interface.Model;
using HelpYou.Component.Interface.Web;
using System.Collections.Generic;
using System.Linq;
namespace HelpYou.Component.Service.Web
{
    public class MenuServer : HelpYouServe<MenuModel>, IMenu
    {
       
        /// <summary>
        /// 根据父级Url查询子集
        /// </summary>
        /// <param name="parentUrl"></param>
        /// <returns></returns>
        public List<MenuModel> Query(string parentUrl)
        {
            return openSqlConnection.Query<MenuModel>($"SELECT * FROM Sys_Menu WHERE parentUrl=@parentUrl",parentUrl).ToList();
        }

        public List<MenuModel> Query(int level)
        {
            return openSqlConnection.Query<MenuModel>($"SELECT * FROM Sys_Menu WHERE LEVEL=@Level",level).ToList();
        }

        /// <summary>
        /// 查询所有菜单
        /// </summary>
        /// <returns></returns>
        public List<MenuModel> QueryAll()
        {
                return openSqlConnection.Query<MenuModel>("SELECT * FROM Sys_Menu").ToList();
        }
    }
}

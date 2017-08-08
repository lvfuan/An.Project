using helpyou.net.cn.DB.Interface;
using helpyou.net.cn.DB.Models;
using System.Collections.Generic;
using System.Linq;
using Framework.Dapper;
namespace helpyou.net.cn.DB.Server
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

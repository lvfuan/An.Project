using HelpYou.Component.Interface.Model;
using System.Collections.Generic;

namespace HelpYou.Component.Interface.Web
{
    public interface IMenu : IHelpYou<MenuModel>
    {
        /// <summary>
        /// 查询所有菜单
        /// </summary>
        /// <returns></returns>
        List<MenuModel> QueryAll();
        /// <summary>
        /// 根据父级Url查询子集
        /// </summary>
        /// <param name="parentUrl"></param>
        /// <returns></returns>
        List<MenuModel> Query(string parentUrl);
        List<MenuModel> Query(int level);
    }
}

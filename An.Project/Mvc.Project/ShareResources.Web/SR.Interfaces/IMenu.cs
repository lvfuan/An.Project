using SR.Models.TModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Interfaces
{
    public interface IMenu:IBaseCommon<MenuModel>
    {
        /// <summary>
        /// 根据菜单等级查询
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        List<MenuModel> QueryList(int level);
        /// <summary>
        /// 根据菜单url字符串查询
        /// </summary>
        /// <param name="urlString"></param>
        /// <returns></returns>
        List<MenuModel> QueryList(string urlString);
    }
}

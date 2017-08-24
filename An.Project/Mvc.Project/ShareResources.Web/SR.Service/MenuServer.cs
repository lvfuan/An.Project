using SR.Interfaces;
using SR.Models.TModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Service
{
    public class MenuServer:BaseCommon<MenuModel>,IMenu
    {
        /// <summary>
        /// 根据菜单等级查询
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
         public List<MenuModel> QueryList(int level)
        {
           return this._dbContext.Menu.Where(x => x.Level == level).ToList();
        }
        /// <summary>
        /// 根据菜单url字符串查询
        /// </summary>
        /// <param name="urlString"></param>
        /// <returns></returns>
        public List<MenuModel> QueryList(string urlString)
        {
            return this._dbContext.Menu.Where(x => x.UrlString.Contains(urlString)).ToList();
        }
    }
}

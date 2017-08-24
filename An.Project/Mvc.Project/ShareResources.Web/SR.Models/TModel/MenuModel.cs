using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Models.TModel
{
    /// <summary>
    /// 导航菜单
    /// </summary>
    public class MenuModel : BaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 页面url
        /// </summary>
        public string PageUrl { get; set; }
        /// <summary>
        /// 路径字符串
        /// </summary>
        public string UrlString { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public int? Level { get; set; }
    }
}

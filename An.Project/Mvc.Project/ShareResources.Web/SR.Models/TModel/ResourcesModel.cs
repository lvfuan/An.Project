using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Models.TModel
{
    /// <summary>
    /// 资源分享
    /// </summary>
     public class ResourcesModel:BaseModel
    {
        /// <summary>
        ///标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 下载地址
        /// </summary>
        public string DownloadUrl { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 语言分类
        /// </summary>
        public int? LanguageTypeId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Models.TModel
{
    /// <summary>
    /// 精选博文
    /// </summary>
     public class BlogModel:BaseModel
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title  { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string Provenance { get; set; }
        /// <summary>
        /// 所属语言Id
        /// </summary>
        public int? LanguageTypeId { get; set; }
    }
}

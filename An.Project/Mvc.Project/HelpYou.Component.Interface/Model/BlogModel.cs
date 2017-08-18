using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpYou.Component.Interface.Model
{
    /// <summary>
    /// 菜单
    /// </summary>
    [Table("Web_Blog")]
    public class BlogModel
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Display(Name = "主键")]
        public int? Id { get; set; }
        /// <summary>
        /// 博客标题
        /// </summary>
        [Display(Name = "博客标题")]
        [StringLength(1000)]
        public string BlogTitie { get; set; }

        /// <summary>
        /// 博客内容
        /// </summary>
        [Display(Name = "博客内容")]
        public string BlogContent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [StringLength(50)]
        public string CreateUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        [StringLength(50)]
        public string UpdateUser { get; set; }

        /// <summary>
        /// 菜单编号
        /// </summary>
        [Display(Name = "菜单编号")]
        [StringLength(50)]
        public string MenuCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public bool? State { get; set; }
    }
}

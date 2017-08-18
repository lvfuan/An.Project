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
    [Table("Sys_Menu")]
     public class MenuModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Display(Name = "主键")]       
        public int? Id { get; set; }
        /// <summary>
        /// 菜单编码
        /// </summary>
        [Display(Name = "菜单编码")]
        [StringLength(50)]
        public string MenuCode { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        [Display(Name = "菜单名称")]
        [StringLength(50)]
        public string MenuName { get; set; }

        /// <summary>
        /// 路径字符串
        /// </summary>
        [Display(Name = "路径字符串")]
        [StringLength(500)]
        public string MenuUrl { get; set; }

        /// <summary>
        /// 分类等级
        /// </summary>
        [Display(Name = "分类等级")]
        public int? MenuLevel { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public string OrderBy { get; set; }

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
        /// 状态
        /// </summary>
        [Display(Name = "状态")]

        public bool? State { get; set; }

    }
}

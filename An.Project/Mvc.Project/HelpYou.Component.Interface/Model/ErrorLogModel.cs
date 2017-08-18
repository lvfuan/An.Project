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
    /// 错误日志
    /// </summary>
    [Table("Sys_ErrorLog")]
     public class ErrorLogModel
    {
        [Display(Name = "主键")]
        public int? Id { get; set; }
        /// <summary>
        /// 错误代码
        /// </summary>
        [Display(Name = "错误代码")]
        public string LogCode { get; set; }

        /// <summary>
        /// 错误信息 
        /// </summary>
        [Display(Name = "错误信息")]
        public string LogMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
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
        public string UpdateUser { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "")]
        public bool? State { get; set; }
    }
}

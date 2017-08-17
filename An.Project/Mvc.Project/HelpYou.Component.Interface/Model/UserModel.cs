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
    /// 用户
    /// </summary>
    [Table("Sys_User")]
     public class UserModel
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Display(Name = "主键Id")]
        public int? Id { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        [Display(Name = "登录名")]
        [StringLength(50)]
        public string LoginId { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        [StringLength(50)]
        public string LoginPwd { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [Display(Name = "昵称")]
        [StringLength(50)]
        public string NickName { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [Display(Name = "真实姓名")]
        [StringLength(50)]
        public string RealName { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Display(Name = "年龄")]
        public int? Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        public int? Gander { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Display(Name = "邮箱")]
        [StringLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        [Display(Name = "手机")]
        [StringLength(50)]
        public string Mobile { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        public string Address { get; set; }

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
        /// 
        /// </summary>
        [Display(Name = "")]
        public bool? State { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace HelpYou.Component.Interface.Model
{
    /// <summary>
    /// 用户
    /// </summary>
    [Table("User_Custom")]
    public class CustomModel:BaseModel
    {
        /// <summary>
        /// 登录id
        /// </summary>
        public string LoginId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Gander { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
    }
}

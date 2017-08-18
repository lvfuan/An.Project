using Helper.Common;
using HelpYou.Component.Interface;
using HelpYou.Component.Interface.Eum;
using HelpYou.Component.Interface.Interface;
using HelpYou.Component.Interface.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelpYou.Component.Controllers.Web
{
    public class UserManagerController:Controller
    {
        private readonly IHelpYou HelpYouServer;
        public UserManagerController(IHelpYou helpyou)
        {
            this.HelpYouServer = helpyou;
        }
        public ActionResult Index()
        {
            return View();
        }
        #region   SignIn
        public ActionResult SignIn(string login, string pwd, string yzm)
        {
            if (Request.IsAjaxRequest())
            {
                var yzmCookie = SessionHelper.Get("yzm");
                if (!yzmCookie.Equals(yzm))
                {
                    return Json(new ReturnResultOption(ReturnResultOptionType.Warning, "验证码不正确"));
                }
                else
                {
                    return Json(CheckSignIn(login,pwd));
                }
            }
            return View();
        }
        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        private ReturnResultOption CheckSignIn(string login, string pwd)
        {
            var model = this.HelpYouServer.User.Query(login);
            if (model != null)
            {
                if ((model.LoginId == login) && (model.LoginPwd == pwd))
                {
                    CookieHelper.SetCookie("user", JsonConvert.SerializeObject(model));
                    return new ReturnResultOption(ReturnResultOptionType.Success,"登陆成功");
                }
                else
                {
                    return new ReturnResultOption(ReturnResultOptionType.ParamError, "用户名或密码错误");
                }
            };
            return new ReturnResultOption(ReturnResultOptionType.Warning,"账号不存在");
        }
        #endregion


        #region Register
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="login">账号</param>
        /// <param name="pwd1">密码</param>
        /// <param name="pwd2">第二次输入的密码</param>
        /// <param name="registerType">注册类型</param>
        /// <returns></returns>
        public ActionResult Register(string login, string pwd1, string pwd2, EumRegisterType registerType)
        {
            if (Request.IsAjaxRequest())
            {
                if (!pwd1.Equals(pwd2)) return Json(new ReturnResultOption(ReturnResultOptionType.ParamError, "两次密码不一致"));
                UserModel model = new UserModel()
                {
                    LoginPwd = pwd1,
                    CreateTime = DateTime.Now,
                    State = true
                };
                switch (registerType)
                {
                    case EumRegisterType.Email:
                        model.Email = login;
                        this.HelpYouServer.User.Insert(model);
                        return Json(new ReturnResultOption(ReturnResultOptionType.Success, "注册成功"));
                    case EumRegisterType.Mobile:
                        model.Mobile = login;
                        this.HelpYouServer.User.Insert(model);
                        return Json(new ReturnResultOption(ReturnResultOptionType.Success, "注册成功"));
                    default:
                        return Json(new ReturnResultOption(ReturnResultOptionType.Warning, "注册失败"));
                }
            }
            return View();
        }
        #endregion
        public ActionResult Main()
        {
            return View();
        }
    }
}

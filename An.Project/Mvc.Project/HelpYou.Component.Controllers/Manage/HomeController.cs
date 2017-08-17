using Helper.Common;
using HelpYou.Component.Interface.Interface;
using System.Web.Mvc;
using HelpYou.Component.Interface.Model;
using System;
using Newtonsoft.Json;
using HelpYou.Component.Interface.Eum;

namespace HelpYou.Component.Controllers.Manage
{
    public class HomeController : Controller
    {
        private readonly IUser UserServer;
        private readonly IMenu MenuServer;
        public HomeController(IUser user, IMenu menu)
        {
            this.UserServer = user;
            this.MenuServer = menu;
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
                if (CheckSignIn(login, pwd))
                {
                    return Json(new ReturnResultOption(ReturnResultOptionType.Success, ""));
                }
                else
                {
                    return Json(new ReturnResultOption(ReturnResultOptionType.ParamError, "账号/密码不正确"));
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
        private bool CheckSignIn(string login, string pwd)
        {
            var model = this.UserServer.Query(login);
            if (model != null)
            {
                if ((model.LoginId == login) && (model.LoginPwd == pwd))
                {
                    CookieHelper.SetCookie("user", JsonConvert.SerializeObject(model));
                    return true;
                }
            };
            return false;
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
                        this.UserServer.Insert(model);
                        return Json(new ReturnResultOption(ReturnResultOptionType.Success, "注册成功"));
                    case EumRegisterType.Mobile:
                        model.Mobile = login;
                        this.UserServer.Insert(model);
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
            ViewBag.Menu = this.MenuServer.QuerList();
            return View();
        }
    }
}
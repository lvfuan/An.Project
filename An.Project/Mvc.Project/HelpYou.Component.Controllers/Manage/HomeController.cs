using Helper.Common;
using System.Web.Mvc;

namespace HelpYou.Component.Controllers.Manage
{
    public class HomeController : Controller
    {
        public HomeController() { }

        #region   SignIn
        public ActionResult SignIn(string login, string pwd, string yzm)
        {
            if (Request.IsAjaxRequest())
            {
                var b = SessionHelper.Get("yzm");
                if (!b.Equals(yzm))
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
            if (login == "admin" && pwd == "888888")
            {
                CookieHelper.SetCookie("user", "admin");
                return true;
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
        public ActionResult Register(string login,string pwd1,string pwd2,string registerType)
        {
            if (Request.IsAjaxRequest())
            {

            }
            return View();
        }
        private bool CkeckRegister()
        {
            return true;
        }
        #endregion
        public ActionResult Main()
        {
            return View();
        }
    }
}
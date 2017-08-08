using Helper.Common;
using helpyou.net.cn.DB.Interface;
using helpyou.net.cn.DB.Models;
using System.Web.Mvc;

namespace helpyou.net.cn.Controllers
{
    public class CustomController : Controller
    {
        private readonly ICustom _customServer;
        private readonly IMenu _menuServer;
        public CustomController(ICustom custom, IMenu menu)
        {
            this._customServer = custom;
            this._menuServer = menu;
        }
        /// <summary>
        /// µÇÂ¼
        /// </summary>
        /// <returns></returns>
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(string loginId, string pw1, string type)
        {
            return View();
        }
        /// <summary>
        /// ×¢²á
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(string loginId, string pw1, string pw2, string type)
        {
            if (string.IsNullOrWhiteSpace(loginId) || string.IsNullOrWhiteSpace(pw1) || string.IsNullOrWhiteSpace(pw2))
                return Json(new ReturnResultOption(ReturnResultOptionType.ParamError, "²ÎÊý´íÎó"));
            if (!pw1.Equals(pw2)) return Json(new ReturnResultOption(ReturnResultOptionType.Warning, "Á½´ÎÃÜÂëÊäÈë²»Ò»ÖÂ"));
            int res = 0;
            switch (type)
            {
                case "email":
                    res = this._customServer.Add(new CustomModel() { LoginId = loginId, Password =EncryptionHelper.MD5(pw1+"an.helpyou"), Email = loginId,State=true });
                    break;
                case "mobile":
                    res = this._customServer.Add(new CustomModel() { LoginId = loginId, Password = EncryptionHelper.MD5(pw1 + "an.helpyou"), Mobile = loginId,State=true });
                    break;
                default:
                    break;
            }
            return Json(res > 0 ? new ReturnResultOption(ReturnResultOptionType.Success, "×¢²á³É¹¦") : new ReturnResultOption(ReturnResultOptionType.Warning, "×¢²áÊ§°Ü"));
        }
        /// <summary>
        /// µÇÂ¼¼ì²é
        /// </summary>
        /// <returns></returns>
        public ActionResult CheckSignIn()
        {
            return View();
        }
        /// <summary>
        /// µÇ³ö
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            return View();
        }
    }
}
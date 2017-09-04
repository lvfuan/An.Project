using System;
using System.Web;
using System.Web.Mvc;

namespace UnitTest.MvcPager.Models.Token
{
    public static class CustomHtmlHelper
    {
        public static HtmlString GenerateVerficationToken(this HtmlHelper htmlhelper)
        {
            string formValue = Utility.Encrypt(HttpContext.Current.Session.SessionID + DateTime.Now.Ticks.ToString());
            HttpContext.Current.Session[PageTokenViewBase.SessionMyToken] = formValue;

            string fieldName = PageTokenViewBase.HiddenTokenName;
            TagBuilder builder = new TagBuilder("input");
            builder.Attributes["type"] = "hidden";
            builder.Attributes["name"] = fieldName;
            builder.Attributes["value"] = formValue;
            builder.Attributes["id"] = fieldName;
            return new HtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}
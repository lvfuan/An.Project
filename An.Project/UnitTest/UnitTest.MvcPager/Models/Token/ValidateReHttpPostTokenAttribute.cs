using System;
using System.Web.Mvc;

namespace UnitTest.MvcPager.Models.Token
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class ValidateReHttpPostTokenAttribute : FilterAttribute, IAuthorizationFilter
    {
        public IPageTokenView PageTokenView { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateReHttpPostTokenAttribute"/> class.
        /// </summary>
        public ValidateReHttpPostTokenAttribute()
        {
            //It would be better use DI inject it.
            PageTokenView = new SessionPageTokenView();
        }

        /// <summary>
        /// 当需要授权时调用.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (!PageTokenView.TokensMatch)
            {
                //重复提交时...
                throw new Exception("操作非法，不能进行重复提交!");
            }
           

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Helper.Common
{
     public class SessionHelper
    {
        /// 添加Session，调动有效期默认为23分钟  
        /// <summary>  
        /// 添加Session，调动有效期默认为23分钟  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <param name="strValue">Session值</param>  
        public static void Add(string strSessionName, string strValue)
        {
            HttpContext.Current.Session[strSessionName] = strValue;
            HttpContext.Current.Session.Timeout = 23;
        }
        /// 添加Session  
        /// <summary>  
        /// 添加Session  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <param name="strValue">Session值</param>  
        /// <param name="iExpires">调动有效期（分钟）</param>  
        public static void Add(string strSessionName, string strValue, int iExpires)
        {
            HttpContext.Current.Session[strSessionName] = strValue;
            HttpContext.Current.Session.Timeout = iExpires;
        }

        /// 读取某个Session对象值  
        /// <summary>  
        /// 读取某个Session对象值  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <returns>Session对象值</returns>  
        public static string Get(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] == null)
            {
                return null;
            }
            else
            {
                return HttpContext.Current.Session[strSessionName].ToString();
            }
        }

        /// 删除某个Session对象  
        /// <summary>  
        /// 删除某个Session对象  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        public static void Del(string strSessionName)
        {
            HttpContext.Current.Session[strSessionName] = null;
        }
    }
}

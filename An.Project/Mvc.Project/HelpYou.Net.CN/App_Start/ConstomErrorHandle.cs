using HelpYou.Component.Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpYou.Net.CN.App_Start
{
    /// <summary>
    /// 捕获记录/错误日志
    /// </summary>
    public class ConstomErrorHandleAttribute : HandleErrorAttribute
    {
        public static Queue<Exception> exceptionQueue = new Queue<Exception>(); //创建队列
        public override void OnException(ExceptionContext filterContext)
        {
            exceptionQueue.Enqueue(filterContext.Exception);  //将异常信息加入队列
            base.OnException(filterContext);         
        }
    }
}
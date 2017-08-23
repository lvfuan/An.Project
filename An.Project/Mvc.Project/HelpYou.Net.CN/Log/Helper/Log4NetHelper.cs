using System.Collections;

namespace HelpYou.Net.CN.Log.Helper
{
    public class Log4NetHelper
    {
        /// <summary>
        /// 记录系统日志
        /// </summary>
        /// <param name="msgLevel">日志级别</param>
        /// <param name="className">类名称</param>
        /// <param name="funName">方法名</param>
        /// <param name="msg">日志内容</param>
        public static void Log(Log4NetService.MsgLevel msgLevel, string className, string funName, string msg)
        {
            //LoginUser loginUser = LoginHelper.GetLoginUser();
            Hashtable parasHashtable = new Hashtable();
            //parasHashtable.Add("UserId", loginUser == null ? "" : loginUser.MemberId.ToString()); //form表单提交的数据
            //parasHashtable.Add("IP", IPHelper.Instance().AcceptIP()); //Url 参数
            parasHashtable.Add("FunName", funName);
            Log4NetService.Instance.Log(msgLevel, className, parasHashtable, msg);
        }
    }
}
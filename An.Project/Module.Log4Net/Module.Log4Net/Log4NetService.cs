using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Layout.Pattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module.Log4Net
{
    /// <summary>
    ///日志服务，支持自定义属性
    /// </summary>
    public sealed class Log4NetService
    {
        /// <summary>
        /// 日志单例
        /// </summary>
        public static Log4NetService Instance = new Log4NetService();

        /// <summary>
        /// 创建log4net日志记录器
        /// </summary>
        private static IMyLog MyLog = MyLogManager.GetLogger("iNotes");

        /// <summary>
        /// 日志级别枚举
        /// </summary>
        public enum MsgLevel
        {
            /// <summary>
            /// 1. 毁灭级别
            /// </summary>
            Fatal,

            /// <summary>
            /// 2. 错误级别
            /// </summary>
            Error,

            /// <summary>
            /// 3. 警告级别
            /// </summary>
            Warn,

            /// <summary>
            /// 4. 消息级别
            /// </summary>
            Info,

            /// <summary>
            ///  5. 调试级别
            /// </summary>
            Debug
        }

        /// <summary>
        /// 创建系统日志
        /// </summary>
        /// <param name="level">级别</param>
        /// <param name="type">类名，可自定义</param>
        /// <param name="parasHashtable">自定义参数,目前固定三个{UserId;IP;FunName}</param>
        /// <param name="message">内容</param>
        public void Log(MsgLevel level, System.String type, Hashtable parasHashtable, object message)
        {

            switch (level)
            {
                case MsgLevel.Debug:
                    MyLog.Debug(type, parasHashtable, message);
                    break;
                case MsgLevel.Info:
                    MyLog.Info(type, parasHashtable, message);
                    break;
                case MsgLevel.Warn:
                    MyLog.Warn(type, parasHashtable, message);
                    break;
                case MsgLevel.Error:
                    MyLog.Error(type, parasHashtable, message);
                    break;
                case MsgLevel.Fatal:
                    MyLog.Fatal(type, parasHashtable, message);
                    break;
            }
        }

    }

    #region 重写log4net接口

    /// <summary>
    /// 重写ILog接口
    /// </summary>
    public interface IMyLog : ILog
    {

        void Debug(string logType, Hashtable parasHashtable, object message);
        void Debug(string logType, Hashtable parasHashtable, object message, System.Exception t);

        void Info(string logType, Hashtable parasHashtable, object message);
        void Info(string logType, Hashtable parasHashtable, object message, System.Exception t);

        void Warn(string logType, Hashtable parasHashtable, object message);
        void Warn(string logType, Hashtable parasHashtable, object message, System.Exception t);

        void Error(string logType, Hashtable parasHashtable, object message);
        void Error(string logType, Hashtable parasHashtable, object message, System.Exception t);

        void Fatal(string logType, Hashtable parasHashtable, object message);
        void Fatal(string logType, Hashtable parasHashtable, object message, System.Exception t);
    }

    /// <summary>
    /// 日志方法类，重写新增日志方法
    /// </summary>
    public class MyLogImpl : LogImpl, IMyLog
    {
        /// <summary>
        /// The fully qualified name of this declaring type not the type of any subclass.
        /// </summary>
        public readonly static System.Type ThisDeclaringType = typeof(MyLogImpl);

        public MyLogImpl(ILogger logger) : base(logger) { }

        #region 重写添加日志内容的方法
        public void Debug(string logType, Hashtable parasHashtable, object message)
        {
            Debug(logType, parasHashtable, message, null);
        }
        public void Debug(string logType, Hashtable parasHashtable, object message, System.Exception t)
        {
            if (this.IsDebugEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Debug, message, t);
                loggingEvent.Properties["logType"] = logType;
                //添加自定义输出项
                foreach (DictionaryEntry de in parasHashtable)
                {
                    loggingEvent.Properties[de.Key.ToString()] = de.Value.ToString();
                }

                Logger.Log(loggingEvent);
            }
        }

        public void Info(string logType, Hashtable parasHashtable, object message)
        {
            Info(logType, parasHashtable, message, null);
        }
        public void Info(string logType, Hashtable parasHashtable, object message, System.Exception t)
        {
            if (this.IsInfoEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Info, message, t);
                loggingEvent.Properties["logType"] = logType;
                //添加自定义输出项
                foreach (DictionaryEntry de in parasHashtable)
                {
                    loggingEvent.Properties[de.Key.ToString()] = de.Value.ToString();
                }
                Logger.Log(loggingEvent);
            }
        }

        public void Warn(string logType, Hashtable parasHashtable, object message)
        {
            Warn(logType, parasHashtable, message, null);
        }
        public void Warn(string logType, Hashtable parasHashtable, object message, System.Exception t)
        {
            if (this.IsWarnEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Warn, message, t);
                loggingEvent.Properties["logType"] = logType;
                //添加自定义输出项
                foreach (DictionaryEntry de in parasHashtable)
                {
                    loggingEvent.Properties[de.Key.ToString()] = de.Value.ToString();
                }
                Logger.Log(loggingEvent);
            }
        }

        public void Error(string logType, Hashtable parasHashtable, object message)
        {
            Error(logType, parasHashtable, message, null);
        }
        public void Error(string logType, Hashtable parasHashtable, object message, System.Exception t)
        {
            if (this.IsErrorEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Error, message, t);
                loggingEvent.Properties["logType"] = logType;
                //添加自定义输出项
                foreach (DictionaryEntry de in parasHashtable)
                {
                    loggingEvent.Properties[de.Key.ToString()] = de.Value.ToString();
                }
                Logger.Log(loggingEvent);
            }
        }

        public void Fatal(string logType, Hashtable parasHashtable, object message)
        {
            Fatal(logType, parasHashtable, message, null);
        }
        public void Fatal(string logType, Hashtable parasHashtable, object message, System.Exception t)
        {
            if (this.IsFatalEnabled)
            {
                LoggingEvent loggingEvent = new LoggingEvent(ThisDeclaringType, Logger.Repository, Logger.Name, Level.Fatal, message, t);
                loggingEvent.Properties["logType"] = logType;
                //添加自定义输出项
                foreach (DictionaryEntry de in parasHashtable)
                {
                    loggingEvent.Properties[de.Key.ToString()] = de.Value.ToString();
                }
                Logger.Log(loggingEvent);
            }
        }
        #endregion 重写添加日志内容的方法

        /// <summary>
        /// 获取当前操作用户编号
        /// </summary>
        /// <returns></returns>
        private string GetUserId()
        {
            string account = string.Empty;
            try
            {
                account = "username"; //这里尽可替换，根据你的程序修改相关代码获取当前登录的用户账号
            }
            catch
            {
                account = "未登录";// string.Empty;
            }
            finally
            {

            }
            return account;
        }
        /// <summary>
        /// 获取当前操作用户IP
        /// </summary>
        /// <returns></returns>
        private string GetIp()
        {
            return System.Web.HttpContext.Current.Request.UserHostAddress;
        }
    }
    /// <summary>
    /// 日志管理类
    /// </summary>
    public class MyLogManager
    {
        #region 静态成员
        /// <summary>
        /// The wrapper map to use to hold the <see cref="EventIDLogImpl"/> objects
        /// </summary>
        private static readonly WrapperMap s_wrapperMap = new WrapperMap(new WrapperCreationHandler(WrapperCreationHandler));

        #endregion

        #region 构造函数
        /// <summary>
        /// Private constructor to prevent object creation
        /// </summary>
        private MyLogManager() { }
        #endregion

        #region 成员方法
        /// <summary>
        /// Returns the named logger if it exists
        /// </summary>
        /// <remarks>
        /// <para>If the named logger exists (in the default hierarchy) then it
        /// returns a reference to the logger, otherwise it returns
        /// <c>null</c>.</para>
        /// </remarks>
        /// <param name="name">The fully qualified logger name to look for</param>
        /// <returns>The logger found, or null</returns>
        public static IMyLog Exists(string name)
        {
            return Exists(Assembly.GetCallingAssembly(), name);
        }

        /// <summary>
        /// Returns the named logger if it exists
        /// </summary>
        /// <remarks>
        /// <para>If the named logger exists (in the specified domain) then it
        /// returns a reference to the logger, otherwise it returns
        /// <c>null</c>.</para>
        /// </remarks>
        /// <param name="domain">the domain to lookup in</param>
        /// <param name="name">The fully qualified logger name to look for</param>
        /// <returns>The logger found, or null</returns>
        public static IMyLog Exists(string domain, string name)
        {
            return WrapLogger(LoggerManager.Exists(domain, name));
        }

        /// <summary>
        /// Returns the named logger if it exists
        /// </summary>
        /// <remarks>
        /// <para>If the named logger exists (in the specified assembly's domain) then it
        /// returns a reference to the logger, otherwise it returns
        /// <c>null</c>.</para>
        /// </remarks>
        /// <param name="assembly">the assembly to use to lookup the domain</param>
        /// <param name="name">The fully qualified logger name to look for</param>
        /// <returns>The logger found, or null</returns>
        public static IMyLog Exists(Assembly assembly, string name)
        {
            return WrapLogger(LoggerManager.Exists(assembly, name));
        }

        /// <summary>
        /// Returns all the currently defined loggers in the default domain.
        /// </summary>
        /// <remarks>
        /// <para>The root logger is <b>not</b> included in the returned array.</para>
        /// </remarks>
        /// <returns>All the defined loggers</returns>
        public static IMyLog[] GetCurrentLoggers()
        {
            return GetCurrentLoggers(Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// Returns all the currently defined loggers in the specified domain.
        /// </summary>
        /// <param name="domain">the domain to lookup in</param>
        /// <remarks>
        /// The root logger is <b>not</b> included in the returned array.
        /// </remarks>
        /// <returns>All the defined loggers</returns>
        public static IMyLog[] GetCurrentLoggers(string domain)
        {
            return WrapLoggers(LoggerManager.GetCurrentLoggers(domain));
        }

        /// <summary>
        /// Returns all the currently defined loggers in the specified assembly's domain.
        /// </summary>
        /// <param name="assembly">the assembly to use to lookup the domain</param>
        /// <remarks>
        /// The root logger is <b>not</b> included in the returned array.
        /// </remarks>
        /// <returns>All the defined loggers</returns>
        public static IMyLog[] GetCurrentLoggers(Assembly assembly)
        {
            return WrapLoggers(LoggerManager.GetCurrentLoggers(assembly));
        }

        /// <summary>
        /// Retrieve or create a named logger.
        /// </summary>
        /// <remarks>
        /// <para>Retrieve a logger named as the <paramref name="name"/>
        /// parameter. If the named logger already exists, then the
        /// existing instance will be returned. Otherwise, a new instance is
        /// created.</para>
        ///
        /// <para>By default, loggers do not have a set level but inherit
        /// it from the hierarchy. This is one of the central features of
        /// log4net.</para>
        /// </remarks>
        /// <param name="name">The name of the logger to retrieve.</param>
        /// <returns>the logger with the name specified</returns>
        public static IMyLog GetLogger(string name)
        {
            return GetLogger(Assembly.GetCallingAssembly(), name);
        }

        /// <summary>
        /// Retrieve or create a named logger.
        /// </summary>
        /// <remarks>
        /// <para>Retrieve a logger named as the <paramref name="name"/>
        /// parameter. If the named logger already exists, then the
        /// existing instance will be returned. Otherwise, a new instance is
        /// created.</para>
        ///
        /// <para>By default, loggers do not have a set level but inherit
        /// it from the hierarchy. This is one of the central features of
        /// log4net.</para>
        /// </remarks>
        /// <param name="domain">the domain to lookup in</param>
        /// <param name="name">The name of the logger to retrieve.</param>
        /// <returns>the logger with the name specified</returns>
        public static IMyLog GetLogger(string domain, string name)
        {
            return WrapLogger(LoggerManager.GetLogger(domain, name));
        }

        /// <summary>
        /// Retrieve or create a named logger.
        /// </summary>
        /// <remarks>
        /// <para>Retrieve a logger named as the <paramref name="name"/>
        /// parameter. If the named logger already exists, then the
        /// existing instance will be returned. Otherwise, a new instance is
        /// created.</para>
        ///
        /// <para>By default, loggers do not have a set level but inherit
        /// it from the hierarchy. This is one of the central features of
        /// log4net.</para>
        /// </remarks>
        /// <param name="assembly">the assembly to use to lookup the domain</param>
        /// <param name="name">The name of the logger to retrieve.</param>
        /// <returns>the logger with the name specified</returns>
        public static IMyLog GetLogger(Assembly assembly, string name)
        {
            return WrapLogger(LoggerManager.GetLogger(assembly, name));
        }

        /// <summary>
        /// Shorthand for <see cref="LogManager.GetLogger(string)"/>.
        /// </summary>
        /// <remarks>
        /// Get the logger for the fully qualified name of the type specified.
        /// </remarks>
        /// <param name="type">The full name of <paramref name="type"/> will
        /// be used as the name of the logger to retrieve.</param>
        /// <returns>the logger with the name specified</returns>
        public static IMyLog GetLogger(System.Type type)
        {
            return GetLogger(Assembly.GetCallingAssembly(), type.FullName);
        }

        /// <summary>
        /// Shorthand for <see cref="LogManager.GetLogger(string)"/>.
        /// </summary>
        /// <remarks>
        /// Get the logger for the fully qualified name of the type specified.
        /// </remarks>
        /// <param name="domain">the domain to lookup in</param>
        /// <param name="type">The full name of <paramref name="type"/> will
        /// be used as the name of the logger to retrieve.</param>
        /// <returns>the logger with the name specified</returns>
        public static IMyLog GetLogger(string domain, System.Type type)
        {
            return WrapLogger(LoggerManager.GetLogger(domain, type));
        }

        /// <summary>
        /// Shorthand for <see cref="LogManager.GetLogger(string)"/>.
        /// </summary>
        /// <remarks>
        /// Get the logger for the fully qualified name of the type specified.
        /// </remarks>
        /// <param name="assembly">the assembly to use to lookup the domain</param>
        /// <param name="type">The full name of <paramref name="type"/> will
        /// be used as the name of the logger to retrieve.</param>
        /// <returns>the logger with the name specified</returns>
        public static IMyLog GetLogger(Assembly assembly, System.Type type)
        {
            return WrapLogger(LoggerManager.GetLogger(assembly, type));
        }

        #endregion

        #region 帮助类

        /// <summary>
        /// Lookup the wrapper object for the logger specified
        /// </summary>
        /// <param name="logger">the logger to get the wrapper for</param>
        /// <returns>the wrapper for the logger specified</returns>
        private static IMyLog WrapLogger(ILogger logger)
        {
            return (IMyLog)s_wrapperMap.GetWrapper(logger);
        }

        /// <summary>
        /// Lookup the wrapper objects for the loggers specified
        /// </summary>
        /// <param name="loggers">the loggers to get the wrappers for</param>
        /// <returns>Lookup the wrapper objects for the loggers specified</returns>
        private static IMyLog[] WrapLoggers(ILogger[] loggers)
        {
            IMyLog[] results = new IMyLog[loggers.Length];
            for (int i = 0; i < loggers.Length; i++)
            {
                results[i] = WrapLogger(loggers[i]);
            }
            return results;
        }

        /// <summary>
        /// Method to create the <see cref="ILoggerWrapper"/> objects used by
        /// this manager.
        /// </summary>
        /// <param name="logger">The logger to wrap</param>
        /// <returns>The wrapper for the logger specified</returns>
        private static ILoggerWrapper WrapperCreationHandler(ILogger logger)
        {
            return new MyLogImpl(logger);
        }
        #endregion
    }

    #endregion

    #region 自定义属性相关
    /// <summary>
    /// 把我们定义的属性转换为log4net所能识别的属性
    /// </summary>
    public class CustomLayout : PatternLayout
    {
        public CustomLayout()
        {
            this.AddConverter("property", typeof(ReflectionPatternConverter));
        }
    }
    /// <summary>
    /// 重写 PatternLayout
    /// </summary>
    public class ReflectionPatternConverter : PatternLayoutConverter
    {
        /// <summary>
        /// 重写 PatternLayout
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="loggingEvent"></param>
        protected override void Convert(System.IO.TextWriter writer, log4net.Core.LoggingEvent loggingEvent)
        {
            if (Option != null)
            {
                WriteObject(writer, loggingEvent.Repository, LookupProperty(Option, loggingEvent));
            }
            else
            {
                WriteDictionary(writer, loggingEvent.Repository, loggingEvent.GetProperties());
            }
        }

        /// <summary>
        /// 获取自定义属性的值
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private object LookupProperty(string property, log4net.Core.LoggingEvent loggingEvent)
        {
            object propertyValue = string.Empty;
            propertyValue = loggingEvent.Properties[property];
            return propertyValue;
        }
    }
    #endregion

    #region 数据库日志相关
    /// <summary>
    /// 将数据库链接字符串独立出来
    /// </summary>
    public class MyAdoNetAppender : AdoNetAppender
    {
        private static IMyLog _Log;
        private string _ConnectionStringName;
        public string ConnectionStringName
        {
            get { return _ConnectionStringName; }
            set { _ConnectionStringName = value; }
        }
        protected static IMyLog Log
        {
            get
            {
                if (_Log == null)
                    _Log = MyLogManager.GetLogger(typeof(MyAdoNetAppender));
                return _Log;
            }
        }
        public override void ActivateOptions() { PopulateConnectionString(); base.ActivateOptions(); }

        /// <summary>
        /// 获取或设置数据库连接字符串
        /// </summary>
        private void PopulateConnectionString()
        {
            // 如果配置文件中设置了ConnectionString，则返回
            if (!String.IsNullOrEmpty(ConnectionString)) return;
            // 如果配置文件中没有设置ConnectionStringName，则返回
            if (String.IsNullOrEmpty(ConnectionStringName)) return;
            // 获取对应Web.config中的连接字符串配置
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[ConnectionStringName];
            if (settings == null)
            {
                if (Log.IsErrorEnabled)
                    Log.ErrorFormat("Connection String Name not found in Configuration: {0}", ConnectionStringName);
                return;
            }
            //返回解密的连接字符串
            ConnectionString = settings.ConnectionString;// new DESEncrypt().Decrypt(settings.ConnectionString, null);
        }
    }
    #endregion


}

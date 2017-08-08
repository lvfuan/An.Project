using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Common
{
    public class ReturnResultOption
    {
        public int Type { get; set; }
        public string Message { get; set; }
        public object ObjData { get; set; }
        public ReturnResultOption(ReturnResultOptionType type)
        {
            this.Type = (int)type;
        }
        public ReturnResultOption(ReturnResultOptionType type,string message)
        {
            this.Type = (int)type;
            this.Message = message;
        }
        public ReturnResultOption(ReturnResultOptionType type, string message,object obj)
        {
            this.Type = (int)type;
            this.Message = message;
            this.ObjData = obj;
        }
    }
    public enum ReturnResultOptionType
    {
        /// <summary>
        /// 正常
        /// </summary>
        Success,
        /// <summary>
        /// 参数错误
        /// </summary>
        ParamError,
        /// <summary>
        /// 警告
        /// </summary>
        Warning
    }
}

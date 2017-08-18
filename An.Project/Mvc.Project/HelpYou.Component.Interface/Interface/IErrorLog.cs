using Helper.Common;
using HelpYou.Component.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpYou.Component.Interface.Interface
{
    public interface IErrorLog : IBaseCommon<ErrorLogModel>
    {
        ReturnResultOption Insert(ErrorLogModel model);
        List<ErrorLogModel> QueryList();
    }
}

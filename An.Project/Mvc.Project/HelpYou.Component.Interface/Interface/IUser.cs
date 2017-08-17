using HelpYou.Component.Interface.Model;
using System;
using System.Collections.Generic;
using Helper.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpYou.Component.Interface.Interface
{
     public interface IUser:IBaseCommon<UserModel>
    {
        ReturnResultOption Insert(UserModel model);
        ReturnResultOption InsertBatch(List<UserModel> list);
        ReturnResultOption Update(UserModel model);
        ReturnResultOption Delete(UserModel model);
        UserModel Query(string loginId);
        List<UserModel> QuerList();
        bool IsExists(string loginId);
        bool IsExists(UserModel model);
    }
}

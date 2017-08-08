using helpyou.net.cn.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpyou.net.cn.DB.Interface
{
    public interface ICustom:IHelpYou<CustomModel>
    {
        int Add(CustomModel model);
        CustomModel Query(string loginId);
        bool IsExists(CustomModel model);
    }
}

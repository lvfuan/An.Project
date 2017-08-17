using HelpYou.Component.Interface.Model;
using System;
using System.Collections.Generic;
using Helper.Common;

namespace HelpYou.Component.Interface.Interface
{
    public interface IMenu:IBaseCommon<MenuModel>
    {
        ReturnResultOption Insert(MenuModel model);
        ReturnResultOption InsertBatch(List<MenuModel> list);
        ReturnResultOption Update(MenuModel model);
        ReturnResultOption Delete(MenuModel model);
        MenuModel Query(string table);
        List<MenuModel> QuerList();
        bool IsExists(MenuModel model);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpYou.Component.Interface
{
    public interface IBaseCommon<T> where T:class,new()
    {
        //List<T> QueryList();
        //List<T> QueryList(string Sql);
    }
}

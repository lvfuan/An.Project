using HelpYou.Component.Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpYou.Component.Interface
{
     public interface IHelpYou 
    {
        IBlog Blog { get; set; }
        IMenu Menu { get; set; }
        IUser User { get; set; }
        IErrorLog ErrorLog { get; set; }
    }
}

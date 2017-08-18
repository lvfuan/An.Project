using HelpYou.Component.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelpYou.Component.Interface.Interface;
using HelpYou.Component.Service.Service;

namespace HelpYou.Component.Service
{
    public class HelpYouServer : IHelpYou
    {
        public IBlog Blog { get; set; } = new BlogServer();
        public IMenu Menu { get; set; } = new MenuServer();
        public IUser User { get; set; } = new UserServer();
        public IErrorLog ErrorLog { get; set; } = new ErrorLogServer();
    }
}

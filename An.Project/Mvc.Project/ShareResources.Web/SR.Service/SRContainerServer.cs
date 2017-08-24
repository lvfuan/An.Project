using SR.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Service
{
    public class SRContainerServer:ISRContainer
    {
        public IMenu Menu { get; set; } = new MenuServer();
        public ILanguageType LanguageType { get; set; } = new LanguageTypeServer();
    }
}

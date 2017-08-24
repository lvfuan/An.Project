using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Interfaces
{
     public interface ISRContainer
    {
        IMenu Menu { get; set; }
        ILanguageType LanguageType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SR.Models.SRContext
{
    public class ContextFactory
    {
        public static SRDbContext _context
        {
            get
            {
                string threeName = typeof(SRDbContext).FullName;
                object obj = CallContext.GetData(threeName);
                if (obj == null)
                {
                    obj = new SRDbContext();
                    CallContext.SetData(threeName,obj);
                }
                return obj as SRDbContext;
            }
        }
    }
}

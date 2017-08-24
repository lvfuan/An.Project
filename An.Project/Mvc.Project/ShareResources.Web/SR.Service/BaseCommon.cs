using SR.Interfaces;
using SR.Models.SRContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.Service
{
    public class BaseCommon<T>:IBaseCommon<T> where T:class,new()
    {
        protected  SRDbContext _dbContext = ContextFactory._context;
        ~BaseCommon()
        {
            _dbContext.Dispose();
        }
    }
}

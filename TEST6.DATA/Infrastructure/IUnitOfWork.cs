using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST6.DATA.Infrastructure
{
    public interface IUnitOfWork
    {
        void commit();
    }
}

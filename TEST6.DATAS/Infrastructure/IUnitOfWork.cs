using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST6.DATAS.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}

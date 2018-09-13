using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST6.MODELS.Model;

namespace TEST6.DATAS.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        northwind_databaseEntities Init();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST6.MODEL.Model;

namespace TEST6.DATA.Infrastructure
{
    public interface IDbFactory
    {
        northwind_databaseEntities Init();
    }
}

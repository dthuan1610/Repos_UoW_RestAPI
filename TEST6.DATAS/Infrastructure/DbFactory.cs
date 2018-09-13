using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST6.MODELS.Model;
using System.Data.Entity;

namespace TEST6.DATAS.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private northwind_databaseEntities dbContext;

        public northwind_databaseEntities Init()
        {
            return dbContext ?? (dbContext = new northwind_databaseEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST6.DATAS.Infrastructure;
using TEST6.MODELS.Model;
using TEST6.DATAS.Interface;

namespace TEST6.DATAS.Repository
{

    public class CustomerRepository : RepositoryBase<customer>, IcustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

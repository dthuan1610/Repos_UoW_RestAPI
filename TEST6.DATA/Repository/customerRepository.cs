using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST6.DATA.Infrastructure;
using TEST6.MODEL.Model;

namespace TEST6.DATA.Repository
{
    public interface IcustomerRepository : IRepository<customer>
    {

    }

    public class CustomerRepository : RepositoryBase<customer>, IcustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}

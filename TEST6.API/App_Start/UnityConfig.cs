using System.Web.Http;
using Unity;
using Unity.WebApi;
using TEST6.API.Controllers;
using TEST6.DATAS.Infrastructure;
using TEST6.DATAS.Repository;
using TEST6.SERVICE;
using TEST6.MODELS.Model;
using TEST6.DATAS.Interface;
using TEST6.API.Models;
using Unity.Lifetime;
using System.Data.Entity;

namespace TEST6.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            //UnitOfWork resolver
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            //DbFactory resolver
            container.RegisterType<IDbFactory, DbFactory>();
            //Customer resolver
            container.RegisterType<IRepository<customer>, RepositoryBase<customer>>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IcustomerRepository, CustomerRepository>();
            container.RegisterSingleton<DbFactory>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
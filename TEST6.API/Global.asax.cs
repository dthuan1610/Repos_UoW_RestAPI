using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using AutoMapper;
using TEST6.API.AutoMapperProfiles;

namespace TEST6.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            UnityConfig.RegisterComponents();
        }
    }
}

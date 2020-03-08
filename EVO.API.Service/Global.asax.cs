using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using EVO.API.Service.Common;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace EVO.API.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var dependencyContainer = DependencyContainer.Instance.Container;
            DependencyContainer.Instance.Register();
            dependencyContainer.EnableHttpRequestMessageTracking(GlobalConfiguration.Configuration);
            dependencyContainer.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            dependencyContainer.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(dependencyContainer);
        }
    }
}

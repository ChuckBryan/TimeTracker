using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Heroic.Web.IoC;
using StructureMap;

namespace TimeTracker.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {

        public IContainer Container
        {
            get
            {
                return StructureMapContainerPerRequestModule.Container;
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MediatorConfig.Configure(new HttpContextWrapper(this.Context).GetContainer());
            EFConfig.Initialize();


            using (IContainer container = Container.GetNestedContainer())
            {
                // Execute Tasks...
            }

        }
    }
}

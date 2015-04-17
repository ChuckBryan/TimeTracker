using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Heroic.Web.IoC;
using StructureMap;
using TimeTracker.Web.Infrastructure.Tasks;
/*
 * Using Heroric IoC. This creates the Container per Request patterns. For each
 * Begin Requested a nested container is created and released at the end request.
 * This takes place in the Module which is registered with Heroic IoC.

 */
namespace TimeTracker.Web
{
    public class MvcApplication : HttpApplication
    {
        public IContainer Container
        {
            get { return StructureMapContainerPerRequestModule.Container; }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MediatorConfig.Configure(new HttpContextWrapper(Context).GetContainer());
            EFConfig.Initialize();


            using (IContainer container = Container.GetNestedContainer())
            {
                foreach (IRunAtInit task in container.GetAllInstances<IRunAtInit>())
                {
                    task.Execute();
                }

                foreach (IRunAtStartup task in container.GetAllInstances<IRunAtStartup>())
                {
                    task.Execute();
                }
            }
        }

        public void Application_BeginRequest()
        {
            foreach (IRunOnEachRequest task in Container.GetAllInstances<IRunOnEachRequest>())
            {
                task.Execute();
            }
        }

        public void Application_Error()
        {
            foreach (IRunOnError task in Container.GetAllInstances<IRunOnError>())
            {
                task.Execute();
            }
        }

        public void Application_EndRequest()
        {
            foreach (IRunAfterEachRequest task in
                Container.GetAllInstances<IRunAfterEachRequest>())
            {
                try
                {
                    task.Execute();
                }
                catch (Exception e)
                {
                    // Just an empty catch
                    // Heroic IoC will dispose of the Container...
                    Console.WriteLine(e);
                }
            }
        }
    }
}
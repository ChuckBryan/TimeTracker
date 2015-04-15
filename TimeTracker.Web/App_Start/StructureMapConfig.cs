using Heroic.Web.IoC;
using System.Web.Http;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Graph;
using TimeTracker.Web.Infrastructure;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TimeTracker.Web.StructureMapConfig), "Configure")]
namespace TimeTracker.Web
{
	public static class StructureMapConfig
	{
		public static void Configure()
		{
			ObjectFactory.Configure(cfg =>
			{
				cfg.Scan(scan =>
				{
					scan.TheCallingAssembly();
					scan.WithDefaultConventions();
				});

				cfg.AddRegistry(new ControllerRegistry());
				cfg.AddRegistry(new MvcRegistry());
				cfg.AddRegistry(new ActionFilterRegistry(namespacePrefix: "TimeTracker.Web"));

				//TODO: Add other registries and configure your container!
                cfg.AddRegistry<MediatorRegistry>();
			});

			var resolver = new StructureMapDependencyResolver();
			DependencyResolver.SetResolver(resolver);
			GlobalConfiguration.Configuration.DependencyResolver = resolver;
		}
	}
}
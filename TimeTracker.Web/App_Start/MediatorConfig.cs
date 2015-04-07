using StructureMap;
using TimeTracker.Web.Infrastructure;

namespace TimeTracker.Web
{
    public static class MediatorConfig
    {
        public static void Configure(IContainer container)
        {
            container.Configure(cfg =>
            {
                cfg.AddRegistry(new MediatorRegistry());
            });
        }
    }
}
using System.Configuration;
using System.Data.Entity;
using TimeTracker.Web.Data;

namespace TimeTracker.Web
{
    public static class EFConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<AppDbContext,
                    Migrations.Configuration>());
        }
    }
}
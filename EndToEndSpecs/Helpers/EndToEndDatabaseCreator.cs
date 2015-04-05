using System;
using System.Data.Entity;
using System.IO;
using SpecsFor.Configuration;
using SpecsFor.Mvc;
using SpecsFor;
using TimeTracker.Web.Data;

namespace EndToEndSpecs.Helpers
{
    public class EndToEndDatabaseCreator : Behavior<SpecsFor<MvcWebApp>>
    {
        private static bool _isInitialized;

        public override void SpecInit(SpecsFor<MvcWebApp> instance)
        {

            if (_isInitialized) return;

            AppDomain.CurrentDomain.SetData("DataDirectory",
                Directory.GetCurrentDirectory());

            var strategy = new DropCreateDatabaseAlways<AppDbContext>();
            Database.SetInitializer(strategy);

            using (var context = new AppDbContext())
            {
                context.Database.Initialize(force:true);
            }


            _isInitialized = true;
        }
    }
}
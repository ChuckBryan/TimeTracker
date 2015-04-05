using IntegrationSpecs.TestHelpers;
using NUnit.Framework;
using SpecsFor;
using SpecsFor.Mvc;
using SpecsFor.Mvc.Helpers;
using TimeTracker.Web.Controllers;
using TimeTracker.Web.Data;

namespace EndToEndSpecs
{
    public class FirstSpec
    {
        public class when_navigating_to_home : SpecsFor<MvcWebApp>, INeedDatabase
        {
            public AppDbContext Database { get; set; }

            protected override void When()
            {
                SUT.NavigateTo<HomeController>(c=>c.Index());
            }

            [Test]
            public void then_should_be_redirected_to_login()
            {
                //  "%2F" = encoded "/"
                SUT.Route.ShouldMapTo<HomeController>(c => c.Index());
            }
            
        }
    }
}
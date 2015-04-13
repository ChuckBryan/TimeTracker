using System;
using System.Web.Mvc;
using IntegrationSpecs.TestHelpers;
using NUnit.Framework;
using Should;
using SpecsFor;
using SpecsFor.Helpers.Web.Mvc;
using TimeTracker.Web.Controllers;
using TimeTracker.Web.Data;
using TimeTracker.Web.Domain;
using TimeTracker.Web.Models.Home;

namespace IntegrationSpecs.Web.Controllers
{
    public class HomeControllerSpecs
    {
        public class when_getting_a_list_of_entries 
            : SpecsFor<HomeController>, INeedDatabase
        {
            private ActionResult _result;

            public AppDbContext Database { get; set; }

            protected override void Given()
            {
                for (var i = 0; i < 5; i++)
                {
                    Database.EntryLogs.Add(new EntryLog()
                    {
                        Description = "Description " + i,
                        EntryDate = DateTime.Now.AddDays(i + 1),
                        Duration = i + 1,
                        Project = "Project " + i

                    });
                }

                Database.SaveChanges();
            }

            protected override void When()
            {
                _result = SUT.Index();
            }

            [Test]
            public void then_it_should_return_entrylogs()
            {
                _result.ShouldRenderDefaultView()
                    .WithModelType<EntryLogViewModel[]>()
                    .Length.ShouldEqual(5);
            }
        }
    }
}
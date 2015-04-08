﻿using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using NUnit.Framework;
using Should;
using SpecsFor;
using TimeTracker.Web.Controllers;
using TimeTracker.Web.Infrastructure;

namespace TimeTrackerSpecs.Web.Controllers
{
    public class HomeControllerSpecs 
    {
        public class when_viewing_index_action : SpecsFor<HomeController>
        {
            private ActionResult _result;

            protected override void Given()
            {
                GetMockFor<ICurrentUser>().Setup(x => x.UserName).Returns("John Doe");
            }

            protected override void When()
            {
                _result = SUT.Index();
            }

            [Test]
            public void then_it_returns_a_view_result()
            {
                _result.ShouldBeType<ViewResult>();
            }

            [Test]
            public void then_it_says_hello_to_the_viewer()
            {
                string message = ((ViewResult) _result).ViewBag.Message;

                message.ShouldEqual("Hello, John Doe!");
            }

        }

        public class when_setting_the_users_name : SpecsFor<HomeController>
        {
            private ActionResult _result;

            protected override void When()
            {
                _result = SUT.SetName("Jane Doe");
            }

            [Test]
            public void then_it_sets_the_name_of_the_user()
            {
                GetMockFor<ICurrentUser>()
                    .Verify(x=>x.SetName("Jane Doe"));
            }

            [Test]
            public void then_it_redirects_back_home()
            {
                var routeResult = (RedirectToRouteResult) _result;
                routeResult.RouteValues["action"].ShouldEqual("Index");
            }
        }
    }
}
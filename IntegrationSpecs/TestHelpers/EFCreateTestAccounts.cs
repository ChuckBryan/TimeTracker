using System.Linq;
using System.Net.Mime;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SpecsFor.Configuration;
using TimeTracker.Web.Domain;

namespace IntegrationSpecs.TestHelpers
{
    public class EFCreateTestAccounts : Behavior<INeedDatabase>
    {
        public override void SpecInit(INeedDatabase instance)
        {
            var userStore = new UserStore<ApplicationUser>(instance.Database);
            var userManager = new UserManager<ApplicationUser>(userStore);
            var userToInsert = new ApplicationUser { UserName = CredentialStrings.Consultant.Email};
            userManager.Create(userToInsert, CredentialStrings.Consultant.Password);
        }
    }
}
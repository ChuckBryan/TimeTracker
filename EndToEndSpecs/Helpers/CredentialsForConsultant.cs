using IntegrationSpecs;
using SpecsFor.Mvc;
using SpecsFor.Mvc.Authentication;
using TimeTracker.Web.Controllers;
using TimeTracker.Web.Models.Account;

namespace EndToEndSpecs.Helpers
{
    public class CredentialsForConsultant : IHandleAuthentication
    {
        public void Authenticate(MvcWebApp mvcWebApp)
        {
            mvcWebApp.NavigateTo<HomeController>(c => c.Index());

            if (mvcWebApp.UrlMapsTo<HomeController>(c => c.Index())) return;

            mvcWebApp.FindFormFor<LoginViewModel>()
                .Field(x => x.Email).SetValueTo(CredentialStrings.Consultant.Email)
                .Field(x => x.Password).SetValueTo(CredentialStrings.Consultant.Password)
                .Submit();
        }
    }
}
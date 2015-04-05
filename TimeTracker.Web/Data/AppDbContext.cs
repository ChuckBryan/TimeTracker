using Microsoft.AspNet.Identity.EntityFramework;
using TimeTracker.Web.Domain;
using TimeTracker.Web.Models;

namespace TimeTracker.Web.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        // Static Factory Method used by the Owin Auth Middleware
        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}
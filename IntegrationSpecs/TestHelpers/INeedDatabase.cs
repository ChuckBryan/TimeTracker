using SpecsFor;
using TimeTracker.Web.Data;
using TimeTracker.Web.Models;

namespace IntegrationSpecs.TestHelpers
{
    public interface INeedDatabase : ISpecs
    {
        AppDbContext Database { get; set; }
    }
}
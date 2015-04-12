using SpecsFor;
using TimeTracker.Web.Data;

namespace IntegrationSpecs.TestHelpers
{
    public interface INeedDatabase : ISpecs
    {
        AppDbContext Database { get; set; }
    }
}
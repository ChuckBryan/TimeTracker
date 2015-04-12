using IntegrationSpecs.TestHelpers;
using NUnit.Framework;
using SpecsFor.Configuration;

namespace IntegrationSpecs
{
    [SetUpFixture]
    public class SpecsForConfig : SpecsForConfiguration
    {
        public SpecsForConfig()
        {
            WhenTesting<INeedDatabase>().EnrichWith<EFDatabaseCreator>();

        }
    }
}
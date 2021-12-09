using DriveTestFinderRepository.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DriveTestFinderLib.Model.DTO
{
    public class TestTypeData
    {
        public int TestTypeId { get; set; }
        public string Description { get; set; }
        public List<LicenseData> LicensesApplicableForTest { get; set; }
        public List<LocationData> LocationsAvailableForTest { get; set; }

        public static TestTypeData FromTestType(TestType testType)
        {
            return new TestTypeData 
            { 
                TestTypeId = testType.TestTypeId, 
                Description = testType.Description,
                LicensesApplicableForTest = testType.LicenseTestTypes.Select(x => new LicenseData { LicenseId = x.LicenseId, Description = x.License.Description }).ToList(),
                LocationsAvailableForTest = testType.LocationTestTypes.Select(x => new LocationData { LocationId = x.LocationId, Description = x.Location.Description }).ToList()
            };
        }
    }
}

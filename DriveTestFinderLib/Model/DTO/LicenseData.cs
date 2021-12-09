using DriveTestFinderRepository.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DriveTestFinderLib.Model.DTO
{
    public class LicenseData
    {
        public int LicenseId { get; set; }
        public string Description { get; set; }
        public List<TestTypeData> TestTypes { get; set; }

        public static LicenseData FromLicense(License license)
        {
            return new LicenseData 
            { 
                LicenseId = license.LicenseId, 
                Description = license.Description,
                TestTypes = license.LicenseTestTypes.Select(x => new TestTypeData 
                { 
                    TestTypeId = x.TestTypeId, 
                    Description = x.TestType.Description,
                    LocationsAvailableForTest = x.TestType.LocationTestTypes.Select
                    (
                        x => new LocationData
                        {
                            LocationId = x.LocationId,
                            Description = x.Location.Description
                        }
                    ).ToList(),
                }).ToList()
            };
        }
    }
}

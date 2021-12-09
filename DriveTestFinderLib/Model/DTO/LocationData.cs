using DriveTestFinderRepository.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DriveTestFinderLib.Model.DTO
{
    public class LocationData
    {
        public int LocationId { get; set; }
        public string Description { get; set; }
        public List<TestTypeData> TestTypesOnLocation { get; set; }

        public static LocationData FromLocation(Location location)
        {
            return new LocationData
            {
                LocationId = location.LocationId,
                Description = location.Description,
                TestTypesOnLocation = location.LocationTestTypes.Select(x => new TestTypeData { TestTypeId = x.TestTypeId, Description = x.TestType.Description }).ToList()
            };
        }
    }
}

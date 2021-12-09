using DriveTestFinderLib.Model.DTO;
using System.Collections.Generic;

namespace DriveTestFinderLib.Model.Response
{
    public class BasicDataResponse
    {
        public IEnumerable<LanguageData> Languages { get; set; }
        public IEnumerable<LicenseData> Licenses { get; set; }
        public IEnumerable<LocationData> Locations { get; set; }
        public IEnumerable<TestTypeData> TestTypes { get; set; }
        public IEnumerable<VehicleTypeData> VehicleTypes { get; set; }

    }
}

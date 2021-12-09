using DriveTestFinderLib.Model.DTO;
using DriveTestFinderLib.Model.Response;
using DriveTestFinderRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTestFinderLib.Managers
{
    public class DataSyncMgr
    {
        private readonly LanguageRepository _languageRepository;
        private readonly LicenseRepository _licenseRepository;
        private readonly LocationRepository _locationRepository;
        private readonly TestTypeRepository _testTypeRepository;
        private readonly VehicleTypeRepository _vehicleTypeRepository;

        public DataSyncMgr(string connectionString)
        {
            _languageRepository = new LanguageRepository(connectionString);
            _licenseRepository = new LicenseRepository(connectionString);
            _locationRepository = new LocationRepository(connectionString);
            _testTypeRepository = new TestTypeRepository(connectionString);
            _vehicleTypeRepository = new VehicleTypeRepository(connectionString);
        }

        public async Task<BasicDataResponse> GetBasicData()
        {
            var bd = new BasicDataResponse();

            var languages = await _languageRepository.GetAll();
            bd.Languages = languages.Select(l => LanguageData.FromLanguge(l));

            var licenses = await _licenseRepository.GetAll();
            bd.Licenses = licenses.Select(l => LicenseData.FromLicense(l));

            var locations = await _locationRepository.GetAll();
            bd.Locations = locations.Select(l => LocationData.FromLocation(l));

            var testTypes = await _testTypeRepository.GetAll();
            bd.TestTypes = testTypes.Select(t => TestTypeData.FromTestType(t));

            var vehicleTypes = await _vehicleTypeRepository.GetAll();
            bd.VehicleTypes = vehicleTypes.Select(v => VehicleTypeData.FromVehicleType(v));
            
            return bd;
        }
    }
}

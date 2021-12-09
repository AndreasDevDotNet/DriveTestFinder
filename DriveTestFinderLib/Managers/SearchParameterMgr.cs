using DriveTestFinderLib.Model.DTO;
using DriveTestFinderRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTestFinderLib.Managers
{
    public class SearchParameterMgr
    {
        private readonly LanguageRepository _languageRepository;
        private readonly LicenseRepository _licenseRepository;
        private readonly LocationRepository _locationRepository;
        private readonly TestTypeRepository _testTypeRepository;
        private readonly VehicleTypeRepository _vehicleTypeRepository;

        public SearchParameterMgr(string connectionString)
        {
            _languageRepository = new LanguageRepository(connectionString);
            _licenseRepository = new LicenseRepository(connectionString);
            _locationRepository = new LocationRepository(connectionString);
            _testTypeRepository = new TestTypeRepository(connectionString);
            _vehicleTypeRepository = new VehicleTypeRepository(connectionString);
        }

        public async Task<List<LanguageData>> GetLanguages()
        {
            var languages = await _languageRepository.GetAll();
            return languages.Select(l => LanguageData.FromLanguge(l)).ToList();
        }

        public async Task<List<LicenseData>> GetLicenses()
        {
            var licenses = await _licenseRepository.GetAll();
            return licenses.Select(l => LicenseData.FromLicense(l)).ToList();
        }

    }
}

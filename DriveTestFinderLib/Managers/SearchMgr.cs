using DriveTestFinderLib.Model.DTO;
using DriveTestFinderLib.Model.JsonMappingClasses;
using DriveTestFinderLib.Model.Request;
using DriveTestFinderRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTestFinderLib.Managers
{
    public class SearchMgr
    {
        private string _trafikVerketBaseUri;
        private readonly TrafikverketMgr _trafikverketMgr;
        private readonly TestOccasionRepository _testOccasionRepository;

        public SearchMgr(string connectionString, string trafikVerketBaseUri)
        {
            _trafikverketMgr = new TrafikverketMgr(trafikVerketBaseUri);
            _testOccasionRepository = new TestOccasionRepository(connectionString);
        }

        public async Task<TestOccasionData> SearchTests(SearchRequest searchRequest)
        {
            var testOccasionsJson = await _trafikverketMgr.SearchTestOccasions(searchRequest);

            var newTestOccasions = convertJsonMappingToDTO(testOccasionsJson, searchRequest.UserId);
            var testOccasionsFromDb = getTestOccasionsFromDB(searchRequest);

            //newTestOccasions = 

        }

        private List<TestOccasionData> getTestOccasionsFromDB(SearchRequest searchRequest)
        {
            var testOccasionsFromDb = _testOccasionRepository.Find(x =>
                                                        x.UserId == searchRequest.UserId &&
                                                        x.TestTypeId == searchRequest.TestTypeId &&
                                                        x.VehicleTypeId == searchRequest.VehicleTypeId &&
                                                        x.LocationId == searchRequest.LocationId &&
                                                        x.LanguageId == searchRequest.LanguageId);

            var testOccasions = new List<TestOccasionData>();

            foreach (var testOccasion in testOccasionsFromDb)
            {
                testOccasions.Add(new TestOccasionData
                {
                    TestTypeId = testOccasion.TestTypeId,
                    OccasionChoiceId = testOccasion.OccasionChoiceId,
                    VehicleTypeId = testOccasion.VehicleTypeId,
                    ExaminationName = testOccasion.ExaminationName,
                    ExaminationDate = testOccasion.ExaminationDate,
                    ExaminationTime = testOccasion.ExaminationTime,
                    Cost = testOccasion.Cost,
                    CostText = testOccasion.CostText,
                    IncreasedFee = testOccasion.IncreasedFee,
                    IsEducatorBooking = testOccasion.IsEducatorBooking,
                    IsLateCancellation = testOccasion.IsLateCancellation,
                    LanguageId = testOccasion.LanguageId,
                    LocationId = testOccasion.LocationId,
                    LocationName = testOccasion.Location.Description,
                    UserId = testOccasion.UserId
                });
            }

            return testOccasions.Distinct(new TestOccasionComparer()).ToList();
        }

        private List<TestOccasionData> convertJsonMappingToDTO(List<TestOccasionJson> testOccasionsList, int userId)
        {
            var newTestOccasions = new List<TestOccasionData>();

            foreach (var testOccasion in testOccasionsList)
            {
                newTestOccasions.Add(new TestOccasionData
                {
                    TestTypeId = testOccasion.ExaminationTypeId,
                    OccasionChoiceId = testOccasion.OccasionChoiceId,
                    VehicleTypeId = testOccasion.VehicleTypeId,
                    ExaminationName = testOccasion.ExaminationName,
                    ExaminationDate = testOccasion.Date,
                    ExaminationTime = testOccasion.Time,
                    Cost = testOccasion.Cost,
                    CostText = testOccasion.CostText,
                    IncreasedFee = testOccasion.IncreasedFee,
                    IsEducatorBooking = testOccasion.IsEducatorBooking,
                    IsLateCancellation = testOccasion.IsLateCancellation,
                    LanguageId = testOccasion.LanguageId,
                    LocationId = testOccasion.LocationId,
                    LocationName = testOccasion.LocationName,
                    UserId = userId
                });
            }

            return newTestOccasions.Distinct(new TestOccasionComparer()).ToList();
        }

        public async Task<bool> CanBookTest(CheckBookingHindranceRequest checkBookingHindranceRequest)
        {
            return await _trafikverketMgr.CheckBookingHindrances(checkBookingHindranceRequest.SocialSecurityNumber, checkBookingHindranceRequest.LicenseId);
        }


    }
}

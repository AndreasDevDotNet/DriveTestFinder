using DriveTestFinderLib.Model.DTO;
using DriveTestFinderLib.Model.JsonMappingClasses;
using DriveTestFinderLib.Model.Request;
using DriveTestFinderRepository.Entities;
using DriveTestFinderRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DriveTestFinderLib.Managers
{
    public class SearchMgr
    {
        private readonly TrafikverketMgr _trafikverketMgr;
        private readonly TestOccasionRepository _testOccasionRepository;

        public SearchMgr(string connectionString, string trafikVerketBaseUri)
        {
            _trafikverketMgr = new TrafikverketMgr(trafikVerketBaseUri);
            _testOccasionRepository = new TestOccasionRepository(connectionString);
        }

        #region Search Tests

        public async Task<List<TestOccasionData>> SearchTests(SearchRequest searchRequest)
        {
            var testOccasionsJson = await _trafikverketMgr.SearchTestOccasions(searchRequest);

            var newTestOccasionDataList = convertJsonMappingToDTO(testOccasionsJson, searchRequest.UserId);
            var testOccasionDataFromDbList = getTestOccasionsFromDB(searchRequest, out List<TestOccasion> testOccasionsDbList);

            newTestOccasionDataList = newTestOccasionDataList.Except(testOccasionDataFromDbList, new TestOccasionComparer()).ToList();

            if (searchRequest.SaveResultInDB && newTestOccasionDataList.Count > 0)
            {
                await resetIsNewFlag(testOccasionsDbList);
                await saveTestOccasionsInDB(newTestOccasionDataList);
            }

            if (searchRequest.OnlyReturnNew)
            {
                return newTestOccasionDataList;
            }
            else
            {
                return newTestOccasionDataList.Union(testOccasionDataFromDbList.Where(x => x.ExaminationDate >= searchRequest.FromDate), new TestOccasionComparer()).ToList();
            }

        }

        private async Task resetIsNewFlag(List<TestOccasion> testOccasionsFromDb)
        {
            testOccasionsFromDb.ForEach(x => x.IsNew = false);
            await _testOccasionRepository.UpdateManyAsync(testOccasionsFromDb);
        }

        private async Task saveTestOccasionsInDB(List<TestOccasionData> newTestOccasions)
        {
            var testOccasionsToAdd = newTestOccasions.Select(x => new TestOccasion
            {
                Cost = x.Cost,
                CostText = x.CostText,
                ExaminationDate = x.ExaminationDate,
                ExaminationName = x.ExaminationName,
                ExaminationTime = x.ExaminationTime,
                IncreasedFee = x.IncreasedFee,
                IsEducatorBooking = x.IsEducatorBooking,
                IsLateCancellation = x.IsLateCancellation,
                IsNew = true,
                LanguageId = x.LanguageId,
                LocationId = x.LocationId,
                OccasionChoiceId = x.OccasionChoiceId,
                TestTypeId = x.TestTypeId,
                UserId = x.UserId,
                VehicleTypeId = x.VehicleTypeId
            }).ToList();

            await _testOccasionRepository.AddManyAsync(testOccasionsToAdd);
        }

        private List<TestOccasionData> getTestOccasionsFromDB(SearchRequest searchRequest, out List<TestOccasion> testOccasionsDbList)
        {
            var testOccasionsFromDb = _testOccasionRepository.FindQueryable(x =>
                                                        x.UserId == searchRequest.UserId &&
                                                        x.TestTypeId == searchRequest.TestTypeId &&
                                                        x.VehicleTypeId == searchRequest.VehicleTypeId &&
                                                        x.LocationId == searchRequest.LocationId &&
                                                        x.LanguageId == searchRequest.LanguageId)
                                                        .Include(x => x.Location).ToList();

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

            testOccasionsDbList = testOccasionsFromDb;

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
                    UserId = userId,
                    IsNew = true
                });
            }

            return newTestOccasions.Distinct(new TestOccasionComparer()).ToList();
        }

        #endregion

        #region CheckBookingHindrances

        public async Task<bool> CheckBookingHindrances(CheckBookingHindranceRequest checkBookingHindranceRequest)
        {
            return await _trafikverketMgr.CheckBookingHindrances(checkBookingHindranceRequest.SocialSecurityNumber, checkBookingHindranceRequest.LicenseId);
        }
        
        #endregion
    }
}

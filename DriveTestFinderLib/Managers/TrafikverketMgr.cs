using DriveTestFinderLib.Model.JsonMappingClasses;
using DriveTestFinderLib.Model.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DriveTestFinderLib.Managers
{
    public class TrafikverketMgr
    {
        private HttpClient _httpClient;
        private string _baseUri;

        public TrafikverketMgr(string baseUri)
        {
            _httpClient = new HttpClient();
            _baseUri = baseUri;
        }

        #region SearchTestOccasions

        internal async Task<List<TestOccasionJson>> SearchTestOccasions(SearchRequest searchRequest)
        {
            var bookingRequest = intializeBookingRequest(searchRequest);

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                _baseUri + "/Boka/occasion-bundles"
            );

            var bookingRequestJson = JsonConvert.SerializeObject(bookingRequest);

            request.Content = new StringContent(bookingRequestJson, Encoding.UTF8, "application/json");

            var bookingResponse = await _httpClient.SendAsync(request);

            if (!bookingResponse.IsSuccessStatusCode)
            {
                return null;
            }

            var bookingResponseJson = await bookingResponse.Content.ReadAsStringAsync();

            var testOccasions = parseTestOccasions(bookingResponseJson);

            return testOccasions;
        }

        private List<TestOccasionJson> parseTestOccasions(string testOccasionsJson)
        {
            var occasionData = JObject.Parse(testOccasionsJson);

            var occasionDataList = (JArray)occasionData["data"]["bundles"];

            var testOccasionList = new List<TestOccasionJson>();

            for (int i = 0; i < occasionDataList.Count; i++)
            {
                var o = occasionDataList[i]["occasions"];
                var json = o.ToString();

                testOccasionList.AddRange(JsonConvert.DeserializeObject<List<TestOccasionJson>>(json));
            }

            foreach (var testOccasion in testOccasionList)
            {
                var date = testOccasion.Date.ToString("yyyy-MM-dd");
                date += " " + testOccasion.Time;

                testOccasion.Date = DateTime.Parse(date);
            }

            return testOccasionList;
        }

        private BookingRequest intializeBookingRequest(SearchRequest searchRequest)
        {
            var newRequest = new BookingRequest();

            newRequest.BookingSession = new BookingSession
            {
                SocialSecurityNumber = searchRequest.SocialSecurityNumber,
                LicenceId = searchRequest.LicenseId,
                BookingModeId = 0,
                IgnoreDebt = false,
                IgnoreBookingHindrance = false,
                ExaminationTypeId = 0,
                RescheduleTypeId = "0"
            };

            newRequest.OccasionBundleQuery = new OccasionBundleQuery
            {
                StartDate = searchRequest.FromDate.ToString("O"),
                LocationId = searchRequest.LocationId,
                LanguageId = searchRequest.LanguageId,
                VehicleTypeId = searchRequest.VehicleTypeId,
                TachographTypeId = 1,
                OccasionChoiceId = 1,
                ExaminationTypeId = searchRequest.TestTypeId
            };

            return newRequest;
        }

        #endregion

        #region CheckBookingHindrances

        internal async Task<bool> CheckBookingHindrances(string socialSecurityNumber, int licenceId)
        {
            var bookingSession = new BookingSession { SocialSecurityNumber = socialSecurityNumber, LicenceId = licenceId };

            var request = new HttpRequestMessage(
                HttpMethod.Post,
                _baseUri + "/boka/booking-hindrances"
            );

            var bookingSessionJson = JsonConvert.SerializeObject(bookingSession);
            request.Content = new StringContent(bookingSessionJson, Encoding.UTF8, "application/json");

            var bookingHindranceResponse = await _httpClient.SendAsync(request);

            if (!bookingHindranceResponse.IsSuccessStatusCode)
            {
                return false;
            }

            var bookingHindranceResponseJson = await bookingHindranceResponse.Content.ReadAsStringAsync();

            return parseCanBookLicenseResponse(bookingHindranceResponseJson);
        }

        private bool parseCanBookLicenseResponse(string bookingHindranceResponseJson)
        {
            var hindranceData = JObject.Parse(bookingHindranceResponseJson);
            var hindranceDataJson = hindranceData["data"].ToString();

            var canBookLicenseResponse = JsonConvert.DeserializeObject<CanBookLicenseResponse>(hindranceDataJson);

            return canBookLicenseResponse.CanBookLicence;
        } 

        #endregion


    }
}

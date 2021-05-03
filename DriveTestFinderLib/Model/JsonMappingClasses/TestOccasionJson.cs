using System;
using Newtonsoft.Json;

namespace DriveTestFinderLib.Model.JsonMappingClasses
{
    public class TestOccasionJson
    {
        [JsonProperty("examinationId")]
        public int? ExaminationId { get; set; }
        [JsonProperty("examinationTypeId")]
        public int ExaminationTypeId { get; set; }
        [JsonProperty("locationId")]
        public int LocationId { get; set; }
        [JsonProperty("occasionChoiceId")]
        public int OccasionChoiceId { get; set; }
        [JsonProperty("vehicleTypeId")]
        public int VehicleTypeId { get; set; }
        [JsonProperty("languageId")]
        public int LanguageId { get; set; }
        [JsonProperty("tachographTypeId")]
        public int TachographTypeId { get; set; }
        [JsonProperty("name")]
        public string ExaminationName { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("time")]
        public string Time { get; set; }
        [JsonProperty("locationName")]
        public string LocationName { get; set; }
        [JsonProperty("cost")]
        public string Cost { get; set; }
        [JsonProperty("costText")]
        public string CostText { get; set; }
        [JsonProperty("increasedFee")]
        public bool IncreasedFee { get; set; }
        [JsonProperty("isEducatorBooking")]
        public bool? IsEducatorBooking { get; set; }
        [JsonProperty("isLateCancellation")]
        public bool IsLateCancellation { get; set; }
        [JsonProperty("placeAddress")]
        public string PlaceAddress { get; set; }
    }
}

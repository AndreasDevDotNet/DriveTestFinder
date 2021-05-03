using Newtonsoft.Json;

namespace DriveTestFinderLib.Model.JsonMappingClasses
{
    public class OccasionBundleQuery
    {
        [JsonProperty("startDate")]
        public string StartDate { get; set; }
        [JsonProperty("locationId")]
        public int LocationId { get; set; }
        [JsonProperty("languageId")]
        public int LanguageId { get; set; }
        [JsonProperty("vehicleTypeId")]
        public int VehicleTypeId { get; set; }
        [JsonProperty("tachographTypeId")]
        public int TachographTypeId { get; set; }
        [JsonProperty("occasionChoiceId")]
        public int OccasionChoiceId { get; set; }
        [JsonProperty("examinationTypeId")]
        public int ExaminationTypeId { get; set; }
    }
}

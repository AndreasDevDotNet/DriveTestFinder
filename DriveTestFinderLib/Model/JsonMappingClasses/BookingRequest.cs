using Newtonsoft.Json;

namespace DriveTestFinderLib.Model.JsonMappingClasses
{
    public class BookingRequest
    {
        [JsonProperty("bookingSession")]
        public BookingSession BookingSession { get; set; }
        [JsonProperty("occasionBundleQuery")]
        public OccasionBundleQuery OccasionBundleQuery { get; set; }
    }
}

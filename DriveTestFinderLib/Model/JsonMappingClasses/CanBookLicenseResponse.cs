using Newtonsoft.Json;
using System.Collections.Generic;

namespace DriveTestFinderLib.Model.JsonMappingClasses
{
    public class CanBookLicenseResponse
    {
        [JsonProperty("canBookLicence")]
        public bool CanBookLicence { get; set; }
        [JsonProperty("hindranceMessages")]
        public List<string> HindranceMessages { get; set; }
    }
}

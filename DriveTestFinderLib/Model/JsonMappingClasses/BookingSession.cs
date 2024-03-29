﻿using Newtonsoft.Json;

namespace DriveTestFinderLib.Model.JsonMappingClasses
{
    public class BookingSession
    {
        public BookingSession()
        {
            BookingModeId = 0;
            IgnoreDebt = false;
            IgnoreBookingHindrance = false;
            ExaminationTypeId = 0;
            RescheduleTypeId = "0";
        }

        [JsonProperty("socialSecurityNumber")]
        public string SocialSecurityNumber { get; set; }
        [JsonProperty("licenceId")]
        public int LicenceId { get; set; }
        [JsonProperty("bookingModeId")]
        public int BookingModeId { get; set; }
        [JsonProperty("ignoreDebt")]
        public bool IgnoreDebt { get; set; }
        [JsonProperty("ignoreBookingHindrance")]
        public bool IgnoreBookingHindrance { get; set; }
        [JsonProperty("examinationTypeId")]
        public int ExaminationTypeId { get; set; }
        [JsonProperty("rescheduleTypeId")]
        public string RescheduleTypeId { get; set; }
    }
}

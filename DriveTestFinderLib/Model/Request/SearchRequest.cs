using System;

namespace DriveTestFinderLib.Model.Request
{
    public class SearchRequest
    {
        public int UserId { get; set; }
        public string SocialSecurityNumber { get; set; }
        public int LanguageId { get; set; }
        public int LocationId { get; set; }
        public int LicenseId { get; set; }
        public int TestTypeId { get; set; }
        public int VehicleTypeId { get; set; }
        public DateTime FromDate { get; set; }
        public bool SaveResultInDB { get; set; }
        public bool OnlyReturnNew { get; set; }
    }
}

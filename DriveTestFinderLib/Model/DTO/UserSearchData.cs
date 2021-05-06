using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTestFinderLib.Model.DTO
{
    public class UserSearchData
    {
        public int UserId { get; set; }
        public int LanguageId { get; set; }
        public int LocationId { get; set; }
        public int LicenseId { get; set; }
        public int TestTypeId { get; set; }
        public int VehicleTypeId { get; set; }
        public DateTime FromDate { get; set; }
    }
}

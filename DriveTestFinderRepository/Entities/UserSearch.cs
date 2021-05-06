using System;
using System.Collections.Generic;

#nullable disable

namespace DriveTestFinderRepository.Entities
{
    public partial class UserSearch :IEntity
    {
        public int UserSearchId { get; set; }
        public int LocationId { get; set; }
        public int LicenseId { get; set; }
        public int TestTypeId { get; set; }
        public int VehicleTypeId { get; set; }
        public DateTime FromDate { get; set; }
        public int UserId { get; set; }

        public virtual License License { get; set; }
        public virtual Location Location { get; set; }
        public virtual TestType TestType { get; set; }
        public virtual User User { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}

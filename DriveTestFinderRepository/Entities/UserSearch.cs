using System;
using System.Collections.Generic;

#nullable disable

namespace DriveTestFinderRepository.Entities
{
    public class UserSearch : IEntity
    {
        public int UserSearchId { get; set; }
        public int Location { get; set; }
        public int License { get; set; }
        public int TestType { get; set; }
        public int VehicleType { get; set; }
        public DateTime FromDate { get; set; }

        public virtual License LicenseNavigation { get; set; }
        public virtual Location LocationNavigation { get; set; }
        public virtual TestType TestTypeNavigation { get; set; }
        public virtual VehicleType VehicleTypeNavigation { get; set; }
    }
}

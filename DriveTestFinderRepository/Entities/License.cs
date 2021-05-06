using System;
using System.Collections.Generic;

#nullable disable

namespace DriveTestFinderRepository.Entities
{
    public partial class License : IEntity
    {
        public License()
        {
            LicenseTestTypes = new HashSet<LicenseTestType>();
            UserSearches = new HashSet<UserSearch>();
        }

        public int LicenseId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LicenseTestType> LicenseTestTypes { get; set; }
        public virtual ICollection<UserSearch> UserSearches { get; set; }
    }
}

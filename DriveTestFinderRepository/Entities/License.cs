using System.Collections.Generic;

namespace DriveTestFinderRepository.Entities
{
    public class License : IEntity
    {
        public int LicenseId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<UserSearch> UserSearches { get; set; }
        public virtual ICollection<LicenseTestType> LicenseTestTypes { get; set; }
    }
}

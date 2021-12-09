using System;
using System.Collections.Generic;

#nullable disable

namespace DriveTestFinderRepository.Entities
{
    public partial class TestType : IEntity
    {
        public TestType()
        {
            LocationTestTypes = new HashSet<LocationTestType>();
            LicenseTestTypes = new HashSet<LicenseTestType>();
            TestOccasions = new HashSet<TestOccasion>();
            UserSearches = new HashSet<UserSearch>();
        }

        public int TestTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LocationTestType> LocationTestTypes { get; set; }
        public virtual ICollection<LicenseTestType> LicenseTestTypes { get; set; }
        public virtual ICollection<TestOccasion> TestOccasions { get; set; }
        public virtual ICollection<UserSearch> UserSearches { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DriveTestFinderRepository.Entities
{
    public partial class Location : IEntity
    {
        public Location()
        {
            LocationTestTypes = new HashSet<LocationTestType>();
            TestOccasions = new HashSet<TestOccasion>();
            UserSearches = new HashSet<UserSearch>();
        }

        public int LocationId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LocationTestType> LocationTestTypes { get; set; }
        public virtual ICollection<TestOccasion> TestOccasions { get; set; }
        public virtual ICollection<UserSearch> UserSearches { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace DriveTestFinderRepository.Entities
{
    public partial class Location : IEntity
    {
        public Location()
        {
            TestOccasions = new HashSet<TestOccasion>();
            UserSearches = new HashSet<UserSearch>();
        }

        public int LocationId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TestOccasion> TestOccasions { get; set; }
        public virtual ICollection<UserSearch> UserSearches { get; set; }
    }
}

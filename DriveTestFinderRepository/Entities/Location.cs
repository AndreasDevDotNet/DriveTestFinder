using System.Collections.Generic;

namespace DriveTestFinderRepository.Entities
{
    public class Location : IEntity
    {
        public Location()
        {
            TestOccasions = new HashSet<TestOccasion>();
        }

        public int LocationId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TestOccasion> TestOccasions { get; set; }
        public virtual ICollection<UserSearch> UserSearches { get; set; }
    }
}

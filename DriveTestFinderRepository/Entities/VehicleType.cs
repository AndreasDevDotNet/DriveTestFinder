using System.Collections.Generic;

namespace DriveTestFinderRepository.Entities
{
    public class VehicleType : IEntity
    {
        public VehicleType()
        {
            TestOccasions = new HashSet<TestOccasion>();
        }

        public int VehicleTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TestOccasion> TestOccasions { get; set; }
        public virtual ICollection<UserSearch> UserSearches { get; set; }
    }
}

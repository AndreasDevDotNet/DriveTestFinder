using System;
using System.Collections.Generic;

#nullable disable

namespace DriveTestFinderRepository.Entities
{
    public class TestType : IEntity
    {
        public TestType()
        {
            TestOccasions = new HashSet<TestOccasion>();
        }

        public int TestTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TestOccasion> TestOccasions { get; set; }
        public virtual ICollection<UserSearch> UserSearches { get; set; }
    }
}

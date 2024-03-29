﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DriveTestFinderRepository.Entities
{
    public partial class Language : IEntity
    {
        public Language()
        {
            TestOccasions = new HashSet<TestOccasion>();
            Users = new HashSet<User>();
        }

        public int LanguageId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TestOccasion> TestOccasions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}

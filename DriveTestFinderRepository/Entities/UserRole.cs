using System;
using System.Collections.Generic;

#nullable disable

namespace DriveTestFinderRepository.Entities
{
    public partial class UserRole : IEntity
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int UserRoleId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

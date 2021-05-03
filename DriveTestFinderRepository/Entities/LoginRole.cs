using System.Collections.Generic;

namespace DriveTestFinderRepository.Entities
{
    public class LoginRole : IEntity
    {
        public int LoginRoleId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Login> Logins { get; set; }
    }
}

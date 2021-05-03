using System.Collections.Generic;

namespace DriveTestFinderRepository.Entities
{
    public class Login : IEntity
    {
        public int LoginId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual LoginRole Role { get; set; }
    }
}

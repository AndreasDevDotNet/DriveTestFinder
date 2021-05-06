using System;
using System.Collections.Generic;

#nullable disable

namespace DriveTestFinderRepository.Entities
{
    public partial class User : IEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool NotifyByPush { get; set; }
        public bool NotifyByEmail { get; set; }
        public int LanguageId { get; set; }
        public int SubscriptionId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }

        public virtual Language Language { get; set; }
        public virtual Subscription Subscription { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<UserSearch> UserSearches { get; set; }
    }
}

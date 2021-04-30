using System;
using System.Collections.Generic;

#nullable disable

namespace DriveTestFinderRepository.Entities
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SocialSecurityNumber { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool NotifyByPush { get; set; }
        public bool NotifyByEmail { get; set; }
        public int Language { get; set; }
        public int Subscription { get; set; }

        public virtual Language LanguageNavigation { get; set; }
        public virtual Subscription SubscriptionNavigation { get; set; }
    }
}

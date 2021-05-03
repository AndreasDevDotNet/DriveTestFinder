namespace DriveTestFinderRepository.Entities
{
    public class User : IEntity
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
        public int LoginId { get; set; }

        public virtual Language Language { get; set; }
        public virtual Subscription Subscription { get; set; }
        public virtual Login Login { get; set; }
    }
}

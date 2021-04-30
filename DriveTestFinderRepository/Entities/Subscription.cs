using System.Collections.Generic;

namespace DriveTestFinderRepository.Entities
{
    public class Subscription : IEntity
    {
        public Subscription()
        {
            Users = new HashSet<User>();
        }

        public int SubscriptionId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}

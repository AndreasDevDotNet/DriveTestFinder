using DriveTestFinderRepository.Entities;

namespace DriveTestFinderRepository.Repositories
{
    public class SubscriptionRepository : DataRepositoryBase<Subscription>
    {
        public SubscriptionRepository(string connectionString) : base(connectionString)
        {
        }
    }
}

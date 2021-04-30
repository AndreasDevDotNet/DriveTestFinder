using DriveTestFinderRepository.Entities;

namespace DriveTestFinderRepository.Repositories
{
    public class UserRepository : DataRepositoryBase<User>
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }
    }
}

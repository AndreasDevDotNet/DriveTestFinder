using DriveTestFinderRepository.Entities;

namespace DriveTestFinderRepository.Repositories
{
    public class TestOccasionRepository : DataRepositoryBase<TestOccasion>
    {
        public TestOccasionRepository(string connectionString) : base(connectionString)
        {
        }
    }
}

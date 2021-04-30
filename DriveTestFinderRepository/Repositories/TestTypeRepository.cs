using DriveTestFinderRepository.Entities;

namespace DriveTestFinderRepository.Repositories
{
    public class TestTypeRepository : DataRepositoryBase<TestType>
    {
        public TestTypeRepository(string connectionString) : base(connectionString)
        {
        }
    }
}

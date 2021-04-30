using DriveTestFinderRepository.Entities;

namespace DriveTestFinderRepository.Repositories
{
    public class LicenseRepository : DataRepositoryBase<License>
    {
        public LicenseRepository(string connectionString) : base(connectionString)
        {
        }
    }
}

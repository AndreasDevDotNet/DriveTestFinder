using DriveTestFinderRepository.Entities;

namespace DriveTestFinderRepository.Repositories
{
    public class LocationRepository : DataRepositoryBase<Location>
    {
        public LocationRepository(string connectionString) : base(connectionString)
        {
        }
    }
}

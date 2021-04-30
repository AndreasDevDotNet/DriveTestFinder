using DriveTestFinderRepository.Entities;

namespace DriveTestFinderRepository.Repositories
{
    public class VehicleTypeRepository : DataRepositoryBase<VehicleType>
    {
        public VehicleTypeRepository(string connectionString) : base(connectionString)
        {
        }
    }
}

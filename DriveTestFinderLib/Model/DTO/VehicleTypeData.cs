using DriveTestFinderRepository.Entities;

namespace DriveTestFinderLib.Model.DTO
{
    public class VehicleTypeData
    {
        public int VehicleTypeId { get; set; }
        public string Description { get; set; }

        public static VehicleTypeData FromVehicleType(VehicleType vehicleType)
        {
            return new VehicleTypeData { VehicleTypeId = vehicleType.VehicleTypeId, Description = vehicleType.Description };
        }
    }
}

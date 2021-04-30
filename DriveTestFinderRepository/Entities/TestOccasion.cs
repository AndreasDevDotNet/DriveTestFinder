using System;

namespace DriveTestFinderRepository.Entities
{
    public class TestOccasion : IEntity
    {
        public int TestOccasionId { get; set; }
        public int TestTypeId { get; set; }
        public int LocationId { get; set; }
        public int? OccasionChoiceId { get; set; }
        public int? VehicleTypeId { get; set; }
        public int LanguageId { get; set; }
        public string ExaminationName { get; set; }
        public DateTime ExaminationDate { get; set; }
        public string ExaminationTime { get; set; }
        public string Cost { get; set; }
        public string CostText { get; set; }
        public bool IncreasedFee { get; set; }
        public bool? IsEducatorBooking { get; set; }
        public bool IsLateCancellation { get; set; }
        public bool IsNew { get; set; }
        public int UserId { get; set; }

        public virtual Language Language { get; set; }
        public virtual Location Location { get; set; }
        public virtual TestType TestType { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}

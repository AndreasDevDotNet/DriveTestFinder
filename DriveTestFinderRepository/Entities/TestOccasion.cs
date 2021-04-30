using System;
using System.Collections.Generic;

#nullable disable

namespace DriveTestFinderRepository.Entities
{
    public class TestOccasion : IEntity
    {
        public int TestOccasionId { get; set; }
        public int TestType { get; set; }
        public int Location { get; set; }
        public int? OccasionChoiceId { get; set; }
        public int? VehicleType { get; set; }
        public int Language { get; set; }
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

        public virtual Language LanguageNavigation { get; set; }
        public virtual Location LocationNavigation { get; set; }
        public virtual TestType TestTypeNavigation { get; set; }
        public virtual VehicleType VehicleTypeNavigation { get; set; }
    }
}

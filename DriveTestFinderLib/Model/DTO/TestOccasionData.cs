using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveTestFinderLib.Model.DTO
{
    public class TestOccasionData
    {
        public int TestOccasionId { get; set; }
        public int TestTypeId { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
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
        public int UserId{ get; set; }
    }

    public class TestOccasionComparer : IEqualityComparer<TestOccasionData>
    {
        public bool Equals(TestOccasionData x, TestOccasionData y)
        {
            return x.TestTypeId == y.TestTypeId &&
                   x.LanguageId == y.LanguageId &&
                   x.LocationId == y.LocationId &&
                   x.VehicleTypeId == y.VehicleTypeId &&
                   x.ExaminationDate.ToString("yyyyMMdd") == y.ExaminationDate.ToString("yyyyMMdd") &&
                   x.ExaminationTime.Trim() == y.ExaminationTime.Trim() &&
                   x.UserId == y.UserId;
        }

        public int GetHashCode(TestOccasionData obj)
        {
            int hashCode = 13;

            hashCode = (hashCode * 7) + 
                       obj.ExaminationDate.ToString("yyyyMMdd").GetHashCode() ^ 
                       obj.ExaminationTime.Trim().GetHashCode() ^ 
                       obj.LocationId.GetHashCode() ^
                       obj.LanguageId.GetHashCode() ^
                       obj.TestTypeId.GetHashCode() ^ 
                       obj.VehicleTypeId.GetHashCode() ^
                       obj.UserId.GetHashCode();

            return hashCode.GetHashCode();
        }
    }
}

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
            var equalsStringX = x.ExaminationDate.ToString("yyyy-MM-dd").Trim() + x.ExaminationTime.Trim() + x.LocationId + x.TestTypeId;
            var equalsStringY = y.ExaminationDate.ToString("yyyy-MM-dd").Trim() + y.ExaminationTime.Trim() + y.LocationId + y.TestTypeId;

            return equalsStringX == equalsStringY;
        }

        public int GetHashCode(TestOccasionData obj)
        {
            int hashCode = 13;

            var hashString = obj.ExaminationDate.ToString("yyyy-MM-dd").Trim() + obj.ExaminationTime.Trim() + obj.LocationId + obj.TestTypeId;

            hashCode = (hashCode * 7) + hashString.GetHashCode(); ;

            return hashCode;
        }
    }
}

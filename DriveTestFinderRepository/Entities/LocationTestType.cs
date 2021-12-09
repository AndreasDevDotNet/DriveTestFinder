namespace DriveTestFinderRepository.Entities
{
    public partial class LocationTestType
    {
        public int LocationId { get; set; }
        public int TestTypeId { get; set; }

        public virtual Location Location { get; set; }
        public virtual TestType TestType { get; set; }
    }
}

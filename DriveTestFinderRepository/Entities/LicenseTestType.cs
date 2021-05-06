using System;
using System.Collections.Generic;

#nullable disable

namespace DriveTestFinderRepository.Entities
{
    public partial class LicenseTestType : IEntity
    {
        public int LicenseId { get; set; }
        public int TestTypeId { get; set; }

        public virtual License License { get; set; }
        public virtual TestType TestType { get; set; }
    }
}

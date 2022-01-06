using System;

namespace DataAccess
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeactivated { get; set; }
        public DateTime? DeactivatedDate { get; set; }
    }
}

using System;

namespace PaymentApp.Entity.BaseEntity
{
    public class AuditInfoBaseEntity
    {
        public bool IsActive { get; set; } = true;
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}

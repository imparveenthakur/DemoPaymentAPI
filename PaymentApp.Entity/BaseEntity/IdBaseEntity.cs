using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Entity.BaseEntity
{
    public class IdBaseEntity<T> : AuditInfoBaseEntity
    {
        public T Id { get; set; }
    }
}

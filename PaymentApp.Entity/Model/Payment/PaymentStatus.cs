using PaymentApp.Entity.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentApp.Entity.Model.Payment
{
    public partial class PaymentStatus: AuditInfoBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentStatusID { get; set; }
        public string Status { get; set; }
        public int? PaymentID { get; set; }
        [ForeignKey("PaymentID")]
        public virtual Payment Payment { get; set; }

    }
}

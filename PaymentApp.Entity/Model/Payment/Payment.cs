using System;
using PaymentApp.Entity.BaseEntity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentApp.Entity.Model.Payment
{
    public partial class Payment : AuditInfoBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentID { get; set; }
        [Required]
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        [Required]
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}

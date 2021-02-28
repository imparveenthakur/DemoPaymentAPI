using System;
using PaymentApp.Common.Enums;
using System.ComponentModel.DataAnnotations;
using PaymentApp.Common.CustomValidations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentApp.ViewModel.Payment
{
    public class PaymentVM
    {
        [Required(ErrorMessage = "Please enter card number.")]
        [CustomCreditCardValidations(AcceptedPaymentCardTypes = PaymentCardType.Visa | PaymentCardType.MasterCard, ErrorMessage = "Please enter valid CCN.")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Please enter card holder name.")]
        public string CardHolder { get; set; }

        [Required(ErrorMessage = "Please enter expiration date.")]
        [DataType(DataType.Date, ErrorMessage = "Incorrect date format.")]
        public DateTime ExpirationDate { get; set; }
        
        [StringLength(3, ErrorMessage = "Security code should be 3 chracters long.", MinimumLength = 0)]
        public string SecurityCode { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public double Amount { get; set; }
    }

}

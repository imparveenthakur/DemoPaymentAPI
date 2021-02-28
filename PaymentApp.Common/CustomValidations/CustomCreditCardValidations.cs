using System;
using PaymentApp.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PaymentApp.Common.CustomValidations
{
   public class CustomCreditCardValidations: ValidationAttribute
    {
        public PaymentCardType AcceptedPaymentCardTypes { get; set; }

        public CustomCreditCardValidations()
        {
            AcceptedPaymentCardTypes = PaymentCardType.All;
        }

        public CustomCreditCardValidations(PaymentCardType AcceptedPaymentCardTypes)
        {
            this.AcceptedPaymentCardTypes = AcceptedPaymentCardTypes;
        }

        public override bool IsValid(object value)
        {
            var number = Convert.ToString(value);

            if (String.IsNullOrEmpty(number))
                return true;

            return IsValidType(number, AcceptedPaymentCardTypes) && IsValidNumber(number);
        }

        public override string FormatErrorMessage(string name)
        {
            return "The " + name + " field contains an invalid credit card number.";
        }

        private bool IsValidType(string cardNumber, PaymentCardType paymentCardType)
        {
            // Visa
            if (Regex.IsMatch(cardNumber, "^(4)")
                && ((paymentCardType & PaymentCardType.Visa) != 0))
                return cardNumber.Length == 13 || cardNumber.Length == 16;

            // MasterCard
            if (Regex.IsMatch(cardNumber, "^(51|52|53|54|55)")
                && ((paymentCardType & PaymentCardType.MasterCard) != 0))
                return cardNumber.Length == 16;

            // Amex
            if (Regex.IsMatch(cardNumber, "^(34|37)")
                && ((paymentCardType & PaymentCardType.Amex) != 0))
                return cardNumber.Length == 15;

            // Diners
            if (Regex.IsMatch(cardNumber, "^(300|301|302|303|304|305|36|38)")
                && ((paymentCardType & PaymentCardType.Diners) != 0))
                return cardNumber.Length == 14;

            //Unknown
            if ((paymentCardType & PaymentCardType.Unknown) != 0)
                return true;

            return false;
        }

        private bool IsValidNumber(string number)
        {
            int[] DELTAS = new int[] { 0, 1, 2, 3, 4, -4, -3, -2, -1, 0 };
            int checksum = 0;
            char[] chars = number.ToCharArray();
            for (int i = chars.Length - 1; i > -1; i--)
            {
                int j = ((int)chars[i]) - 48;
                checksum += j;
                if (((i - chars.Length) % 2) == 0)
                    checksum += DELTAS[j];
            }

            return ((checksum % 10) == 0);
        }
    }
}

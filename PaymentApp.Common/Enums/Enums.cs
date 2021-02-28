using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.Common.Enums
{
    public enum PaymentProviders
    {
        Cheap = 1,
        Expensive = 2,
        Premium = 3
    }
    public enum PaymentStatus
    {
        Pending = 1,
        Processed = 2,
        Failed = 3
    }
    public enum PaymentCardType
    {
        Unknown = 1,
        Visa = 2,
        MasterCard = 4,
        Amex = 8,
        Diners = 16,

        All = PaymentCardType.Visa | PaymentCardType.MasterCard | PaymentCardType.Amex | PaymentCardType.Diners,
        AllOrUnknown = PaymentCardType.Unknown | PaymentCardType.Visa | PaymentCardType.MasterCard | PaymentCardType.Amex | PaymentCardType.Diners
    }
}

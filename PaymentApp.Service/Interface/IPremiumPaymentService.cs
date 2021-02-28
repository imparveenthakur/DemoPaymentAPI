using PaymentApp.ViewModel.Payment;

namespace PaymentApp.Service.Interface
{
    public interface IPremiumPaymentService
    {
        PaymentProcessResponseVM MakePaymentRequest(PaymentVM paymentVM);
    }
}

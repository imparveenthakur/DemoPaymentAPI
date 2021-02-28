using PaymentApp.ViewModel.Payment;

namespace PaymentApp.Service.Interface
{
    public interface ICheapPaymentService
    {

        PaymentProcessResponseVM MakePaymentRequest(PaymentVM paymentVM);
    }
}

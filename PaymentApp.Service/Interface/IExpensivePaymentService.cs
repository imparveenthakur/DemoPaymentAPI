using PaymentApp.ViewModel.Payment;

namespace PaymentApp.Service.Interface
{
    public interface IExpensivePaymentService
    {
        PaymentProcessResponseVM MakePaymentRequest(PaymentVM paymentVM);
    }
}

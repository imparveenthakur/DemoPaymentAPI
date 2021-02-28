using System.Threading.Tasks;
using PaymentApp.ViewModel.Payment;

namespace PaymentApp.Service.Interface
{
    public interface IPaymentService
    {
        Task<PaymentProcessResponseVM> ProcessPayment(PaymentVM paymentVM);
    }
}

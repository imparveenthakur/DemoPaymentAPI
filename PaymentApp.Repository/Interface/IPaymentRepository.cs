using System.Threading.Tasks;
using PaymentApp.ViewModel.Payment;

namespace PaymentApp.Repository.Interface
{
    public interface IPaymentRepository
    {
        Task<string> AddPayment(PaymentVM paymentVM, string paymentStatus);
    }
}

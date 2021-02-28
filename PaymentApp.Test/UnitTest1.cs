using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentApp.Service.Interface;
using PaymentApp.ViewModel.Payment;

namespace PaymentApp.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IPaymentService _paymentService;
        public UnitTest1(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        [TestMethod]
        public async System.Threading.Tasks.Task TestMethod1Async(PaymentVM paymentVM)
        {
            var response = await _paymentService.ProcessPayment(paymentVM);

        }
    }
}

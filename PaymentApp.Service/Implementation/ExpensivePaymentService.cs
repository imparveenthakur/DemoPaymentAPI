using System;
using PaymentApp.Common.Enums;
using PaymentApp.Service.Interface;
using PaymentApp.ViewModel.Payment;

namespace PaymentApp.Service.Implementation
{
    public class ExpensivePaymentService : IExpensivePaymentService
    {
        /// <summary>
        /// To make payment request.
        /// </summary>
        /// <param name="paymentVM">Payment VM.</param>
        /// <returns>
        /// It returns the status of the transaction from payment provider. 
        /// </returns>
        public PaymentProcessResponseVM MakePaymentRequest(PaymentVM paymentVM)
        {
            try
            {
                //Write code here for payment provider 
                var response = new PaymentProcessResponseVM();
                response.TrasactionStatus = PaymentStatus.Processed.ToString();
                response.Message = "Payment is processed:";
                return response;

            }
            catch (Exception e)
            {
                var response = new PaymentProcessResponseVM();
                response.TrasactionStatus = PaymentStatus.Failed.ToString();
                response.Error = e.Message.ToString();
                return response;
            }
        }
    }
}

using System;
using PaymentApp.Repository.Interface;
using PaymentApp.Entity.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using PaymentApp.ViewModel.Payment;
using PaymentApp.Entity.Model.Payment;

namespace PaymentApp.Repository.Implementation
{
    public class PaymentRepository : IPaymentRepository
    {
        protected readonly PaymentDBContext _context;
        internal DbSet<Payment> dbSet;

        public PaymentRepository(PaymentDBContext context)
        {
            _context = context;
            dbSet = context.Set<Payment>();
        }

        /// <summary>
        /// To save payment details.
        /// </summary>
        /// <param name="paymentVM">Payment M</param>
        /// <param name="paymentStatus">Payment Status</param>
        /// <returns>
        /// It returns the payment status.
        /// </returns>
        public async Task<string> AddPayment(PaymentVM paymentVM, string paymentStatus)
        {
            try
            {
                Payment payment = new Payment();
                payment.CardHolder = paymentVM.CardHolder;
                payment.CreditCardNumber = paymentVM.CreditCardNumber;
                payment.ExpirationDate = paymentVM.ExpirationDate;
                payment.SecurityCode = paymentVM.SecurityCode;
                payment.Amount = paymentVM.Amount;
                await _context.Payments.AddAsync(payment);

                PaymentStatus paymentState = new PaymentStatus();
                paymentState.Payment = payment;
                paymentState.Status = paymentStatus;
                await _context.PaymentStatus.AddAsync(paymentState);
                await _context.SaveChangesAsync();
                return "Payment Saved!";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
    }
}

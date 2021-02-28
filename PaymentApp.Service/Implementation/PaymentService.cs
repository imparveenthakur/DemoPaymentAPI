using System;
using AutoMapper;
using System.Threading.Tasks;
using PaymentApp.Common.Enums;
using PaymentApp.Service.Interface;
using PaymentApp.ViewModel.Payment;
using System.Collections.Generic;
using PaymentApp.Repository.UnitOfWorkPattern;

namespace PaymentApp.Service.Implementation
{
    public class PaymentService : IPaymentService
    {

        private readonly IPremiumPaymentService _premiumPaymentService;
        private readonly IExpensivePaymentService _expensivePaymentService;
        private readonly ICheapPaymentService _cheapPaymentService;
        private static int reProcessCount = 0;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, IPremiumPaymentService premiumPaymentService, IExpensivePaymentService expensivePaymentService, ICheapPaymentService cheapPaymentService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _premiumPaymentService = premiumPaymentService;
            _expensivePaymentService = expensivePaymentService;
            _cheapPaymentService = cheapPaymentService;
        }

        /// <summary>
        /// To process payment.
        /// </summary>
        /// <param name="paymentVM">Payment VM</param>
        /// <returns>
        /// It returns the payment status for the requested process.
        /// or 
        /// It returns customized error if any exception occur.
        /// </returns>
        public async Task<PaymentProcessResponseVM> ProcessPayment(PaymentVM paymentVM)
        {
            try
            {
                reProcessCount = 0;
                return await CreatePaymentRequest(paymentVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        /// <summary>
        /// To make payment request.
        /// </summary>
        /// <param name="paymentVM">Payment VM.</param>
        /// <returns>
        /// It returns the status of the transaction from payment provider. 
        /// </returns>
        private async Task<PaymentProcessResponseVM> CreatePaymentRequest(PaymentVM paymentVM)
        {
            try
            {
                PaymentProcessResponseVM paymentProcessResponse = new PaymentProcessResponseVM();
                if (paymentVM.Amount <= 20)
                {
                    paymentProcessResponse = _cheapPaymentService.MakePaymentRequest(paymentVM);
                }

                else if (paymentVM.Amount > 20 & paymentVM.Amount <= 500)
                {
                    if (CheckPaymentProviderAvailable(PaymentProviders.Expensive.ToString()))
                    {
                        paymentProcessResponse = _expensivePaymentService.MakePaymentRequest(paymentVM);
                    }
                    else
                    {
                        paymentProcessResponse = _cheapPaymentService.MakePaymentRequest(paymentVM);
                    }
                }

                else if (paymentVM.Amount > 500)
                {
                    paymentProcessResponse = _premiumPaymentService.MakePaymentRequest(paymentVM);
                    if (paymentProcessResponse.TrasactionStatus == PaymentStatus.Failed.ToString() && reProcessCount < 3)
                    {
                        reProcessCount++;
                        await CreatePaymentRequest(paymentVM);
                    }
                }
                await _unitOfWork.Payment.AddPayment(paymentVM, paymentProcessResponse.TrasactionStatus);
                return paymentProcessResponse;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool CheckPaymentProviderAvailable(string paymentProvider)
        {
            List<string> paymentProviders = new List<string> { "Cheap", "Expensive", "Premium" };
            return paymentProviders.Contains(paymentProvider) ? true : false;
        }

    }
}

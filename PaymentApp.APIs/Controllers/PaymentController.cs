#region using
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentApp.APIs.Helpers;
using PaymentApp.Service.Interface;
using PaymentApp.ViewModel.Payment;
#endregion

namespace PaymentApp.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IResponseFactory _responseFactory;
        public PaymentController(IPaymentService paymentService, IResponseFactory responseFactory)
        {
            _paymentService = paymentService;
            _responseFactory = responseFactory;
        }

        /// <summary>
        /// To process payment.
        /// </summary>
        /// <param name="paymentVM">Payment VM</param>
        /// <returns>
        /// It returns the payment status for the requested process from provider.
        /// or 
        /// It returns error details if any exception occurred.
        /// </returns>
        [AllowAnonymous, HttpPost("ProcessPayment")]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentVM paymentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var paymentProcessResponse = await _paymentService.ProcessPayment(paymentVM);
                    var response = _responseFactory.CreateResponse(paymentProcessResponse, paymentProcessResponse.Message);
                    return Ok(response);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Invalid Request");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}

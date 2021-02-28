using PaymentApp.ViewModel.Shared;
using Microsoft.AspNetCore.Http;

namespace PaymentApp.APIs.Helpers
{
    public class ResponseFactory : PaymentApp.APIs.Helpers.IResponseFactory
    {
        public ResponseWrapper<T> CreateResponse<T>(T data, string message = null, int statusCode = StatusCodes.Status200OK)
        {
            ResponseWrapper<T> response = new ResponseWrapper<T>
            {
                Data = data,
                Message = message,
                Status = statusCode
            };
            return response;
        }
    }
}

using Microsoft.AspNetCore.Http;
using PaymentApp.ViewModel.Shared;

namespace PaymentApp.APIs.Helpers
{
    public interface IResponseFactory
    {
        ResponseWrapper<T> CreateResponse<T>(T data, string message = null, int statusCode = StatusCodes.Status200OK);
    }
}

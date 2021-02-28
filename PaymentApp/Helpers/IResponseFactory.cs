using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PaymentApp.ViewModel.Shared;
using PaymentApp.Common.Utilities;

namespace PaymentApp.API.Helpers
{
    public interface IResponseFactory
    {
        ResponseWrapper<T> CreateResponse<T>(T data, string message = null, int statusCode = StatusCodes.Status200OK);
        ResponseWrapper<ListResponseWrapper<T>> CreateResponse<T>(List<T> data, Pagination pagination = null, string message = null, int statusCode = StatusCodes.Status200OK);
    }
}

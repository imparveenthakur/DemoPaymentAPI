using PaymentApp.Common.StaticConstants;
using PaymentApp.Common.Utilities;
using PaymentApp.ViewModel.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KPFormsModule.API.Helpers
{
    public class ResponseFactory : PaymentApp.API.Helpers.IResponseFactory
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

        public ResponseWrapper<ListResponseWrapper<T>> CreateResponse<T>(List<T> data, Pagination pagination = null, string message = null, int statusCode = StatusCodes.Status200OK)
        {
            ResponseWrapper<ListResponseWrapper<T>> response = new ResponseWrapper<ListResponseWrapper<T>>();
            ListResponseWrapper<T> listResponseVM = new ListResponseWrapper<T>
            {
                Items = data,
                Page = pagination?.PageIndex ?? 0,
                Count = pagination?.PageSize ?? 0,
                TotalCount = pagination?.TotalCount ?? 0,
                TotalPages = pagination?.TotalPages ?? 0,
                Next = pagination.HasNextPage,
                Previous = pagination.HasPreviousPage
            };
            response.Data = listResponseVM;
            response.Message = message;
            response.Status = statusCode;
            return response;
        }
    }
}

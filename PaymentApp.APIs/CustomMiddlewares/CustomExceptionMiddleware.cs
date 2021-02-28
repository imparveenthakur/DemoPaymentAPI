using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Serilog;
using PaymentApp.Common.CustomException;

namespace PaymentApp.APIs.CustomMiddlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomExceptionMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next<see cref="RequestDelegate"/></param>
        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// The InvokeAsync
        /// </summary>
        /// <param name="httpContext">The httpContext<see cref="HttpContext"/></param>
        /// <returns>The <see cref="Task"/></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomException ex)
            {
                Log.Error($"Custom Exception: {ex}");
                await HandleKnownExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                Log.Error($"General Exception: {ex}");
                await HandleUnknownExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// The HandleUnknownExceptionAsync
        /// </summary>
        /// <param name="context">The context<see cref="HttpContext"/></param>
        /// <param name="exception">The exception<see cref="Exception"/></param>
        /// <returns>The <see cref="Task"/></returns>
        private static Task HandleUnknownExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                //Message = KPMessages.GenralException
                Message = exception.Message
            }.ToString());
        }

        /// <summary>
        /// The HandleKnownExceptionAsync
        /// </summary>
        /// <param name="context">The context<see cref="HttpContext"/></param>
        /// <param name="exception">The exception<see cref="Exception"/></param>
        /// <returns>The <see cref="Task"/></returns>
        private static Task HandleKnownExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }

    /// <summary>
    /// Error details class
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// Gets or sets the StatusCode
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}


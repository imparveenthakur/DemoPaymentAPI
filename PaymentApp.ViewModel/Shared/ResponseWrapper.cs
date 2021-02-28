using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.ViewModel.Shared
{
    public class ResponseWrapper<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
    }
}

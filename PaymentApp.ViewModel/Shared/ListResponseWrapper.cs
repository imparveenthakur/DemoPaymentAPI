using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.ViewModel.Shared
{
    public class ListResponseWrapper<T>
    {
        public int Page { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public bool Previous { get; set; }
        public bool Next { get; set; }
        public List<T> Items { get; set; }

    }
}

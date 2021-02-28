using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentApp.ViewModel.Shared
{
    public class BaseVM<T>
    {
        public T Id { get; set; }
        public DateTimeOffset? DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PaymentApp.Common.CustomException
{
    [Serializable]
    public class CustomException:Exception
    {
        protected CustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public CustomException()
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, Exception inner) : base(message, inner)
        {
        }

    }
}

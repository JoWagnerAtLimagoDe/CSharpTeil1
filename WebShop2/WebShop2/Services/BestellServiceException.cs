using System;
using System.Runtime.Serialization;

namespace WebShop.Services
{
    public class BestellServiceException : Exception
    {
        public BestellServiceException()
        {
        }

        public BestellServiceException(string message) : base(message)
        {
        }

        public BestellServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BestellServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

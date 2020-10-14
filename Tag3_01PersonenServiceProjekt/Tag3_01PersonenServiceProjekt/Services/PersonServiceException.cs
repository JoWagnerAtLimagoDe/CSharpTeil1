using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Tag3_01PersonenServiceProjekt.Services
{
    public class PersonServiceException : Exception
    {
        public PersonServiceException()
        {
        }

        public PersonServiceException(string message) : base(message)
        {
        }

        public PersonServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PersonServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

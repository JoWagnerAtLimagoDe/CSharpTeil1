using System;
using System.Runtime.Serialization;

namespace BBk.Rc1.Ricis.DataImport.Exceptions
{
    public class DataImportException : Exception
    {
        public DataImportException()
        {
        }

        public DataImportException(string message) : base(message)
        {
        }

        public DataImportException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataImportException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

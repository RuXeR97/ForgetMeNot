using System;
using System.Runtime.Serialization;

namespace CommonComponents.Exceptions
{
    public class InvalidEventDataException : Exception
    {
        public InvalidEventDataException()
        {
        }

        public InvalidEventDataException(string message) : base(message)
        {
        }

        public InvalidEventDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidEventDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

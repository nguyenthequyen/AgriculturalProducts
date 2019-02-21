using System;
using System.Runtime.Serialization;

namespace AgriculturalProducts.Repository
{
    [Serializable]
    internal class UnintentianalCodeFirstException : Exception
    {
        public UnintentianalCodeFirstException()
        {
        }

        public UnintentianalCodeFirstException(string message) : base(message)
        {
        }

        public UnintentianalCodeFirstException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnintentianalCodeFirstException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
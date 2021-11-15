using System;
using System.Runtime.Serialization;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    [Serializable]
    public class NotValideQuantityExcepton : Exception
    {
        public NotValideQuantityExcepton() : base()
        {
        }

        public NotValideQuantityExcepton(string? message) : base(message)
        {
        }

        public NotValideQuantityExcepton(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotValideQuantityExcepton(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

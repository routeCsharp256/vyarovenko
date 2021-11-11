using System;
using System.Runtime.Serialization;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    [Serializable]
    public class NotValideMerchType : Exception
    {
        public NotValideMerchType() : base()
        {
        }

        public NotValideMerchType(string? message) : base(message)
        {
        }

        public NotValideMerchType(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotValideMerchType(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

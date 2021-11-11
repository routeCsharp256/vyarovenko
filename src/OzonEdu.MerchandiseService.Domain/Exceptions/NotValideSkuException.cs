using System;
using System.Runtime.Serialization;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    public class NotValideSkuException : Exception
    {
        public NotValideSkuException(string? message) : base(message)
        {
        }
    }
}

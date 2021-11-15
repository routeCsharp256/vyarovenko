using System;
using System.Runtime.Serialization;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    public class NotSizeException : Exception
    {
        public NotSizeException(string? message) : base(message)
        {
        }
    }
}

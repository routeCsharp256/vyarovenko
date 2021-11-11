using System;

namespace OzonEdu.MerchandiseService.Domain.Exceptions
{
    public class NotValideSizeException : Exception
    {
        public NotValideSizeException(string? message) : base(message)
        {
        }
    }
}

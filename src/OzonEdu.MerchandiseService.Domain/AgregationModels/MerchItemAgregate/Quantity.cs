using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;
using System;
using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate
{
    /// <summary>
    /// Количество мерча
    /// </summary>
    public class Quantity : ValueObject
    {
        public int Value { get; }

        public Quantity(int quantity)
        {
            if (quantity <= 0)
                throw new NotValideQuantityExcepton(
                    "Количество заказанного товара не может быть меньше или равно нулю");
            Value = quantity;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

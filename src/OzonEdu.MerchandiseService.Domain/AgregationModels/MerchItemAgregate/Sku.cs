using OzonEdu.MerchandiseService.Domain.Exceptions;
using OzonEdu.MerchandiseService.Domain.Models;
using System;
using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate
{
    /// <summary>
    /// Идентификатор для склада
    /// </summary>
    public class Sku : ValueObject
    {
        public long Value { get; }

        public Sku(long sku)
        {
            if (sku < 0) throw new NotValideSkuException("Sku cannot be negative");
            Value = sku;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

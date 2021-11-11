using OzonEdu.MerchandiseService.Domain.Models;
using System;
using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate
{
    /// <summary>
    /// Название мерча
    /// </summary>
    public class Name : ValueObject
    {
        public string Value { get; }

        public Name(string name)
        {
            if (name is null) throw new ArgumentNullException("Name is null");
            Value = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

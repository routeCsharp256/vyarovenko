using OzonEdu.MerchandiseService.Domain.Models;
using System;
using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate
{
    /// <summary>
    /// Заметка по мерчу
    /// </summary>
    public class Tag : ValueObject
    {
        public string Value { get; }
        public Tag(string tag)
        {
            if(tag is null) throw new ArgumentNullException("Tag is null");
            Value = tag;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

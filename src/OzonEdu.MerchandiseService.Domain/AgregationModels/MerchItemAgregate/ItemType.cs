using OzonEdu.MerchandiseService.Domain.Models;
using System;
using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate
{
    /// <summary>
    /// Вид мерча
    /// </summary>
    public class ItemType : Entity
    {
        public MerchType Value { get; }

        public ItemType(MerchType merchType)
        {
            if (merchType is null) throw new ArgumentNullException("ItemType is null");
            Value = merchType;
        }
    }
}

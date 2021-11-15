using OzonEdu.MerchandiseService.Domain.Models;
using System;

namespace OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate
{
    /// <summary>
    /// Вариант вида мерча
    /// </summary>
    public class MerchType : Enumeration
    {
        public static MerchType TShort = new MerchType(1, nameof(TShort));
        public static MerchType Sweatshirt = new MerchType(2, nameof(Sweatshirt));
        public static MerchType Notepad = new MerchType(3, nameof(Notepad));
        public static MerchType Bag = new MerchType(4, nameof(Bag));
        public static MerchType Pen = new MerchType(5, nameof(Pen));
        public static MerchType Socks = new MerchType(6, nameof(Socks));

        public MerchType(int id, string name) : base(id, name)
        {
            if (name is null) throw new ArgumentNullException("MerchTypeName is null");
        }
    }
}

using OzonEdu.MerchandiseService.Domain.Models;
using System;

namespace OzonEdu.MerchandiseService.Domain.AgregationModels.MerchItemAgregate
{
    /// <summary>
    /// Размер одежды
    /// </summary>
    public class ClouthingSize : Enumeration
    {
        public static ClouthingSize NULL = new ClouthingSize(0, nameof(NULL));
        public static ClouthingSize XS = new ClouthingSize(1, nameof(XS));
        public static ClouthingSize S = new ClouthingSize(2, nameof(S));
        public static ClouthingSize M = new ClouthingSize(3, nameof(M));
        public static ClouthingSize L = new ClouthingSize(4, nameof(L));
        public static ClouthingSize XL = new ClouthingSize(5, nameof(XL));
        public static ClouthingSize XXL = new ClouthingSize(6, nameof(XXL));

        public ClouthingSize(int id, string name) : base(id, name)
        {
            if (name is null) throw new ArgumentNullException("ClouthingSizeName is null");
        }
    }
}

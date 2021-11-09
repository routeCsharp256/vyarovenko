using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Models
{
    public sealed class OrderMerchModel
    {
        public Employee Employee { get; set; }
        public List<MerchModel> MerchItems { get; set; }
    }
}

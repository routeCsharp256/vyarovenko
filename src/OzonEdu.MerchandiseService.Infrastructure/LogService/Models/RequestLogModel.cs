using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Infrastructure.Logs.Models
{
    public class RequestLogModel
    {
        public string Route { get; set;}
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
    }

}

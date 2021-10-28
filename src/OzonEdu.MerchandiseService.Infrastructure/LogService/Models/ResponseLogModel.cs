using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Infrastructure.Logs.Models
{
    public class ResponseLogModel
    {
        public string Route { get; set; }
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public string Body { get; set; }
    }

}

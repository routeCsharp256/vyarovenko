using System.Collections.Generic;

namespace OzonEdu.MerchandiseService.Infrastructure.Logs.Models
{
    public class ResponseLogModel
    {
        public string Route { get; set; }
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public string Body { get; set; }
        public override string ToString()
        {
            string result = "\n";
            result += "Response logged:\n";
            result += $"Route: {Route}\n";
            result += $"Headers\n";
            foreach (var header in Headers)
            {
                result += $"\t\"{header.Key}\":\"{header.Value}\"\n";
            }
            result += "Body: " + $"{Body}";
            return result;
        }
    }

}

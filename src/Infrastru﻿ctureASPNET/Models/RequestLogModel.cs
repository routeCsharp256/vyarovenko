using System.Collections.Generic;

namespace Infrastru﻿ctureASPNET.Models
{
    public class RequestLogModel
    {
        public string Route { get; set;}
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public override string ToString()
        {
            string result = "\n";
            result += "Request logged:\n";
            result += $"Route: {Route}\n";
            result += $"Headers\n";
            foreach (var header in Headers)
            {
                result += $"\t\"{header.Key}\":\"{header.Value}\"\n";
            }
            return result;
        }
    }

}

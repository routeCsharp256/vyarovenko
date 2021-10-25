using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastru_ctureASPNET.Models
{
    public static class VersionModel
    {
        public static string Version = Assembly.GetEntryAssembly().GetName().Version?.ToString();
        public static string ServiceName = Assembly.GetEntryAssembly().GetName().Name;
        public static new string ToString()
        {
            return "{" + $"\"version\":\"{Version}\", \"serviceName\": \"{ServiceName}\"" + "}";
        }
    }
}

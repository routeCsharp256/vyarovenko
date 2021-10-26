using System.Reflection;

namespace OzonEdu.MerchandiseService.Infrastructure.Version.Models
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

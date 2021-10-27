using System.Reflection;

namespace OzonEdu.MerchandiseService.Infrastructure.Version.Models
{
    public static class VersionModel
    {
        public readonly static string Version = Assembly.GetEntryAssembly().GetName().Version?.ToString();
        public readonly static string Name = Assembly.GetEntryAssembly().GetName().Name;
        //public static new string ToString()
        //{
        //    return "{" + $"\"version\":\"{Version}\", \"serviceName\": \"{ServiceName}\"" + "}";
        //}
    }
}

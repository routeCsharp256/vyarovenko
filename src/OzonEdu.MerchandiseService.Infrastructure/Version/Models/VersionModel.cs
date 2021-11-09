using System.Reflection;

namespace OzonEdu.MerchandiseService.Infrastructure.Version.Models
{
    public sealed class VersionModel
    {
        public string Version { get; private set; }
        public string Name { get; private set; }

        public VersionModel()
        {
            Version = Assembly.GetEntryAssembly().GetName().Version?.ToString();
            Name = Assembly.GetEntryAssembly().GetName().Name;
        }
    }
}

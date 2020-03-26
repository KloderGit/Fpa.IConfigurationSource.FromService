using Microsoft.Extensions.Configuration;

namespace Fpa.IConfigurationSource.FromService
{
    public static class AddServiceConfigurationExtension
    {
        public static IConfigurationBuilder AddServiceConfiguration(
            this IConfigurationBuilder builder, string server, string rootKey)
        {
            return builder.Add(new ServiceConfigurationSource(server, rootKey));
        }
    }
}

using Microsoft.Extensions.Configuration;
using System;

namespace Fpa.IConfigurationSource.FromService
{
    public static class AddServiceConfigurationExtension
    {
        public static IConfigurationBuilder AddServiceConfiguration(
            this IConfigurationBuilder builder, Uri server, string rootKey)
        {
            return builder.Add(new ServiceConfigurationSource(server, rootKey));
        }
    }
}

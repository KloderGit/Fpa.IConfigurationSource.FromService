using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fpa.IConfigurationSource.FromService
{
    public class ServiceConfigurationSource : Microsoft.Extensions.Configuration.IConfigurationSource
    {
        private Uri Source { get; set; }
        private string Key { get; set; }

        public ServiceConfigurationSource(string server, string rootKey)
        {
            _ = server ?? throw new ArgumentNullException("Не указан сервер конфигураций");
            _ = rootKey ?? throw new ArgumentNullException("Не указан ключ конфигурации");
            Source = new Uri(GetAddressWithProtocol(server));
            Key = rootKey;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            var endpoint = new Uri(Source, PathBuilder());

            return new SeviceConfigurationProvider(endpoint);
        }

        private string PathBuilder()
        {
            return "/" + Key;
        }

        private string GetAddressWithProtocol(string host)
        {
            var prot = "http://";

            if (host.Length < prot.Length || host.Substring(0, 7) != prot)
            {
                return prot + host;
            }

            return host;
        }
    }
}

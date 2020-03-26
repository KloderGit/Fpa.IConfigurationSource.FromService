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
            Source = new Uri(server);
            Key = rootKey;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            var endpoint = new Uri(Source, PathBuilder());

            return new SeviceConfigurationProvider(endpoint);
        }

        private string PathBuilder()
        {
            return "/api" + "/Assembly/" + Key;
        }
    }
}

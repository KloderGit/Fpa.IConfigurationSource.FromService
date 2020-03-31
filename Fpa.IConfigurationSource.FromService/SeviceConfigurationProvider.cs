using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net;

namespace Fpa.IConfigurationSource.FromService
{
    public class SeviceConfigurationProvider : ConfigurationProvider
    {
        private readonly Uri source;

        public SeviceConfigurationProvider(Uri url)
        {
            this.source = url;
        }

        public override void Load()
        {
            using (var client = new WebClient())
            {
                try
                {
                    var response = client.DownloadString(source);

                    var value = JsonConvert.DeserializeObject<ConfigDTO>(response);

                    if(value != null) Data = value.Params?.Where(p=>p.Active == true).ToDictionary(c => c.Key, c => c.Value);
                }
                catch (JsonReaderException ex)
                {
                    throw new JsonReaderException("Не удалось преобразовать результат ответа сервера конфигураций к Json объекту", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Не удалось преобразовать полученный результат к Key:Value", ex);
                }
            }
        }
    }
}

using Hangfire;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrascture.Common.HangFires
{
    public static class HangFireConfigurationExtension
    {
        public static void UseMediator(this IGlobalConfiguration configuration)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            configuration.UseSerializerSettings(jsonSettings);
        }
    }
}

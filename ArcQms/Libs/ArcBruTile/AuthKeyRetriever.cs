
using BrutileArcGIS.Lib;
using System.Collections.Generic;
using System.Net.Http;

namespace BrutileArcGIS.lib
{
    public class AuthKeyRetriever
    {
        private static readonly Dictionary<string, string> Keys = new Dictionary<string, string>(); 

        public static string GetAuthKey(string provider)
        {
            if (!Keys.ContainsKey(provider))
            {
                var config = ConfigurationHelper.GetConfig();
                var authProvider = config.AppSettings.Settings["authProvider"].Value;

                var url = authProvider + provider + "/key.txt";
                var httpClient = new HttpClient();
                var key = httpClient.GetStringAsync(url).Result;
                Keys.Add(provider,key);
            }
            return Keys[provider];
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace IBetWinApp
{
    class JsonUtil
    {
        public static T DeserializeObject<T>(string json)
        {
            T obj = default(T);
            try
            {
                var result = json.Replace(@"\", "");
                result = result.Substring(1, result.Length - 2);
                obj = JsonConvert.DeserializeObject<T>(result);
            }
            catch (Exception ex)
            {
                new MessageDialog("Error ocured while parsing API response").ShowAsync();
            }

            return obj;
        }
    }
}

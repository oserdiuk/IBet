using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IBetWinApp.Managers
{
    public static class ApiManager
    {

        private static string GetParameterString(Dictionary<string, string> paramters)
        {
            List<string> parametersList = new List<string>();
            foreach (var keyValuePair in paramters)
            {
                parametersList.Add(String.Format("{0}={1}", keyValuePair.Key, keyValuePair.Value));
            }

            return String.Join<string>("&", parametersList);
        }
        private static FormUrlEncodedContent PostParameterBody(Dictionary<string, string> paramters)
        {
            List<KeyValuePair<string, string>> parametersList = paramters.ToList();
            return new FormUrlEncodedContent(parametersList);
        }

        public async static Task<string> ExecuteGetRequest(string apiPath, Dictionary<string, string> parameters)
        {
            return await ExecuteRequest(apiPath, parameters, HttpMethod.Get);
        }

        public async static Task<string> ExecutePostRequest(string apiPath, Dictionary<string, string> parameters)
        {
            return await ExecuteRequest(apiPath, parameters, HttpMethod.Post);
        }

        public async static Task<string> ExecuteRequest(string apiPath, Dictionary<string, string> parameters, HttpMethod method)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var cts = new CancellationTokenSource();
                cts.CancelAfter(TimeSpan.FromSeconds(30));

                string requestString = String.Format("http://localhost:54407/{0}", apiPath);
                if (parameters.Count > 0 && method == HttpMethod.Get)
                {
                    requestString += GetParameterString(parameters);
                }

                var resourceUri = new Uri(requestString);
                try
                {
                    HttpResponseMessage response = null;
                    if (method == HttpMethod.Get)
                    {
                        response = await httpClient.GetAsync(resourceUri, cts.Token);
                    }
                    else if (method == HttpMethod.Post)
                    {
                        response = await httpClient.PostAsync(requestString, PostParameterBody(parameters));
                    }

                    string responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
                catch (TaskCanceledException ex)
                {
                    Debug.WriteLine("TaskCanceledException");
                }
                catch (HttpRequestException ex)
                {
                    Debug.WriteLine("HttpRequestException");
                }
                return null;
            }
        }
    }
}

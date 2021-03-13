using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtility.Helpers
{
    public class ConsumeExternalService : IConsumeExternalService
    {
        private readonly IHttpClientFactory _clientFactory;

        public async Task<T> RestAsync<T>(string url, HttpMethod method, object content = null, List<KeyValuePair<string, string>> headers = null)
        {
            try
            {
                HttpClient client = CreateNewInstanClient();
                var request = new HttpRequestMessage(method, url);

                if (headers != null)
                {
                    foreach (var header in headers)
                        request.Headers.Add(header.Key, header.Value);
                }

                HttpContent httpContent = CreateHttpContent(content);

                request.Content = httpContent;
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

                var responseString = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(responseString);

            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                return default(T);
            }
        }
        public ConsumeExternalService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        private HttpClient CreateNewInstanClient()
        {
            HttpClient client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.CacheControl = CacheControlHeaderValue.Parse("no-cache");
            return client;
        }

        private static HttpContent CreateHttpContent<T>(T content)
        {
            string json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        
    }
}

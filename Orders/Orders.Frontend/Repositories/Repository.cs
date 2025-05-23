using System.Text;
using System.Text.Json;

namespace Orders.Frontend.Repositories
{
    public class Repository : IRepository
    {
        private readonly HttpClient _httpClient;

        private JsonSerializerOptions _jsonDefaultOptions => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public Repository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseWrapper<T>> GetAsync<T>(string url)
        {
            var responseHttp = await _httpClient.GetAsync(url);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await UnserializeAnswer<T>(responseHttp);
                return new HttpResponseWrapper<T>(response, false, responseHttp);
            }

            return new HttpResponseWrapper<T>(default, true, responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model)
        {
            var messageJSON = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(messageJSON, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PostAsync(url, messageContent);
            return new HttpResponseWrapper<object>(null, !responseHttp.IsSuccessStatusCode, responseHttp);
        }

        public async Task<HttpResponseWrapper<TActionResponse>> PostAsync<T, TActionResponse>(string url, T model)
        {
            var messageJSON = JsonSerializer.Serialize(model);
            var messageContent = new StringContent(messageJSON, Encoding.UTF8, "application/json");
            var responseHttp = await _httpClient.PostAsync(url, messageContent);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await UnserializeAnswer<TActionResponse>(responseHttp);
                return new HttpResponseWrapper<TActionResponse>(response, false, responseHttp);
            }
            // Aquí había un '!' que podría causar un NRE si responseHttp no fue exitoso.
            // Debería ser: return new HttpResponseWrapper<TActionResponse>(default, true, responseHttp);
            return new HttpResponseWrapper<TActionResponse>(default, true, responseHttp);
        }

        private async Task<T?> UnserializeAnswer<T>(HttpResponseMessage httpResponseMessage)
        {
            var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, _jsonDefaultOptions);
        }
    }
}
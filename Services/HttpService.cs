using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace CryptlexLicensingApp.Services
{
    public class HttpService : HttpClient
    {
        public HttpService(IConfiguration configuration)
        {
            BaseAddress = new Uri(configuration["HttpBaseUrl"]);
        }

        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        };
        public void SetBearerToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                DefaultRequestHeaders.Authorization = null;             
            }
            else
            {
                DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

#nullable enable
        private async Task<TDeserializedOutput?> SendAsync<TDeserializedOutput>(string path, HttpMethod methodType, object? data = null, bool authorize = true)
        {
            TDeserializedOutput? returnData = default;
            HttpResponseMessage? response = null;
            if (DefaultRequestHeaders.Authorization == null && authorize)
            {
                return returnData;
            }

            if (methodType == HttpMethod.Post)
            {
                var jsonContent = JsonSerializer.Serialize(data, Options);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                response = await PostAsync(path, content);
            }
            else if (methodType == HttpMethod.Get)
            {
                response = await GetAsync(path);
            }
            else if (methodType == HttpMethod.Delete)
            {
                response = await DeleteAsync(path);
            }

            if (response != null && response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(jsonString))
                    returnData = JsonSerializer.Deserialize<TDeserializedOutput>(jsonString, Options);
            }

            return returnData;
        }
        public async Task<TDeserializedOutput?> SendPostAsync<TDeserializedOutput>(string path, object? data = null, bool authorize = true)
        {
            return await SendAsync<TDeserializedOutput>(path, HttpMethod.Post, data, authorize);
        }
        public async Task<TDeserializedOutput?> SendGetAsync<TDeserializedOutput>(string path, bool authorize = true)
        {
            return await SendAsync<TDeserializedOutput>(path, HttpMethod.Get, authorize);
        }
        public async Task<TDeserializedOutput?> SendDeleteAsync<TDeserializedOutput>(string path, bool authorize = true)
        {
            return await SendAsync<TDeserializedOutput>(path, HttpMethod.Delete, authorize);
        }
    }
}

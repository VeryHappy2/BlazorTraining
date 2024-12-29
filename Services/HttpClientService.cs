using BlazorApp2.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace BlazorApp2.Services;

public class HttpClientService : IHttpClientService
{
    private readonly IHttpClientFactory _clientFactory;

    public HttpClientService(
        IHttpClientFactory clientFactory,
        IHttpContextAccessor httpContextAccessor)
    {
        _clientFactory = clientFactory;
    }

    public async Task<TResponse> SendAsync<TResponse, TRequest>(string url, HttpMethod method, TRequest? content)
    {
        var client = _clientFactory.CreateClient();

        var httpMessage = new HttpRequestMessage();
        httpMessage.RequestUri = new Uri(url);
        httpMessage.Method = method;

        if (content != null)
        {
            httpMessage.Content =
                new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
        }

        var result = await client.SendAsync(httpMessage);

        if (result.IsSuccessStatusCode)
        {
            var resultContent = await result.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<TResponse>(resultContent);
            return response!;
        }

        return default(TResponse)!;
    }
}


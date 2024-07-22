namespace Basic.Webapi;

public class HttpService : IHttpService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string> ReadAsync()
    {
        using var httpClient = _httpClientFactory.CreateClient("DummyJSON");
        var response = await httpClient.GetAsync("/products/1");
        if (!(response?.IsSuccessStatusCode ?? false))
        {
            return string.Empty;
        }
        return await response.Content.ReadAsStringAsync();
    }
}

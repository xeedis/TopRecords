using System.Net.Http;
using Newtonsoft.Json;
using TopRecords.WPF.Model;

namespace TopRecords.WPF.Client;

public interface ITopRecordsClient
{
    public Task<Catalog> GetCdCatalog(CancellationToken cancellationToken = default);
}

public class TopRecordsClient : ITopRecordsClient
{
    private readonly HttpClient _httpClient;

    public TopRecordsClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(TopRecordsEndpoints.Url);
    }

    public async Task<Catalog> GetCdCatalog(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("", cancellationToken);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        var catalog = JsonConvert.DeserializeObject<Catalog>(responseBody);

        return catalog;
    }
}
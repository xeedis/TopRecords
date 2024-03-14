using System.Xml.Serialization;
using Microsoft.Extensions.Options;
using TopRecords.Api.DTO;
using TopRecords.Api.Helpers;

namespace TopRecords.Api.Clients;

public interface IW3SchoolClient
{
    public Task<CatalogDto> GetCdCatalog(CancellationToken cancellationToken = default);
}

public sealed class W3SchoolClient : IW3SchoolClient
{
    private readonly HttpClient _httpClient;

    public W3SchoolClient(HttpClient httpClient, IOptions<AppOptions> options)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(options.Value.Url);
    }

    public async Task<CatalogDto> GetCdCatalog(CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(W3SchoolEndpoints.CdCatalog,cancellationToken);
        var xmlString = await response.Content.ReadAsStringAsync(cancellationToken);
        
        var serializer = new XmlSerializer(typeof(CatalogDto));
        using var reader = new StringReader(xmlString);
        var catalogs = serializer.Deserialize(reader) as CatalogDto;

        return catalogs;
    }
}
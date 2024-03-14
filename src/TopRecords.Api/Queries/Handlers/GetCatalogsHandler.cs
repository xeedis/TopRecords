using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Options;
using TopRecords.Api.Abstractions;
using TopRecords.Api.DTO;
using TopRecords.Api.Helpers;

namespace TopRecords.Api.Queries.Handlers;

public class GetCatalogsHandler : IQueryHandler<GetCatalog, CatalogDto>
{
    private readonly IHttpClientFactory _httpClient;
    private readonly string _url;
    
    public GetCatalogsHandler(IHttpClientFactory httpClient, IOptionsSnapshot<AppOptions> options)
    {
        _httpClient = httpClient;
        _url = options.Value.Url;
    }
    public async Task<CatalogDto> HandleAsync(GetCatalog query)
    {
        var client = _httpClient.CreateClient("CatalogClient");
        CatalogDto catalogs;
        
        var response = await client.GetAsync(_url);
        var xmlString = await response.Content.ReadAsStringAsync();
        
        var serializer = new XmlSerializer(typeof(CatalogDto));
        using(var reader = new StringReader(xmlString))
        {
            catalogs = (CatalogDto)serializer.Deserialize(reader);
        }

        return catalogs;
    }
}
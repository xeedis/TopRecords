using TopRecords.Api.Abstractions;
using TopRecords.Api.Clients;
using TopRecords.Api.DTO;

namespace TopRecords.Api.Queries.Handlers;

internal sealed class GetCatalogsHandler : IQueryHandler<GetCatalogQuery, CatalogDto>
{
    private readonly IW3SchoolClient _w3SchoolClient;
    
    public GetCatalogsHandler(IW3SchoolClient w3SchoolClient)
    {
        _w3SchoolClient = w3SchoolClient;
    }
    
    public async Task<CatalogDto> HandleAsync(GetCatalogQuery query, CancellationToken cancellationToken)
    {
        return await _w3SchoolClient.GetCdCatalog(cancellationToken);
    }
}
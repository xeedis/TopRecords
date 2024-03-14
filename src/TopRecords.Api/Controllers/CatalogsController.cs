using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TopRecords.Api.Abstractions;
using TopRecords.Api.DTO;
using TopRecords.Api.Helpers;
using TopRecords.Api.Queries;

namespace TopRecords.Api.Controllers;

[Route("catalogs")]
public class CatalogsController : ControllerBase
{
    private readonly IQueryHandler<GetCatalog, CatalogDto> _getCatalogHandler;

    public CatalogsController(IOptionsSnapshot<AppOptions> options, IQueryHandler<GetCatalog, CatalogDto> getCatalogHandler)
    {
        _getCatalogHandler = getCatalogHandler;
    }

    [HttpGet]
    public async Task<ActionResult<CatalogDto>> GetCatalog([FromQuery] GetCatalog query)
    {
        return Ok(await _getCatalogHandler.HandleAsync(query));
    }
}
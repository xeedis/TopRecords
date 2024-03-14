using Microsoft.AspNetCore.Mvc;
using TopRecords.Api.Abstractions;
using TopRecords.Api.DTO;
using TopRecords.Api.Queries;

namespace TopRecords.Api.Controllers;

[Route("api/[controller]")]
public class CatalogsController : ControllerBase
{
    private readonly IQueryHandler<GetCatalogQuery, CatalogDto> _getCatalogHandler;

    public CatalogsController(IQueryHandler<GetCatalogQuery, CatalogDto> getCatalogHandler)
    {
        _getCatalogHandler = getCatalogHandler;
    }
    
    [HttpGet]
    [Route("Get")]
    public async Task<ActionResult<CatalogDto>> GetCatalog(GetCatalogQuery query)
    {
        return Ok(await _getCatalogHandler.HandleAsync(query));
    }
}
using TopRecords.Api.Abstractions;
using TopRecords.Api.DTO;

namespace TopRecords.Api.Queries;

public sealed record GetCatalogQuery : IQuery<CatalogDto>;

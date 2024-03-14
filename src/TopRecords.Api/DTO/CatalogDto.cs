using System.Xml.Serialization;

namespace TopRecords.Api.DTO;

[XmlRoot("CATALOG")]
public class CatalogDto
{
    [XmlElement("CD")]
    public List<CdDto> Cds { get; init; } = [];
}
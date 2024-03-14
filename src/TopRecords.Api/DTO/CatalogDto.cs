using System.Xml.Serialization;

namespace TopRecords.Api.DTO;
[XmlRoot("CATALOG")]
public class CatalogDto
{
    [XmlElement("CD")]
    public virtual List<CdDto> Cds { get; set; } = new();
}
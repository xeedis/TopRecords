using System.Xml.Serialization;

namespace TopRecords.Api.DTO;

public class CdDto
{
    [XmlElement("TITLE")]
    public string Title { get; init; }
    
    [XmlElement("ARTIST")]
    public string Artist { get; init; }
    
    [XmlElement("COUNTRY")]
    public string Country { get; init; }
    
    [XmlElement("COMPANY")]
    public string Company { get; init; }
    
    [XmlElement("PRICE")]
    public decimal Price { get; init; }
    
    [XmlElement("YEAR")]
    public string Year { get; init; }
}
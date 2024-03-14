using System.Xml.Serialization;

namespace TopRecords.Api.DTO;

public class CdDto
{
    [XmlElement("TITLE")]
    public string Title { get; set; }
    [XmlElement("ARTIST")]
    public string Artist { get; set; }
    [XmlElement("COUNTRY")]
    public string Country { get; set; }
    [XmlElement("COMPANY")]
    public string Company { get; set; }
    [XmlElement("PRICE")]
    public decimal Price { get; set; }
    [XmlElement("YEAR")]
    public string Year { get; set; }
}
namespace MatchesSystem.Common.XmlObjects
{
    using System.Xml.Serialization;

    public class XmlSports
    {
        [XmlElement("Sport")]
        public XmlSport Sport { get; set; }
    }
}

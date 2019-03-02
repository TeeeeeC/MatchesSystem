namespace MatchesSystem.Common.XmlObjects
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class XmlSport
    {
        [XmlAttribute("ID")]
        public int SportID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlElement("Event")]
        public List<XmlEvent> Events { get; set; }
    }
}

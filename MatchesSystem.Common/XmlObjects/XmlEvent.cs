namespace MatchesSystem.Common.XmlObjects
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class XmlEvent
    {
        [XmlAttribute("ID")]
        public int EventID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("IsLive")]
        public bool IsLive { get; set; }

        [XmlAttribute("CategoryID")]
        public int CategoryID { get; set; }

        [XmlElement("Match")]
        public List<XmlMatch> Matches { get; set; }
    }
}

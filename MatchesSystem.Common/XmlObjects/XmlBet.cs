namespace MatchesSystem.Common.XmlObjects
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class XmlBet
    {
        [XmlAttribute("ID")]
        public int BetID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("IsLive")]
        public bool IsLive { get; set; }

        [XmlElement("Odd")]
        public List<XmlOdd> Odds { get; set; }
    }
}

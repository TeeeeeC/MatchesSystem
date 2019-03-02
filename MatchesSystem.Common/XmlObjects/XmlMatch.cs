namespace MatchesSystem.Common.XmlObjects
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class XmlMatch
    {
        [XmlAttribute("ID")]
        public int MatchID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("StartDate")]
        public DateTime StartDate { get; set; }

        [XmlAttribute("MatchType")]
        public string MatchType { get; set; }

        [XmlElement("Bet")]
        public List<XmlBet> Bets { get; set; }
    }
}

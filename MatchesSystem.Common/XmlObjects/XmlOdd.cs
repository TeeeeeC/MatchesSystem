namespace MatchesSystem.Common.XmlObjects
{
    using System.Xml.Serialization;

    public class XmlOdd
    {
        [XmlAttribute("ID")]
        public int OddID { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Value")]
        public decimal Value { get; set; }

        [XmlAttribute("SpecialBetValue")]
        public decimal SpecialBetValue { get; set; }
    }
}

namespace MatchesSystem.Services
{
    using MatchesSystem.Common.XmlObjects;
    using MatchesSystem.Services.Contracts;
    using System;
    using System.IO;
    using System.Net;
    using System.Xml.Serialization;

    public class ExternalDataService : IExternalDataService
    {
        public XmlSport GetExternalData(string url)
        {
            XmlSports xmlSports = null;
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(XmlSports));
                StreamReader reader = new StreamReader(WebRequest.Create(url).GetResponse().GetResponseStream());
                xmlSports = (XmlSports)deserializer.Deserialize(reader);
                reader.Close();
            }
            catch(Exception)
            {
                //log
                return null;
            }

            return xmlSports.Sport;
        }
    }
}

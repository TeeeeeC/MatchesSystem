namespace MatchesSystem.Services.Contracts
{
    using MatchesSystem.Common.XmlObjects;

    public interface IExternalDataService
    {
        XmlSport GetExternalData(string url);
    }
}

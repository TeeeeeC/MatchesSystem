namespace MatchesSystem.Services.Contracts
{
    using MatchesSystem.Services.DTOs;
    using System.Collections.Generic;

    public interface IMatchService
    {
        IList<MatchDTO> GetMatchesInitialStartingInNextDay();

        IList<MatchDTO> GetMatchesLatestDataStartingInNextDay();
    }
}

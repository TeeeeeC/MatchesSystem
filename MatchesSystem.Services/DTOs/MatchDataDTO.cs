namespace MatchesSystem.Services.DTOs
{
    using System.Collections.Generic;

    public class MatchDataDTO
    {
        public IList<MatchDTO> MatchesToAdd { get; set; }

        public IList<MatchDTO> MatchesToUpdate { get; set; }

        public IList<int> MatchesToRemove { get; set; }
    }
}

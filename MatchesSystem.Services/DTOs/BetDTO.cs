namespace MatchesSystem.Services.DTOs
{
    using System.Collections.Generic;

    public class BetDTO
    {
        public int BetID { get; set; }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        public IList<OddDTO> Odds { get; set; }
    }
}

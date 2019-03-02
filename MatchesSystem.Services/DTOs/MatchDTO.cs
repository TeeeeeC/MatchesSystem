namespace MatchesSystem.Services.DTOs
{
    using System;

    public class MatchDTO
    {
        public int MatchID { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string MatchType { get; set; }

        public int OddsCount { get; set; }
    }
}

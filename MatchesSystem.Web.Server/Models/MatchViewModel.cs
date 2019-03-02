namespace MatchesSystem.Web.Server.Models
{
    using System;

    public class MatchViewModel
    {
        public int MatchID { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string MatchType { get; set; }

        public int OddsCount { get; set; }
    }
}
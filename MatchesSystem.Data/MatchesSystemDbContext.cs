namespace MatchesSystem.Data
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using MatchesSystem.Data.Models;

    public class MatchesSystemDbContext : DbContext, IMatchesSystemDbContext
    {
        public MatchesSystemDbContext()
            : base("MatchesSystem")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual IDbSet<Bet> Bets { get; set; }

        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<Match> Matches { get; set; }

        public virtual IDbSet<MatchType> MatchTypes { get; set; }

        public virtual IDbSet<Odd> Odds { get; set; }

        public virtual IDbSet<Sport> Sports { get; set; }
    }
}

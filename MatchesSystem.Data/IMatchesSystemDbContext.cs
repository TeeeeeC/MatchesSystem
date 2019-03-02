namespace MatchesSystem.Data
{
    using MatchesSystem.Data.Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IMatchesSystemDbContext
    {
        int SaveChanges();

        void Dispose();

        IDbSet<Bet> Bets { get; }

        IDbSet<Event> Events { get; }

        IDbSet<Match> Matches { get; }

        IDbSet<MatchType> MatchTypes { get; }

        IDbSet<Odd> Odds { get; }

        IDbSet<Sport> Sports { get; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}

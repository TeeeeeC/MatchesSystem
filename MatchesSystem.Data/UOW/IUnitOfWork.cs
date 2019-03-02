namespace MatchesSystem.Data.UOW
{
    using MatchesSystem.Data.Models;
    using MatchesSystem.Data.Repositories;

    public interface IUnitOfWork
    {
        IRepository<Bet> BetRepository { get; }

        IRepository<Event> EventRepository { get; }

        IRepository<Match> MatchRepository { get; }

        IRepository<MatchType> MatchTypeRepository { get; }

        IRepository<Odd> OddRepository { get; }

        IRepository<Sport> SportRepository { get; }

        void Save();

        void Dispose();

        void BulkSave();
    }
}

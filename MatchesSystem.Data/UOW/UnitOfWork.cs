namespace MatchesSystem.Data.UOW
{
    using MatchesSystem.Data.Models;
    using MatchesSystem.Data.Repositories;
    using System;

    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private bool disposed = false;

        public UnitOfWork(MatchesSystemDbContext context, IRepository<Bet> betRepository, 
            IRepository<Event> eventRepository, IRepository<Match> matchRepository,
            IRepository<MatchType> matchTypeRepository, IRepository<Odd> oddRepository, 
            IRepository<Sport> sportRepository)
        {
            this.Context = context;
            this.BetRepository = betRepository;
            this.EventRepository = eventRepository;
            this.MatchRepository = matchRepository;
            this.MatchTypeRepository = matchTypeRepository;
            this.OddRepository = oddRepository;
            this.SportRepository = sportRepository;
        }

        protected MatchesSystemDbContext Context { get; private set; }

        public IRepository<Bet> BetRepository { get; private set; }

        public IRepository<Event> EventRepository { get; private set; }

        public IRepository<Match> MatchRepository { get; private set; }

        public IRepository<MatchType> MatchTypeRepository { get; private set; }

        public IRepository<Odd> OddRepository { get; private set; }

        public IRepository<Sport> SportRepository { get; private set; }

        public void Save()
        {
            this.Context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void BulkSave()
        {
            this.Context.BulkSaveChanges();
        }
    }
}

namespace MatchesSystem.Services.IoC
{
    using MatchesSystem.Data;
    using MatchesSystem.Data.Repositories;
    using MatchesSystem.Data.UOW;
    using Ninject.Modules;

    public class UnitOfWorkModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMatchesSystemDbContext>().To<MatchesSystemDbContext>().InSingletonScope();
            Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}

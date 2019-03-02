namespace MatchesSystem.Services
{
    using MatchesSystem.Data;
    using MatchesSystem.Data.Migrations;
    using System.Data.Entity;

    public class DbProviderService
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MatchesSystemDbContext, Configuration>());
        }
    }
}

namespace MatchesSystem.Web.Server.BackgroundServices
{
    using MatchesSystem.Services.Contracts;
    using MatchesSystem.Web.Server.Hubs;
    using Microsoft.AspNet.SignalR;
    using System.Threading;
    using System.Web.Hosting;

    public class BackgroundMatchServerTimer : IRegisteredObject
    {
        private const int MATCHES_INITIAL_DELAY_IN_MILISECONDS = 60 * 1000; // 1 min 
        private const int MATCHES_REPEAT_INTERVAL_IN_MILISECONDS = 60 * 1000; // 1 min 

        private readonly IHubContext matchHub;
        private readonly IMatchService matchService;
        private Timer timer;

        public BackgroundMatchServerTimer(IMatchService matchService)
        {
            this.matchService = matchService;
            this.matchHub = GlobalHost.ConnectionManager.GetHubContext<MatchHub>();

            this.StartTimer();
        }
        private void StartTimer()
        {
            this.timer = new Timer(this.BroadcastMatchesToClients, null, 
                MATCHES_INITIAL_DELAY_IN_MILISECONDS, MATCHES_REPEAT_INTERVAL_IN_MILISECONDS);
        }
        private void BroadcastMatchesToClients(object state)
        {
            var matches = this.matchService.GetMatchesLatestDataStartingInNextDay();
            this.matchHub.Clients.All.updateMatches(matches);
        }

        public void Stop(bool immediate)
        {
            this.timer.Dispose();

            HostingEnvironment.UnregisterObject(this);
        }
    }
}
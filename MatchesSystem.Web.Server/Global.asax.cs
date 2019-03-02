namespace MatchesSystem.Web.Server
{
    using MatchesSystem.Services;
    using MatchesSystem.Services.Contracts;
    using MatchesSystem.Services.IoC;
    using MatchesSystem.Web.Server.BackgroundServices;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using System.Web.Hosting;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DbProviderService.Initialize();

            IKernel kernel = new StandardKernel();
            kernel.Load(new UnitOfWorkModule());
            kernel.Bind<IMatchService>().To<MatchService>();
            kernel.Bind<IExternalDataService>().To<ExternalDataService>();
            kernel.Bind<BackgroundMatchServerTimer>().ToSelf();
            var backgroundMatchServerTimer = kernel.Get<BackgroundMatchServerTimer>();

            HostingEnvironment.RegisterObject(backgroundMatchServerTimer);
        }
    }
}

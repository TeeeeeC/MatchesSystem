namespace MatchesSystem.Web.Server.Controllers
{
    using MatchesSystem.Services.Contracts;
    using MatchesSystem.Services.DTOs;
    using MatchesSystem.Web.Server.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private readonly IMatchService matchService;

        public HomeController(IMatchService matchService)
        {
            this.matchService = matchService;
        }

        public ActionResult Index()
        {
            var matchesDTO = this.matchService.GetMatchesInitialStartingInNextDay();
            var matchesViewModel = this.MapToViewModel(matchesDTO);

            return View(matchesViewModel);
        }

        private IEnumerable<MatchViewModel> MapToViewModel(IList<MatchDTO> matchesDTO)
        {
            return matchesDTO.Select(m => new MatchViewModel()
            {
                MatchID = m.MatchID,
                MatchType = m.MatchType,
                Name = m.Name,
                StartDate = m.StartDate,
                OddsCount = m.OddsCount
            }).ToList();
        }
    }
}

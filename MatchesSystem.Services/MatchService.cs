namespace MatchesSystem.Services
{
    using MatchesSystem.Common;
    using MatchesSystem.Common.XmlObjects;
    using MatchesSystem.Data.Models;
    using MatchesSystem.Data.UOW;
    using MatchesSystem.Services.Contracts;
    using MatchesSystem.Services.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MatchService : IMatchService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IExternalDataService externalDataService;

        public MatchService(IUnitOfWork unitOfWork, IExternalDataService externalDataService)
        {
            this.unitOfWork = unitOfWork;
            this.externalDataService = externalDataService;
        }

        public IList<MatchDTO> GetMatchesInitialStartingInNextDay()
        {
            this.InitialSeed();

            var dateTimeAfterTwentyFourHours = DateTime.UtcNow.AddDays(1);
            var matches = this.unitOfWork.MatchRepository.All()
                .Where(m => m.StartDate > DateTime.UtcNow
                 && m.StartDate < dateTimeAfterTwentyFourHours
                 && m.Bets.Count > 0)
                .Select(m => new MatchDTO()
                {
                    MatchID = m.MatchID,
                    MatchType = m.MatchType.Name,
                    Name = m.Name,
                    StartDate = m.StartDate,
                    OddsCount = m.Bets.Sum(b => b.Odds.Count)
                })
                .ToList();


            return matches;
        }

        public IList<MatchDTO> GetMatchesLatestDataStartingInNextDay()
        {
            var xmlSport = this.externalDataService.GetExternalData(ExternalApiConstants.URL);
            this.AddOrUpdateData(xmlSport);

            var matches = this.GetMatchesInitialStartingInNextDay();

            return matches;
        }

        private void InitialSeed()
        {
            if(this.unitOfWork.SportRepository.All().Any() == false)
            {
                var xmlSport = this.externalDataService.GetExternalData(ExternalApiConstants.URL);
                this.AddOrUpdateData(xmlSport);
            }
        }

        private void AddOrUpdateData(XmlSport xmlSport)
        {
            var sports = new List<Sport>()
            {
                new Sport
                {
                    SportID = xmlSport.SportID,
                    Name = xmlSport.Name
                }
            };
            this.unitOfWork.SportRepository.BulkMerge(sports);

            var events = xmlSport.Events.Select(e => new Event()
            {
                CategoryID = e.CategoryID,
                EventID = e.EventID,
                IsLive = e.IsLive,
                Name = e.Name,
                SportID = xmlSport.SportID
            });
            this.unitOfWork.EventRepository.BulkMerge(events);

            var matchTypes = this.unitOfWork.MatchTypeRepository.All().ToDictionary(k => k.Name, v => v.MatchTypeID);
            var matches = new List<Match>();
            foreach (var eventItem in xmlSport.Events)
            {
                foreach (var match in eventItem.Matches)
                {
                    int matchTypeID = 0;
                    if (matchTypes.ContainsKey(match.MatchType))
                    {
                        matchTypeID = matchTypes[match.MatchType];
                    }
                    else
                    {
                        var matchType = new MatchType()
                        {
                            Name = match.MatchType
                        };

                        this.unitOfWork.MatchTypeRepository.Add(matchType);
                        this.unitOfWork.MatchTypeRepository.SaveChanges();
                        matchTypes.Add(match.MatchType, matchType.MatchTypeID);
                        matchTypeID = matchType.MatchTypeID;
                    }

                    matches.Add(new Match()
                    {
                        MatchID = match.MatchID,
                        Name = match.Name,
                        MatchTypeID = matchTypeID,
                        StartDate = match.StartDate,
                        EventID = eventItem.EventID
                    });
                }
            }
            this.unitOfWork.MatchRepository.BulkMerge(matches);

            var xmlMatches = xmlSport.Events.SelectMany(e => e.Matches);
            var bets = new List<Bet>();
            foreach (var match in xmlMatches)
            {
                bets.AddRange(match.Bets.Select(b => new Bet()
                {
                    BetID = b.BetID,
                    Name = b.Name,
                    IsLive = b.IsLive,
                    MatchID = match.MatchID
                }));
            }
            this.unitOfWork.BetRepository.BulkMerge(bets);

            var odds = new List<Odd>();
            foreach (var bet in xmlMatches.SelectMany(m => m.Bets))
            {
                odds.AddRange(bet.Odds.Select(o => new Odd()
                {
                    BetID = bet.BetID,
                    OddID = o.OddID,
                    Name = o.Name,
                    Value = o.Value,
                    SpecialBetValue = o.SpecialBetValue
                }));
            }
            this.unitOfWork.OddRepository.BulkMerge(odds);

            this.unitOfWork.BulkSave();
        }
    }
}

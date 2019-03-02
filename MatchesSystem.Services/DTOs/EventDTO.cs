namespace MatchesSystem.Services.DTOs
{
    using System.Collections.Generic;

    public class EventDTO
    {
        public int EventID { get; set; }

        public string Name { get; set; }

        public bool IsLive { get; set; }

        public int CategoryID { get; set; }

        public IList<MatchDTO> Matches { get; set; }
    }
}

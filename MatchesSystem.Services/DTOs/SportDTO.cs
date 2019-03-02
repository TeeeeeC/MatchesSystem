namespace MatchesSystem.Services.DTOs
{
    using System.Collections.Generic;

    public class SportDTO
    {
        public int SportID { get; set; }

        public string Name { get; set; }

        public List<EventDTO> Events { get; set; }
    }
}

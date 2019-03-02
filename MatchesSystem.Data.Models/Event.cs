 namespace MatchesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Event
    {
        private ICollection<Match> matches;

        public Event()
        {
            this.matches = new HashSet<Match>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool IsLive { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public int SportID { get; set; }

        public virtual Sport Sport { get; set; }

        public virtual ICollection<Match> Matches
        {
            get
            {
                return this.matches;
            }
            set
            {
                this.matches = value;
            }
        }
    }
}

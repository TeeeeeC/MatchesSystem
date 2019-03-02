namespace MatchesSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Match
    {
        private ICollection<Bet> bets;

        public Match()
        {
            this.bets = new HashSet<Bet>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MatchID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public int MatchTypeID { get; set; }

        public virtual MatchType MatchType { get; set; }

        public int EventID { get; set; }

        public virtual Event Event { get; set; }

        public virtual ICollection<Bet> Bets
        {
            get
            {
                return this.bets;
            }
            set
            {
                this.bets = value;
            }
        }
    }
}

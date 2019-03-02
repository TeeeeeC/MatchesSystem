namespace MatchesSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Odd
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OddID { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Value { get; set; }

        public decimal SpecialBetValue { get; set; }

        public int BetID { get; set; }

        public virtual Bet Bet { get; set; }
    }
}

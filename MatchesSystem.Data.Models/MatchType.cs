namespace MatchesSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MatchType
    {
        [Key]
        public int MatchTypeID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

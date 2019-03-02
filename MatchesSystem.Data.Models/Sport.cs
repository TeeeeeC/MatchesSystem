﻿namespace MatchesSystem.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sport
    {
        private ICollection<Event> events;

        public Sport()
        {
            this.events = new HashSet<Event>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SportID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Event> Events
        {
            get
            {
                return this.events;
            }
            set
            {
                this.events = value;
            }
        }
    }
}

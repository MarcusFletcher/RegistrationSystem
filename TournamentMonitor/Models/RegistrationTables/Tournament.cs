using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TournamentMonitor.Models.RegistrationTables
{
    public class Tournament
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TournamentID { get; set; }

        public Event Event { get; set; }
        public long EventID { get; set; }
        public Organiser Organiser { get; set; }
        public Venue Venue { get; set; }
        public Product Product { get; set; }
        public TournamentType TournamentType { get; set; }
        public Format Format { get; set; }
        public string TournamentName { get; set; }
        public string Description { get; set; }
        public int SanctionID { get; set; }
        public bool RegistrationRequired { get; set; }

        [JsonIgnore]
        public virtual ICollection<DivisionDetail> DivisionDetails { get; set; }
        public virtual ICollection<TournamentRegistration> TournamentRegistrations { get; set; }

    }
}

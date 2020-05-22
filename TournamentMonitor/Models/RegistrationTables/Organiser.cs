using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TournamentMonitor.Models.RegistrationTables
{
    public class Organiser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrganiserID { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Website { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }

        [JsonIgnore]
        public virtual ICollection<Tournament> Tournaments { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TournamentMonitor.Models.RegistrationTables
{
    public class RegistrationStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long StatusID { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<TournamentRegistration> TournamentRegistrations { get; set; }
    }
}

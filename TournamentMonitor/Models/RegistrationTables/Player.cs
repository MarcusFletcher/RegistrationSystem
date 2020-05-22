using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TournamentMonitor.Models.RegistrationTables
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PlayerID { get; set; }
        public int PID { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string Password3 { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public virtual ICollection<TournamentRegistration> TournamentRegistrations { get; set; }

    }
}

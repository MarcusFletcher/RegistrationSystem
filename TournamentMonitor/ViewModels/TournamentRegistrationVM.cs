using System;
using System.Collections.Generic;
using TournamentMonitor.Models;
using TournamentMonitor.Models.RegistrationTables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace TournamentMonitor.ViewModels
{
    public class TournamentRegistrationVM
    {
        public long TournamentID { get; set; }
        public Tournament Tournament { get; set; }
        public long PlayerID { get; set; }
        public Player Player { get; set; }
        public RegistrationStatus RegistrationStatus { get; set; }

        [Column(TypeName = "money")]
        public float PaidAmount { get; set; }

        public string Division { get; set; }
    }
}

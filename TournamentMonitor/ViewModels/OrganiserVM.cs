using System;
using System.Collections.Generic;
using TournamentMonitor.Models;
using TournamentMonitor.Models.RegistrationTables;

namespace TournamentMonitor.ViewModels
{
    public class OrganiserVM
    {
        public long OrganiserID { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Website { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
    }
}

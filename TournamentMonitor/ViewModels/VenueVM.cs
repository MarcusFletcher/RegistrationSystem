using System;
using System.Collections.Generic;
using TournamentMonitor.Models;
using TournamentMonitor.Models.RegistrationTables;

namespace TournamentMonitor.ViewModels
{
    public class VenueVM
    {
        public long VenueID { get; set; }
        public Country Country { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
    }
}

using System;
using TournamentMonitor.Models;

namespace TournamentMonitor.ViewModels
{
    public class EventVM
    {
        public long EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Banner { get; set; }
        public string Country { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OrganiserID { get; set; }
    }
}

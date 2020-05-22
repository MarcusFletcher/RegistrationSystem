using System;
namespace TournamentMonitor.ViewModels
{
    public class PlayerVM
    {
        public long PlayerID { get; set; }
        public int PID { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string Password3 { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
    }
}

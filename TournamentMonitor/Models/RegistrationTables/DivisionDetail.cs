using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TournamentMonitor.Models.RegistrationTables
{
    public class DivisionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DivisionID { get; set; }
        public Tournament Tournament { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int TotalRegistered { get; set; }
        [Column(TypeName = "money")]
        public float EntryCost { get; set; }
        public DateTime StartDateTime { get; set; }
        public int SwissMatchPoints { get; set; }
        public TimeSpan SwissRoundTime { get; set; }
        public int EliminationMatchPoints { get; set; }
        public TimeSpan EliminationRoundTime { get; set; }
        public DateTime RegistrationOpen { get; set; }
        public DateTime RegistrationClosed { get; set; }
    }
}

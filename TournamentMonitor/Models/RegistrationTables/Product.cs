using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TournamentMonitor.Models.RegistrationTables
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Tournament> Tournaments { get; set; }
    }
}

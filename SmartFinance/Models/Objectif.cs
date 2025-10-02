using SmartFinance.Models.SmartFinance.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartFinance.Models
{
    public class Objectif
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontantCible { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontantActuel { get; set; }
        public DateTime DateCible { get; set; }
        public int CompteId { get; set; }
        public string UserId { get; set; }
        public Compte Compte { get; set; }
        public User User { get; set; }
    }
}

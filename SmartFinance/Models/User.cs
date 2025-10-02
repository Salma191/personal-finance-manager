using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace SmartFinance.Models
{
    
        public class User : IdentityUser
        {
            [Required]
            [StringLength(50)]
            public string Prenom { get; set; }
            [Required]
            [StringLength(50)]
            public string Nom { get; set; }
            public DateTime DateInscription { get; set; } = DateTime.Now;

            // Navigation properties
            public ICollection<Compte> Comptes { get; set; }
            public ICollection<Categorie> Categories { get; set; }
            public ICollection<Budget> Budgets { get; set; }
            public ICollection<Objectif> Objectifs { get; set; }
            public ICollection<Transaction> Transactions { get; set; }
    }
}

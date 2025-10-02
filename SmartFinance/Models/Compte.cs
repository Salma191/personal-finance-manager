using System.ComponentModel.DataAnnotations.Schema;

namespace SmartFinance.Models
{
    public class Compte
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Institution { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Solde { get; set; }
        public TypeCompte TypeCompte { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Objectif> Objectifs { get; set; }
    }

    public enum TypeCompte
    {
        Chèque,
        Épargne,
        Crédit
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace SmartFinance.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Montant { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TypeTransaction Type { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
        public int CompteId { get; set; }
        public string UserId { get; set; }
        public Compte Compte { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool isDeleted { get; set; }
    }

    public enum TypeTransaction
    {
        Depense,
        Revenu,
        Transfert
    }
}

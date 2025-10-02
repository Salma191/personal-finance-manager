using System.ComponentModel.DataAnnotations.Schema;

namespace SmartFinance.Models
{
    public class Budget
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MontantAlloue { get; set; }
        public DateTime MoisAnnee { get; set; }
        public int CategorieId { get; set; }
        public string UserId { get; set; }
        public Categorie Categorie { get; set; }
        public User User { get; set; }
    }
}

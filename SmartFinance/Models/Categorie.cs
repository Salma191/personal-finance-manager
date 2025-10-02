using SmartFinance.Models.SmartFinance.Models;

namespace SmartFinance.Models
{

    public class Categorie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public bool EstEssentielle { get; set; }
        public bool AUnPlafond { get; set; }
        public string UserId { get; set; }
        public int? ParentId { get; set; }
        public User User { get; set; }
        public Categorie Parent { get; set; }
        public ICollection<Categorie> SousCategories { get; set; }
        public ICollection<Budget> Budgets { get; set; }
    }
}

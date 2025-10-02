using SmartFinance.Models;

namespace SmartFinance.Service.Interfaces
{
    public interface ICategorieService
    {
        public Task<List<Categorie>> GetCategoriesAsync();
        public Task<Categorie> GetCategorieAsync(int id);
        public Task AddCategorieAsync(Categorie categorie);
        public Task UpdateCategorieAsync(Categorie categorie);
        public Task DeleteCategorieAsync(int id);
        public Task<List<Categorie>> GetSousCategoriesAsync(int parentId);
    }
}

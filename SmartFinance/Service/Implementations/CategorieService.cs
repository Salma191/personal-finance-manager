using Microsoft.EntityFrameworkCore;
using SmartFinance.Data;
using SmartFinance.Models;
using SmartFinance.Service.Interfaces;

namespace SmartFinance.Service.Implementations
{
    public class CategorieService : ICategorieService
    {
        private readonly AppDbContext _context;
        public CategorieService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categorie>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Categorie> GetCategorieAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task AddCategorieAsync(Categorie categorie)
        {
            _context.Categories.Add(categorie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategorieAsync(Categorie categorie)
        {
            var existingCategorie = await _context.Categories.FindAsync(categorie.Id);
            if (existingCategorie == null) throw new Exception("Categorie not found");

            existingCategorie.Nom = categorie.Nom;
            existingCategorie.Description = categorie.Description;
            existingCategorie.EstEssetielle = categorie.EstEssetielle;
            existingCategorie.AUnPlafond = categorie.AUnPlafond;
            existingCategorie.ParentId = categorie.ParentId;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategorieAsync(int id)
        {
            var categorie = await _context.Categories.FindAsync(id);
            if (categorie != null)
            {
                _context.Categories.Remove(categorie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Categorie>> GetSousCategoriesAsync(int parentId)
        {
            return await _context.Categories
                .Where(c => c.ParentId == parentId)
                .ToListAsync();
        }

    }
}

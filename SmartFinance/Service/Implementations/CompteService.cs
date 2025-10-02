using Microsoft.EntityFrameworkCore;
using SmartFinance.Data;
using SmartFinance.Models;
using SmartFinance.Service.Interfaces;

namespace SmartFinance.Service.Implementations
{
    public class CompteService : ICompteService
    {
        private readonly AppDbContext _context;
        public CompteService(AppDbContext context) {
            _context = context;
        }

        public async Task<List<Compte>> GetComptesAsync()
        {
            return await _context.Comptes.ToListAsync();
        }

        public async Task<Compte> GetCompteAsync(int Id)
        {
            var compte = await _context.Comptes.FindAsync(Id);
            if (compte == null) new Exception("Ce compte n'existe pas");
            return compte;
        }

        public async Task AddCompteAsync(Compte compte)
        {
            _context.Comptes.Add(compte);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompteAsync(Compte compte)
        {
            var existingCompte = await _context.Comptes.FindAsync(compte.Id);
            if (existingCompte == null) new Exception("Ce compte n'existe pas");
            existingCompte.Nom = compte.Nom;
            existingCompte.Solde = compte.Solde;
            existingCompte.Institution = compte.Institution;
            existingCompte.TypeCompte = compte.TypeCompte;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompteAsync(int id)
        {
            var compte = await _context.Comptes.FindAsync(id);
            if (compte == null) new Exception("Ce compte n'existe pas");
            _context.Comptes.Remove(compte);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> CalculerSoldeGlobal()
        {
            return await _context.Comptes.SumAsync(c => c.Solde);
        }
    }
}

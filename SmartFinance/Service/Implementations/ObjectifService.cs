using SmartFinance.Data;
using SmartFinance.Service.Interfaces;
using SmartFinance.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartFinance.Service.Implementations
{
    public class ObjectifService : IObjectifService
    {
        private readonly AppDbContext _context;
        public ObjectifService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Objectif>> GetAllObjectifs()
        {
            return await _context.Objectifs.ToListAsync();
        }

        public async Task<Objectif> GetObjectifById(int id)
        {
            var objectif = await _context.Objectifs.FindAsync(id);
            if (objectif == null) {
                throw new Exception("Objectif not found");
            }
            return objectif;
        }

        public async Task CreateObjectif(Objectif objectif)
        {
            _context.Objectifs.Add(objectif);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateObjectif(Objectif objectif)
        {
            var existObjectif = await _context.Objectifs.FirstOrDefaultAsync(o => o.Id == objectif.Id);
            if (existObjectif == null)
            {
                throw new Exception("Objectif not found");
            }
            existObjectif.Nom = objectif.Nom;
            existObjectif.Description = objectif.Description;
            existObjectif.MontantCible = objectif.MontantCible;
            existObjectif.DateCible = objectif.DateCible;
            existObjectif.MontantActuel = objectif.MontantActuel;
            existObjectif.CompteId = objectif.CompteId;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteObjectif(int id)
        {
            var objectif = await _context.Objectifs.FindAsync(id);
            if (objectif == null)
            {
                throw new Exception("Objectif not found");
            }
            _context.Objectifs.Remove(objectif);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Objectif>> GetObjectifsByCompteId(int compteId)
        {
            return await _context.Objectifs.Where(o => o.CompteId == compteId).ToListAsync();
        }

        public async Task<decimal> CalculProgression(int objectifId)
        {
            var objectif = await _context.Objectifs.FindAsync(objectifId);
            if (objectif == null)
            {
                throw new Exception("Objectif not found");
            }
            if (objectif.MontantCible == 0) return 0;
            return (objectif.MontantActuel / objectif.MontantCible) * 100;
        }
    }
}

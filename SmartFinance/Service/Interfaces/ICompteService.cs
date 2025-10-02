using SmartFinance.Models;

namespace SmartFinance.Service.Interfaces
{
    public interface ICompteService
    {
        public Task<List<Compte>> GetComptesAsync();
        public Task<Compte> GetCompteAsync(int id);
        public Task AddCompteAsync(Compte compte);
        public Task UpdateCompteAsync(Compte compte);
        public Task DeleteCompteAsync(int id);
        public Task<decimal> CalculerSoldeGlobal();
    }
}

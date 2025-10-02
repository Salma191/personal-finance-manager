using SmartFinance.Models;

namespace SmartFinance.Service.Interfaces
{
    public interface IObjectifService
    {
        public Task CreateObjectif(Objectif objectif);
        public Task<Objectif> GetObjectifById(int id);
        public Task<IEnumerable<Objectif>> GetAllObjectifs();
        public Task UpdateObjectif(Objectif objectif);
        public Task DeleteObjectif(int id);
        public Task<IEnumerable<Objectif>> GetObjectifsByCompteId(int compteId);
        public Task<decimal> CalculProgression(int objectifId);

    }
}

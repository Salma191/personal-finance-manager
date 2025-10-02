using SmartFinance.Models;

namespace SmartFinance.Service.Interfaces
{
    public interface ITransactionService
    {
        public Task<List<Transaction>> GetTransactionsAsync();
        public Task<Transaction> GetTransactionAsync(int id);
        public Task AddTransaction(Transaction transaction);
        public Task UpdateTransaction(Transaction transaction);
        public Task DeleteTransaction(int id);
        public Task<List<Transaction>> GetTransactionsByCompte(int compteId);
        public Task<List<Transaction>> GetTransactionsByCategorie(int categorieId, DateTime startDate, DateTime endDate);
        public Task<decimal> CalculeDepensesParCategorie(int categorieId, DateTime startDate, DateTime endDate);
    }
}

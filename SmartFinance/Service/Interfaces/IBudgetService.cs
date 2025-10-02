using SmartFinance.Models;

namespace SmartFinance.Service.Interfaces
{
    public interface IBudgetService
    {
        public Task<List<Budget>> GetBudgets();
        public Task<Budget> GetBudget(int budgetId);
        public Task DefineBudget(Budget budget);
        public Task UpdateBudget(Budget budget);
        public Task DeleteBudget(int budgetId);
        public Task<Budget> GetBudgetByCategorieAndMonth(int categorieId, DateTime month);
        public Task<decimal> GetDepenseVsBudget(int categorieId, DateTime month);
    }
}

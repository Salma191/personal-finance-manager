using SmartFinance.Data;
using SmartFinance.Service.Interfaces;
using SmartFinance.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartFinance.Service.Implementations
{
    public class BudgetService : IBudgetService
    {
        private readonly AppDbContext _context;
        public BudgetService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Budget>> GetBudgets()
        {
            return await _context.Budgets.ToListAsync();
        }

        public async Task<Budget> GetBudget(int budgetId)
        {
            var Budget = await _context.Budgets.FindAsync(budgetId);
            if (Budget == null)
            {
                throw new Exception("Budget not found");
            }
            return Budget;
        }

        public async Task DefineBudget(Budget budget)
        {
            _context.Budgets.Add(budget);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBudget(Budget budget)
        {
            var existBudget = await _context.Budgets.FirstOrDefaultAsync(b => b.Id == budget.Id);
            if (existBudget == null)
            {
                throw new Exception("Budget not found");
            }
            existBudget.MontantAlloue = budget.MontantAlloue;
            existBudget.MoisAnnee = budget.MoisAnnee;
            existBudget.CategorieId = budget.CategorieId;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBudget(int budgetId)
        {
            var budget = await _context.Budgets.FindAsync(budgetId);
            if (budget == null)
            { throw new Exception("Budget not found"); }
            _context.Budgets.Remove(budget);
            await _context.SaveChangesAsync();
        }

        public async Task<Budget> GetBudgetByCategorieAndMonth(int categorieId, DateTime month)
        {
            var budget = await _context.Budgets
                .FirstOrDefaultAsync(b => b.CategorieId == categorieId && b.MoisAnnee.Month == month.Month && b.MoisAnnee.Year == month.Year);
            if (budget == null)
            {
                throw new Exception("Budget not found for the specified category and month");
            }
            return budget;
        }

        public async Task<decimal> GetDepenseVsBudget(int categorieId, DateTime month)
        {
            var budget = await GetBudgetByCategorieAndMonth(categorieId, month);
            var transactions = await _context.Transactions
                .Where(tr => tr.CategorieId == categorieId && tr.Date.Month == month.Month && tr.Date.Year == month.Year && tr.Type == TypeTransaction.Depense)
                .SumAsync(tr => tr.Montant);

            return budget.MontantAlloue - transactions;

        }
    }
}
using Microsoft.EntityFrameworkCore;
using SmartFinance.Data;
using SmartFinance.Models;
using SmartFinance.Service.Interfaces;

namespace SmartFinance.Service.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;
        public TransactionService(AppDbContext context) {
            _context = context;
        }

        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            return await _context.Transactions
                .Include(t => t.Categorie)
                .Include(t => t.Compte)
                .OrderByDescending(t => t.Date)
                .Where(t => !t.isDeleted)
                .ToListAsync();
        }

        public async Task<Transaction> GetTransactionAsync(int id)
        {
            var trans =  await _context.Transactions
                .Include(t => t.Categorie)
                .Include(t => t.Compte)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (trans.isDeleted) return null;
            return trans;
        }

        public async Task AddTransaction(Transaction transaction)
        {
            var compte = await _context.Comptes.FindAsync(transaction.CompteId);
            if (compte == null) return;
            var categori = await _context.Categories.FindAsync(transaction.CategorieId);
            if (transaction.Type == TypeTransaction.Revenu)
            {
                compte.Solde += transaction.Montant;
            }
            else if (transaction.Type == TypeTransaction.Depense)
            {
                compte.Solde -= transaction.Montant;
            }
            transaction.CreatedAt = DateTime.Now;
            transaction.UpdatedAt = DateTime.Now;
            transaction.isDeleted = false;

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTransaction(Transaction transaction)
        {
            var existingTransaction = await _context.Transactions.FirstOrDefaultAsync(t => t.Id == transaction.Id);
            if (existingTransaction == null || existingTransaction.isDeleted) return;
            var compte = await _context.Comptes.FindAsync(transaction.CompteId);
            if (compte == null) return;
            if (existingTransaction.Type == TypeTransaction.Revenu)
            {
                compte.Solde -= existingTransaction.Montant;
            }
            else if (existingTransaction.Type == TypeTransaction.Depense)
            {
                compte.Solde += existingTransaction.Montant;
            }
            if (transaction.Type == TypeTransaction.Revenu)
            {
                compte.Solde += transaction.Montant;
            }
            else if (transaction.Type == TypeTransaction.Depense)
            {
                compte.Solde -= transaction.Montant;
            }
            
            existingTransaction.Montant = transaction.Montant;
            existingTransaction.Date = transaction.Date;
            existingTransaction.Description = transaction.Description;
            existingTransaction.Type = transaction.Type;
            existingTransaction.CategorieId = transaction.CategorieId;
            existingTransaction.CompteId = transaction.CompteId;
            existingTransaction.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransaction(int id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null || transaction.isDeleted) return;
            var compte = await _context.Comptes.FindAsync(transaction.CompteId);
            if (compte == null) return;
            if (transaction.Type == TypeTransaction.Revenu)
            {
                compte.Solde -= transaction.Montant;
            }
            else if (transaction.Type == TypeTransaction.Depense)
            {
                compte.Solde += transaction.Montant;
            }
            
            transaction.isDeleted = true;
            transaction.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Transaction>> GetTransactionsByCompte(int compteId)
        {
            return await _context.Transactions
                .Include(t => t.Categorie)
                .Include(t => t.Compte)
                .Where(t => t.CompteId == compteId && !t.isDeleted)
                .OrderByDescending(t => t.Date)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetTransactionsByCategorie(int categorieId, DateTime startDate, DateTime endDate)
        {
            return await _context.Transactions
                .Include(t => t.Categorie)
                .Include(t => t.Compte)
                .Where(t => t.CategorieId == categorieId 
                && !t.isDeleted
                && t.Date >= startDate
                && t.Date <= endDate)
                .OrderByDescending(t => t.Date)
                .ToListAsync();
        }

        public async Task<decimal> CalculeDepensesParCategorie(int categorieId, DateTime startDate, DateTime endDate)
        {
            return await _context.Transactions.Where(t => t.CategorieId == categorieId
                && t.Type == TypeTransaction.Depense
                && !t.isDeleted
                && t.Date >= startDate
                && t.Date <= endDate)
                .SumAsync(t => t.Montant);
        }

        }
}

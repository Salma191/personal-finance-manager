using Microsoft.EntityFrameworkCore;
using SmartFinance.Models;
namespace SmartFinance.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Objectif> Objectifs { get; set; }

    }
}

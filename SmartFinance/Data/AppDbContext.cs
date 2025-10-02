using Microsoft.EntityFrameworkCore;
using SmartFinance.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace SmartFinance.Data
{
    public class AppDbContext : IdentityDbContext<User>

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Objectif> Objectifs { get; set; }

            protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configuration des relations User - TOUTES en Restrict sauf Compte
            builder.Entity<Compte>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comptes)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Garder Cascade seulement pour Compte

            builder.Entity<Categorie>()
                .HasOne(c => c.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict); // ← Changer en Restrict

            builder.Entity<Budget>()
                .HasOne(b => b.User)
                .WithMany(u => u.Budgets)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict); // ← Changer en Restrict

            builder.Entity<Objectif>()
                .HasOne(o => o.User)
                .WithMany(u => u.Objectifs)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict); // ← Changer en Restrict

            // Relations entre entités métier
            builder.Entity<Transaction>()
                .HasOne(t => t.Compte)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CompteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Budget>()
                .HasOne(b => b.Categorie)
                .WithMany(c => c.Budgets)
                .HasForeignKey(b => b.CategorieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Objectif>()
                .HasOne(o => o.Compte)
                .WithMany(c => c.Objectifs)
                .HasForeignKey(o => o.CompteId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relation catégorie parent/enfant
            builder.Entity<Categorie>()
                .HasOne(c => c.Parent)
                .WithMany(c => c.SousCategories)
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
    }
    }


}

using Microsoft.EntityFrameworkCore;
using RazorApp.Models;

namespace RazorApp.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public DbSet<Food> Foods { get; set;}
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<DrinkCategory> DrinkCategories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyHQ> CompanyHQs { get; set; }
        public DbSet<DrinkAssignment> DrinkAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().ToTable("Food");
            modelBuilder.Entity<Menu>().ToTable("Menu");
            modelBuilder.Entity<Drink>().ToTable("Drink");
            modelBuilder.Entity<DrinkCategory>().ToTable("DrinkCategory");
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<CompanyHQ>().ToTable("CompanyHQ");
            modelBuilder.Entity<DrinkAssignment>().ToTable("DrinkAssignment");

            modelBuilder.Entity<DrinkAssignment>()
                .HasKey(d => new { d.DrinkID, d.CompanyID });
        }
    }
}

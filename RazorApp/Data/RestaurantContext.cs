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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().ToTable("Food");
            modelBuilder.Entity<Menu>().ToTable("Menu");
            modelBuilder.Entity<Drink>().ToTable("Drink");
        }
    }
}

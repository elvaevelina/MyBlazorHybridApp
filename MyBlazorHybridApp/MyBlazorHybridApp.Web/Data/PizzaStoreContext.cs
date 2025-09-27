using BlazingPizza;
using Microsoft.EntityFrameworkCore;
using MyBlazorHybridApp.Shared.Models;

namespace MyBlazorHybridApp.Web.Data
{
    public class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options) : base(options) { }

        public DbSet<PizzaSpecial> Specials { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<PizzaTopping> PizzaToppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key untuk PizzaTopping
            modelBuilder.Entity<PizzaTopping>()
                .HasKey(pt => new { pt.PizzaId, pt.ToppingId });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using shoppingcart.Models;
using System.Collections.Generic;

namespace ShoppingCart.Data
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
           : base(options)
        { }
        public DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new shoppingcart.Models.Category { CategoryId = 1, Name = "Comedy", DisplayOrder = 1 },
                new shoppingcart.Models.Category { CategoryId = 2, Name = "Action", DisplayOrder = 2 },
                new shoppingcart.Models.Category { CategoryId = 3, Name = "Fiction", DisplayOrder = 3 });

        }
    }
}

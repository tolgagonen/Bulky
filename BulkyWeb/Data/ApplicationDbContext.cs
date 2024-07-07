using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public  DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name= "Action", DisplayOrder=1},
                    new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "History", DisplayOrder = 3 }

                    );

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Title = "The Eye of the World",
                   Author = "Robert Jordan",
                   Description = "The Eye of the World is a high fantasy novel by American writer Robert Jordan, the first book of The Wheel of Time series.",
                   ISBN = "SW9999001",
                   ListPrice = 210,
                   Price50 = 160,
                   Price100 = 135,
                   CategoryId = 1,
                   ImageUrl=""
               },
               new Product
               {
                   Id = 2,
                   Title = "The Great Hunt",
                   Author = "Robert Jordan",
                   Description = "The Great Hunt is a fantasy novel by American author Robert Jordan, the second book of The Wheel of Time series.",
                   ISBN = "SW9999002",
                   ListPrice = 250,
                   Price50 = 185,
                   Price100 = 150,
                   CategoryId = 2,
                   ImageUrl = ""

               },
               new Product
               {
                   Id = 3,
                   Title = "The Dragon Reborn",
                   Author = "Robert Jordan",
                   Description = "The Dragon Reborn is a fantasy novel by American writer Robert Jordan, the third in his series The Wheel of Time.",
                   ISBN = "SW9999003",
                   ListPrice = 230,
                   Price50 = 170,
                   Price100 = 145,
                   CategoryId = 1,
                   ImageUrl = ""

               }


               );
        }
    }
}

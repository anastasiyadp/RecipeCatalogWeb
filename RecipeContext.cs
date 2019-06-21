using System;
using System.Collections.Generic;
using System.Data.Entity;
using RecipeCatalogWeb.Models;

namespace RecipeCatalogWeb
{
    public class RecipeContext: DbContext
    {
        public RecipeContext(): base("RecipeContext") {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>().HasMany(c => c.recipes)
        //        .WithMany(s => s.products)
        //        .Map(t => t.MapLeftKey("productID")
        //        .MapRightKey("recipeID")
        //        .ToTable("Ingredients"));
        //}
    }
}
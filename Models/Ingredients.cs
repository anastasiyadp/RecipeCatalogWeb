using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RecipeCatalogWeb.Models
{
    public class Ingredient
    {
        [Key, ForeignKey("Recipe")]
        [Column(Order = 0)]
        public int RecipeId { get; set; }

        [Key, ForeignKey("Product")]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        //ссылка на продукт
        public Product Product { get; set;}
        //ссылка на рецепт
        public Recipe Recipe { get; set; }
    }
}
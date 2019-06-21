using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeCatalogWeb.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Instruction { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //ссылка на продукты
        public virtual List<Product> Products { get; set; }
    }
}
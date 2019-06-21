using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeCatalogWeb.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string UnitMeasure { get; set; }

        // список рецептов, которые содержат данный рецепт
        public List<Recipe> Recipes { get; set; }
    }
}
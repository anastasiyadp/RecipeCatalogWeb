﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeCatalogWeb.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual List<Recipe> Recipes { get; set; }
    }
}
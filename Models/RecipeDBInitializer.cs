using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace RecipeCatalogWeb.Models
{
    public class RecipeDBInitializer: DropCreateDatabaseAlways<RecipeContext>
    {
        protected override void Seed(RecipeContext context)
        {
            List<Category> categories = new List<Category>
            {
                new Category { Name = "Первые блюда" },
                new Category { Name = "Вторые блюда" },
                new Category { Name = "Салаты" },
                new Category { Name = "Закуски" },
                new Category { Name = "Соусы" },
                new Category { Name = "Десерты" },
                new Category { Name = "Выпечка" },
                new Category { Name = "Другое" }
            };

            categories.ForEach(category => context.Categories.Add(category));
            context.SaveChanges();

            List<Product> products = new List<Product> {
                new Product { Name = "Мясо", UnitMeasure = "г."}, //0
                new Product { Name = "Курица копченая", UnitMeasure = "г."}, //1
                new Product { Name = "Колбаса вареная", UnitMeasure = "г."}, //2

                new Product { Name = "Морковь", UnitMeasure = "шт."}, //3
                new Product { Name = "Картошка", UnitMeasure = "шт." }, //4
                new Product { Name = "Болгарский перец", UnitMeasure = "шт." }, //5

                new Product { Name = "Лук", UnitMeasure = "шт."}, //6
                new Product { Name = "Укроп", UnitMeasure = "пучок" }, //7
                new Product { Name = "Огурец соленый", UnitMeasure = "шт."}, //8

                new Product { Name = "Капуста квашеная", UnitMeasure = "г."}, //9
                new Product { Name = "Горошек зеленый конс.", UnitMeasure = "банка" }, //10
                new Product { Name = "Фасоль конс.", UnitMeasure = "банка" }, //11

                new Product { Name = "Яйцо", UnitMeasure = "шт." }, //12
                new Product { Name = "Майонез", UnitMeasure = "г." }, //13
                new Product { Name = "Томатная паста", UnitMeasure = "г."}, //14

                new Product { Name = "Горох", UnitMeasure = "г."}, //15
            };

            products.ForEach(product => context.Products.Add(product));
            context.SaveChanges();

            List<Recipe> recipes = new List<Recipe> {
                new Recipe {
                    CategoryId = 3,
                    Name = "С фасолью",
                    Instruction = "Порезать кубиками копченую курицу, болгарский перец и лук. Добавить фасоль. " +
                    "Заправить майонезом и посолить."
                },
                new Recipe{
                    CategoryId = 1,
                    Name = "Борщ",
                    Instruction = "Приготовить бульон. Сварить отдельно квашенную капусту. Порубить кубиками катошку. " +
                    "Картошку положить в кипящий бульон. Когда доварится, добавить капусту. Обжарить лук, морковь, болгарский перец." +
                    "Добавить томатную пасту и ещё немного подержать на огне. Зажарку положить в кастрюлю к остальным ингредиентам. " +
                    "Добавить свежую зелень."
                },
                new Recipe{
                    CategoryId = 1,
                    Name = "Гороховый суп",
                    Instruction = "Предварительно промыть горох и подержать в холодной воде. Сварить копченую курицу или ребра. " +
                    "Когда бульон будет готов, положить в него горох и варить до полуготовности. Добавить зажарку из лука и моркови. " +
                    "В конце добавить зелень."
                },
                new Recipe{
                    CategoryId = 3,
                    Name = "Оливье",
                    Instruction = "Сварить картошку и яйца. Порезать их кубиками. Также порезать колбасу, лук, сол. огурцы. " +
                    "Высыпать зеленый горошек. Заправить майонезом"
                }
            };

            recipes.ForEach(recipe => context.Recipes.Add(recipe));
            context.SaveChanges();

            List<Ingredient> ingredients = new List<Ingredient>
            {
                new Ingredient { RecipeId = 1, ProductId = 2, Quantity=400 },
                new Ingredient { RecipeId = 1, ProductId = 6, Quantity=2 },
                new Ingredient { RecipeId = 1, ProductId = 7, Quantity=1 },
                new Ingredient { RecipeId = 1, ProductId = 12, Quantity=1 },
                new Ingredient { RecipeId = 1, ProductId = 14, Quantity=20 },

                new Ingredient { RecipeId = 2, ProductId = 1, Quantity=700 },
                new Ingredient { RecipeId = 2, ProductId = 4, Quantity=1 },
                new Ingredient { RecipeId = 2, ProductId = 5, Quantity=6 },
                new Ingredient { RecipeId = 2, ProductId = 6, Quantity=1 },
                new Ingredient { RecipeId = 2, ProductId = 7, Quantity=1 },
                new Ingredient { RecipeId = 2, ProductId = 8, Quantity=1 },
                new Ingredient { RecipeId = 2, ProductId = 10, Quantity=300 },
                new Ingredient { RecipeId = 2, ProductId = 15, Quantity=50 },

                new Ingredient { RecipeId = 3, ProductId = 2, Quantity=500 },
                new Ingredient { RecipeId = 3, ProductId = 4, Quantity=1 },
                new Ingredient { RecipeId = 3, ProductId = 5, Quantity=5 },
                new Ingredient { RecipeId = 3, ProductId = 7, Quantity=1 },
                new Ingredient { RecipeId = 3, ProductId = 8, Quantity=1 },
                new Ingredient { RecipeId = 3, ProductId = 16, Quantity=300 },

                new Ingredient { RecipeId = 4, ProductId = 3, Quantity=400 },
                new Ingredient { RecipeId = 4, ProductId = 5, Quantity=6 },
                new Ingredient { RecipeId = 4, ProductId = 7, Quantity=1 },
                new Ingredient { RecipeId = 4, ProductId = 9, Quantity=4 },
                new Ingredient { RecipeId = 4, ProductId = 11, Quantity=1 },
                new Ingredient { RecipeId = 4, ProductId = 13, Quantity=6 },
                new Ingredient { RecipeId = 4, ProductId = 14, Quantity=50 }
            };

            //foreach (Ingredient e in ingredients)
            //{
            //    var ingredientInDataBase = context.Ingredients.Where(
            //        s =>
            //             s.Recipe.RecipeId == e.RecipeId &&
            //             s.Product.ProductId == e.ProductId).SingleOrDefault();
            //    if (ingredientInDataBase == null)
            //    {
            //        context.Ingredients.Add(e);
            //    }
            //}

            ingredients.ForEach(ingredient => context.Ingredients.Add(ingredient));
            context.SaveChanges();


            base.Seed(context);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RecipeCatalogWeb.Models;

namespace RecipeCatalogWeb.Controllers
{
    public class HomeController : Controller
    {
        private RecipeContext db = new RecipeContext();

        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult OneCategoryRecipe(int? id)
        {
            var recipes = db.Recipes.Where(recipe => recipe.CategoryId == id);
            ViewBag.Products = db.Ingredients.Include(c => c.Product).Where(co=>co.Recipe.Category.CategoryId==id).ToList();
            return View(recipes.ToList());
        }

        public ActionResult ShowRecipe(int? id)
        {
            Recipe recipe = db.Recipes.Find(id);
            ViewBag.Products = db.Ingredients.Include(ingr=> ingr.Product).Where(ingr => ingr.Recipe.RecipeId == id).ToList();
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        [HttpGet]
        public ActionResult Create()
        {
            //Формирование списка Категорий для передачи в представление
            SelectList categories = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.Categories = categories;
            ViewBag.Products = new SelectList(db.Ingredients, "ProductId", "Product.Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Recipe recipe)
        {
            db.Recipes.Add(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("OneCategoryRecipe", new { id = recipe.CategoryId});
        }
    }
}
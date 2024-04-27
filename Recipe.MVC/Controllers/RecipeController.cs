using Microsoft.AspNetCore.Mvc;
using Recipe.Library;
using Recipe.Library.Models;

namespace Recipe.MVC.Controllers
{
    public class RecipeController : Controller
    {
        public IActionResult Index()
        {
            return View(Library.Library.GetRecipes());
        }

        public IActionResult Details(int id) 
        {
            return View(Library.Library.GetRecipe(id));
        }

        public IActionResult Edit(int Id)
        {
            var rec = Library.Library.GetRecipe(Id);
            return View(rec);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Library.Models.Recipe rec)
        {
            Recipe.Library.Models.Recipe recipeItem = new Recipe.Library.Models.Recipe()
            {
                RecipeName = rec.RecipeName,
                RecipeNotes = rec.RecipeNotes,
                RecipeInstructions = rec.RecipeInstructions

            };

            Library.Library.AddRecipe(recipeItem);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Library.Models.Recipe rec)
        {
            Library.Library.UpdateRecipe(rec.RecipeId, rec);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Library.Library.DeleteRecipe(id);
            return RedirectToAction("Index");
        }
    }
}
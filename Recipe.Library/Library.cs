using Recipe.Library.Context;

namespace Recipe.Library
{
    public class Library
    {
        public static List<Recipe.Library.Models.Recipe> GetRecipes()
        {
            // Create a list to return all recipes
            List<Recipe.Library.Models.Recipe> list;

            try
            {
                using (var db = new DataContext())
                {
                    // Get the recipes from the database and save into list
                    list = db.Recipes.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
            return list;
        }
       
        public static Recipe.Library.Models.Recipe GetRecipe(long ID)
        {
            // Create a single recipe record to hold data
            Recipe.Library.Models.Recipe rec;

            try
            {
                using (var db = new DataContext())
                {
                    // Retrieve the recipe from teh database using the RecipeID
                    rec = db.Recipes.FirstOrDefault(x => x.RecipeId == ID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
            return rec;
        }

        public static void AddRecipe(Models.Recipe recipe)
        {
            try
            {
                using (var db = new DataContext())
                {
                    // Insert a new recipe into the database
                    db.Recipes.Add(recipe);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }

        }

        public static void DeleteRecipe(long RecipeID)
        {
            try
            {
                using (var db = new DataContext())
                {
                    // Get the RecipeID to be deleted 
                    var recipe = db.Recipes.Find(RecipeID);
                    if (recipe == null) return;

                    // Delete the recipe from the database
                    db.Recipes.Remove(recipe);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }

        }

        public static void UpdateRecipe(long RecipeID, Models.Recipe recipe)
        {
            try
            {
                using (var db = new DataContext())
                {
                    // Get the RecipeID to be updated
                    var rec = db.Recipes.Find(RecipeID);
                    if (rec == null) return;

                    // Validate changes by comparing the database info with the screen data
                    if (rec.RecipeName != recipe.RecipeName) rec.RecipeName = recipe.RecipeName;
                    if (rec.RecipeNotes != recipe.RecipeNotes) rec.RecipeNotes = recipe.RecipeNotes;
                    if (rec.RecipeInstructions != recipe.RecipeInstructions) rec.RecipeInstructions = recipe.RecipeInstructions;

                    // Update the recipe in the database
                    db.Recipes.Update(rec);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred: " + ex.Message);
            }
        }
    }
}
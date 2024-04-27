using System;
using System.Collections.Generic;

namespace Recipe.Library.Models;

public partial class Recipe
{
    public long RecipeId { get; set; }

    public string RecipeName { get; set; } = null!;

    public string? RecipeNotes { get; set; }

    public string RecipeInstructions { get; set; } = null!;
}

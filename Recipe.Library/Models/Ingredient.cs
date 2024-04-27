using System;
using System.Collections.Generic;

namespace Recipe.Library.Models;

public partial class Ingredient
{
    public long IngredientId { get; set; }

    public long RecipeId { get; set; }

    public string? Amount { get; set; }

    public string? FractionalAmount { get; set; }

    public string? UnitOfMeasure { get; set; }

    public string Description { get; set; } = null!;
}

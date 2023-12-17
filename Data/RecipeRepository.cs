using System.Text.Json;
using Logic.Domain;
using Logic.Interfaces;

namespace Data;

public class RecipeRepository : IRecipeRepository
{
    public IEnumerable<Recipe> GetAllRecipes()
    {
        var recipeJson = File.ReadAllText("../recipes.json");
        var recipes = JsonSerializer.Deserialize<List<Recipe>>(recipeJson);
        
        return recipes?.ToArray() ?? Array.Empty<Recipe>();
    }

    public IEnumerable<Ingredient> GetAllIngredients()
    {
        var ingredientJson = File.ReadAllText("../ingredients.json");
        var ingredients = JsonSerializer.Deserialize<List<Ingredient>>(ingredientJson);
        
        return ingredients?.ToArray() ?? Array.Empty<Ingredient>();
    }
}
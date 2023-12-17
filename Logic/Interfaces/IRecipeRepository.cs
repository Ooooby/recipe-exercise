using Logic.Domain;

namespace Logic.Interfaces;

public interface IRecipeRepository
{
    public IEnumerable<Recipe> GetAllRecipes();
    public IEnumerable<Ingredient> GetAllIngredients();
}
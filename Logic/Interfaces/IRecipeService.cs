using Logic.Domain;

namespace Logic.Interfaces;

public interface IRecipeService
{
    IEnumerable<Recipe> SearchRecipes(string searchTerm);
}
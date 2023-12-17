using Logic.Domain;
using Logic.Interfaces;

namespace Logic;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;

    public RecipeService(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    
    public IEnumerable<Recipe> SearchRecipes(string? searchTerm)
    {
        return _recipeRepository.GetAllRecipes()
            .Where(r => r.Name.ToLower().Contains(searchTerm?.ToLower() ?? ""));
    }
}
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.React.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipeController : ControllerBase
{
    private readonly ILogger<RecipeController> _logger;
    private readonly IRecipeService _recipeService;

    public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService)
    {
        _logger = logger;
        _recipeService = recipeService;
    }
    
    private readonly string[] _searchTerms = { "chicken", "pasta", "cheese" };

    [HttpGet]
    public IEnumerable<Recipe> Get()
    {
        var searchTerm = _searchTerms[Random.Shared.Next(_searchTerms.Length)];
        var recipes = _recipeService.SearchRecipes(searchTerm).ToArray();
        
        return recipes.Select(r => new Recipe
            {
                Id = r.Id,
                Name = r.Name,
            })
            .ToArray();
    }
}
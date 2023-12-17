using System.Diagnostics;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Razor.Models;

namespace Web.Razor.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRecipeService _recipeService;

    public HomeController(ILogger<HomeController> logger, IRecipeService recipeService)
    {
        _logger = logger;
        _recipeService = recipeService;
    }

    public IActionResult Index()
    {
        var model = new IndexModel
        {
            RecipeNames = Array.Empty<string>(),
            SearchTerm = "",
        };
        
        return View(model);
    }

    [HttpPost]
    public IActionResult Index(IndexModel model)
    {
        model.RecipeNames = _recipeService.SearchRecipes(model.SearchTerm)
            .Select(r => r.Name)
            .ToArray();
        
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
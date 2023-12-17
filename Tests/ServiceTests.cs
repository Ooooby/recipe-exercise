using System.Collections.Generic;
using System.Linq;
using Logic;
using Logic.Domain;
using Logic.Interfaces;
using Moq;
using Xunit;

namespace Tests;

public class ServiceTests
{
    private RecipeService? _underTest;
    
    [Fact]
    public void SearchRecipes_ReturnsAllMatchingRecipes()
    {
        var mockRecipeRepository = new Mock<IRecipeRepository>();
        var allRecipes = new List<Recipe>
        {
            new() { Id = 1, Name = "Chicken Soup" },
            new() { Id = 2, Name = "Jam Sandwich" },
            new() { Id = 3, Name = "Honey Chicken" },
        };
        mockRecipeRepository.Setup(repo => repo.GetAllRecipes())
            .Returns(allRecipes);
        _underTest = new RecipeService(mockRecipeRepository.Object);

        var foundRecipes = _underTest.SearchRecipes("chicken").ToArray();

        Assert.Equal(new[] {1, 3}, foundRecipes.Select(r => r.Id).ToArray());
    }
}
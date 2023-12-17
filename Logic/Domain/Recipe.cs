namespace Logic.Domain;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int[] IngredientIds { get; set; } = Array.Empty<int>();
}
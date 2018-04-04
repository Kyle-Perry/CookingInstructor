using System.Collections.Generic;

public class Recipe
{
    public string recipeName;
    public string category;
    public string photoPath;
    public List<Ingredient> ingredients;
    public List<Instruction> instructions;
    bool isFavorite;
    
    public Recipe()
    {
        this.isFavorite = false;
    }

    public Recipe(string recipeName, string category, string photoPath, List<Ingredient> ingredients, List<Instruction> instructions)
    {
        this.isFavorite = false;
        this.recipeName = recipeName;
        this.category = category;
        this.photoPath = photoPath;
        this.ingredients = ingredients;
        this.instructions = instructions;
    }

}


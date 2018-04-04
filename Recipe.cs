public class Recipe
{
    public string recipeName;
    public string category;
    public string photoPath;
    public List<Ingredient> ingredients;
    public List<Instruction> instructions;
    
    public Recipe Recipe()
    {

    }

    public Recipe Recipe(string recipeName, string category, string photoPath, List<Ingredient> ingredients, List<Instructions> instructions)
    {
        this.recipeName = recipeName;
        this.category = category;
        this.photoPath = photoPath;
        this.ingredients = ingredients;
        this.instructions = instructions;
    }

    /*public string getRecipeName()
    {
        return recipeName;
    }

    public void setRecipeName(string recipeName)
    {
        this.recipeName = recipeName;
    }

    public string getCategory()
    {
        return category;
    }

    public string getPhotoPath()
    {
        return photoPath;
    }

    public bool emptyIngredients()
    {
        return ingredients.isEmpty();
    }

    public bool emptyIngredients()
    {
        return instructions.isEmpty();
    }*/


}


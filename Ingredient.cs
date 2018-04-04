public class Ingredient
{
    public string name;
    public string measure;
    public double amount;

    public Ingredient()
    {

    }

    public Ingredient(string name, string measure, double amount)
    {
        this.name = name;
        this.measure = measure;
        this.amount = amount;
    }
}
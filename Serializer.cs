using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public class Serializer
{
    XmlSerializer serializer;
    string filename;

    public Serializer(string filename)
    {
        this.filename = filename;
        serializer = new XmlSerializer(typeof(List<Recipe>));
    }

    public List<Recipe> Read()
    {
        try
        {
            FileStream writer = File.Open(filename, FileMode.Open);
            List<Recipe> recipes = new List<Recipe>();
            recipes = (serializer.Deserialize(writer) as List<Recipe>);
            writer.Close();
            return recipes;
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
        

    public void WriteRecipes(List<Recipe> recipes)
    {
        FileStream writer = File.Create(filename);  
        serializer.Serialize(writer, recipes);
        writer.Close();
    }
}


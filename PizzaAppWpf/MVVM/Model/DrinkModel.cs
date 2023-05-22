using System;

namespace PizzaAppWpf.MVVM.Model;

public class DrinkModel : ICloneable
{
    public string imageUrl    { get; set; }
    public string Name        { get; set; }
    public string Description { get; set; }

    public DrinkModel()
    {
        imageUrl = "";
        Name = "";
        Description = "";
    }

    public DrinkModel(string imageUrl, string name, string description)
    {
        this.imageUrl = imageUrl;
        Name = name;
        Description = description;
    }


    public object Clone()
    {
        return new DrinkModel(imageUrl, Name, Description);
    }
}
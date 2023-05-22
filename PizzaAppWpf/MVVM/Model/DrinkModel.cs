using System;
using System.Collections.Generic;

#pragma warning disable
namespace PizzaAppWpf.MVVM.Model;

public class DrinkModel : ICloneable
{
    public string imageUrl    { get; set; }
    public string Name        { get; set; }
    public string Description { get; set; }
    public List<CapacitiesModel> Size        { get; set; }

    public DrinkModel()
    {
        imageUrl = "";
        Name = "";
        Description = "";
    }

    public DrinkModel(string imageUrl, string name, string description, object size)
    {
        this.imageUrl = imageUrl;
        Name = name;
        Description = description;
        Size = (List<CapacitiesModel>)size;
    }


    public object Clone()
    {
        return new DrinkModel(imageUrl, Name, Description, this.Size);
    }
}
using System;

namespace PizzaAppWpf.Model
{
    public class ToppingsModel : ICloneable
    {
        public int    Id         { get; set; }
        public string Name       { get; set; }
        public int    Price      { get; set; } 
        public bool   IsSelected { get; set; }

        public ToppingsModel(int id, string name,int price, bool isSelected)
        {
            Id = id;
            Name = name;
            Price = price;
            IsSelected = isSelected;
        }

        public ToppingsModel()
        {
            // Empty constructor
        }

        public object Clone()
        {
            return new ToppingsModel(Id, Name, Price,IsSelected);
        }
    }
}
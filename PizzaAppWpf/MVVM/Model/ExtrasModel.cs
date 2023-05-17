using System;

namespace PizzaAppWpf.Model
{
    public class ExtrasModel : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public int Amount { get; set; }

        public ExtrasModel(int id, string name, int price, int total, int amount)
        {
            Id = id;
            Name = name;
            Price = price;
            Total = total;
            Amount = amount;
        }

        public object Clone()
        {
            return new ExtrasModel(Id, Name, Price, Total, Amount);
        }
    }
}
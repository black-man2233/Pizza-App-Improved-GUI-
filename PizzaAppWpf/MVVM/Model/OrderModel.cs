using System;
using System.Collections.ObjectModel;
using System.Text;
using PizzaAppWpf.Model;

#pragma warning disable
namespace PizzaAppWpf.MVVM.Model
{
    public class OrderModel : ICloneable
    {
        public  string                               ImageUrl    { get; set; }
        private int                                  Id          { get; set; }
        public  string                               Name        { get; set; }
        public  int                                  Price       { get; set; }
        public  string                               Description { get; set; }
        public  ObservableCollection<ToppingsModel>? Toppings    { get; set; }


        public OrderModel(string imageUrl, int id, string name, int price, string description,
            ObservableCollection<ToppingsModel>? toppings)
        {
            this.ImageUrl = imageUrl;
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Toppings = toppings;
        }

        /// <summary>
        /// Takes an object and creates a new OrderModel from it, if the object is not a PizzaModel or DrinkModel
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="Exception"></exception>
        public OrderModel(Object obj)
        {
            if (obj is PizzaModel p)
            {
                PizzaModel(p);
            }
            else if (obj is DrinkModel d)
            {
                this.DrinkModel(d);
            }
            else
            {
                throw new Exception("Invalid object type");
            }
        }

        public void PizzaModel(PizzaModel p)
        {
            this.ImageUrl = p.imageUrl;
            Id = p.Id;
            Name = p.Name;
            Price = p.Price;
            Description = Description;
            Toppings = new();
        }

        public void DrinkModel(DrinkModel d)
        {
            this.ImageUrl = d.imageUrl;
            Name = d.Name;
            Price = d.Price;
            Description = Description;
            Toppings = null;
        }

        public object Clone()
        {
            return new OrderModel(this.ImageUrl, this.Id, this.Name, this.Price, this.Description,
                this.Toppings);
        }
    }
}
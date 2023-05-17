using System;
using PizzaAppWpf.Model;

namespace PizzaAppWpf.MVVM.Model
{
    public class OrderModel : ICloneable
    {
        public string imageUrl { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<ToppingsModel>? Toppings { get; set; }
        public System.Collections.ObjectModel.ObservableCollection<ExtrasModel>? Extras { get; set; }


        public OrderModel(string u, int i, string n, int p, int t, string d, string type, System.Collections.ObjectModel.ObservableCollection<ToppingsModel>? tp, System.Collections.ObjectModel.ObservableCollection<ExtrasModel>? e)
        {
            imageUrl = u;
            Id = i;
            Name = n;
            Price = p;
            Total = t;
            Description = d;
            Type = type;

            Toppings = tp;
            Extras = e;
        }


        public OrderModel(PizzaModel p)
        {
            this.Type = "PizzaModel";
            imageUrl = p.imageUrl;
            Id = p.Id;
            Name = p.Name;
            Price = p.Price;
            Description = p.Description;
            if (p.Toppings is not null)
            {
                Toppings = p.Toppings;
            }

            if (p.Extras is not null)
            {
                Extras = p.Extras;

            }
        }


        public OrderModel(SidesModel s)
        {
            Type = "SidesModel"; ;
            imageUrl = s.imageUrl;
            Id = s.Id;
            Name = s.Name;
            Price = s.Price;
            Total = s.Price;
            Description = s.Description;
            Toppings = null;
            Extras = null;
        }

        public object Clone()
        {
            return new OrderModel(this.imageUrl, this.Id, this.Name, this.Price, this.Total, this.Description, this.Type, this.Toppings, this.Extras);
        }
    }
}

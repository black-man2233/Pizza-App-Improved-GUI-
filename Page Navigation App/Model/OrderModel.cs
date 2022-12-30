using System;
using System.Collections.ObjectModel;

namespace Page_Navigation_App.Model
{
    class OrderModel : ICloneable
    {
        public string imageUrl { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public string Description { get; set; }
        public String Type { get; set; }
        public ObservableCollection<ToppingsModel>? Toppings { get; set; }
        public ObservableCollection<ExtrasModel>? Extras { get; set; }


        public OrderModel(string u, int i, string n, int p, int t, string d, string type, ObservableCollection<ToppingsModel>? tp, ObservableCollection<ExtrasModel>? e)
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
            Total = p.Total;
            Description = p.Description;
            Toppings = null;
            Extras = null;
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

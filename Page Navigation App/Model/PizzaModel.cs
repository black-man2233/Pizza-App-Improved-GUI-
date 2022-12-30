using System.Collections.ObjectModel;

namespace Page_Navigation_App.Model
{
    class PizzaModel
    {
        public string imageUrl { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public string Description { get; set; }

        public string Type { get; set; }

        public ObservableCollection<ToppingsModel>? Toppings { get; set; }
        public ObservableCollection<ExtrasModel>? Extras { get; set; }

        public PizzaModel(string url, int i, string n, int p, int t, string d, ObservableCollection<ToppingsModel>? tp, ObservableCollection<ExtrasModel>? e)
        {
            imageUrl = url;
            Id = i;
            Name = n;
            Price = p;
            Total = t;
            Description = d;
            Type = "PizzaModel";
            Toppings = tp;
            Extras = e;
        }

        public object Clone()
        {
            return new PizzaModel(this.imageUrl, this.Id, this.Name, this.Price, this.Total, this.Description, this.Toppings, this.Extras);
        }

    }
}

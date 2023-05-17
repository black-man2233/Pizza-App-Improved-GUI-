using System.Collections.ObjectModel;
using PizzaAppWpf.Model;

#pragma warning disable
namespace PizzaAppWpf.MVVM.Model
{
    public class PizzaModel
    {
        public string imageUrl { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }


        public ObservableCollection<ToppingsModel>? Toppings { get; set; }
        public ObservableCollection<ExtrasModel>? Extras { get; set; }

        public PizzaModel()
        {
            
        }
        public PizzaModel(string url, int i, string n, int p, string d, ObservableCollection<ToppingsModel>? tp, ObservableCollection<ExtrasModel>? e)
        {
            imageUrl = url;
            Id = i;
            Name = n;
            Price = p;
            Description = d;
            Toppings = tp;
            Extras = e;
        }

        public object Clone()
        {
            return new PizzaModel(this.imageUrl, this.Id, this.Name, this.Price, this.Description, this.Toppings, this.Extras);
        }

    }
}

using System;
using System.Collections.ObjectModel;

namespace PizzaAppWpf.Model
{
    public class SidesModel : ICloneable
    {
        public string imageUrl { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public ObservableCollection<SidesSizeModel> Sizes { get; set; }

        public SidesModel(string imageUrl, int id, string name, int price, string description, ObservableCollection<SidesSizeModel> sizes)
        {
            this.imageUrl = imageUrl;
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Sizes = sizes;
        }


        public object Clone()
        {
            return new SidesModel(imageUrl, Id, Name, Price, Description, Sizes);
        }
    }
}

using Newtonsoft.Json;
using PizzaAppWpf.Model;
using System.Collections.ObjectModel;
using System.IO;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    class DataBaseModel
    {
        //PizzaList
        private ObservableCollection<PizzaModel> _pizzas = JsonConvert.DeserializeObject<ObservableCollection<PizzaModel>>(File.ReadAllText(@"Pizza-App-Improved-GUI-\PizzaAppWpf\DataBase\Json\PizzasDB.json"));
        public ObservableCollection<PizzaModel> PizzaList { get => this._pizzas; }

        //Sides
        private ObservableCollection<SidesModel> _sides = JsonConvert.DeserializeObject<ObservableCollection<SidesModel>>(File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaAppWpf\PizzaAppWpf\DataBase\Json\SidesDB.json"));
        public ObservableCollection<SidesModel> Sides { get => this._sides; }


        //Toppings
        private ObservableCollection<ToppingsListModel> _toppingsList = JsonConvert.DeserializeObject<ObservableCollection<ToppingsListModel>>(File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaAppWpf\PizzaAppWpf\DataBase\Json\ToppingsDB.json"));
        public ObservableCollection<ToppingsListModel> ToppingsList { get => _toppingsList; }

        //Extras
        private ObservableCollection<ExtrasModel> _extraList = JsonConvert.DeserializeObject<ObservableCollection<ExtrasModel>>(File.ReadAllText(@"C:\Users\Kevin\source\repos\PizzaAppWpf\PizzaAppWpf\DataBase\Json\ExtrasDb.json"));
        public ObservableCollection<ExtrasModel> ExtrasList { get => _extraList; }
    }
}


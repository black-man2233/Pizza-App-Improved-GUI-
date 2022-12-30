﻿using Newtonsoft.Json;
using Page_Navigation_App.Model;
using System.Collections.ObjectModel;
using System.IO;

namespace PizzaApp_WPF.Model
{
#pragma warning disable
    class DataBaseModel
    {
        //PizzaList
        private ObservableCollection<PizzaModel> _pizzas = JsonConvert.DeserializeObject<ObservableCollection<PizzaModel>>(File.ReadAllText(@"C:\Users\Kevin\source\repos\Page Navigation App\Page Navigation App\DataBase\Json\PizzasDB.json"));
        public ObservableCollection<PizzaModel> PizzaList { get => this._pizzas; }


        ////Toppings
        //PizzaList
        private ObservableCollection<SidesModel> _sides = JsonConvert.DeserializeObject<ObservableCollection<SidesModel>>(File.ReadAllText(@"C:\Users\Kevin\source\repos\Page Navigation App\Page Navigation App\DataBase\Json\SidesDB.json"));
        public ObservableCollection<SidesModel> Sides { get => this._sides; }




    }
}

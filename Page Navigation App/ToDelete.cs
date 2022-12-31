using Page_Navigation_App.Model;
using System;
using System.Collections.ObjectModel;

namespace Page_Navigation_App
{
    class ToDelete
    {
        public ToDelete(object sender)
        {

            ObservableCollection<ToppingsListModel> ToppingsList = new();
            ObservableCollection<ExtrasModel> ExtrasList = new();
            PizzaModel pizza = sender as PizzaModel;


            if (ToppingsList.Count > pizza.Id - 1)
            {
                var _toppingslist = (ToppingsList[pizza.Id - 1].Toppings);
                pizza.Toppings = new();

                foreach (var item in _toppingslist)
                    pizza.Toppings.Add(item);

                pizza.Extras = new();
                foreach (var item in ExtrasList)
                    pizza.Extras.Add(item);

            }
            else
            {
                Random _randomNumber = new Random();
                int _randIndex = _randomNumber.Next(ToppingsList.Count);
                var _toppingslist = (ToppingsList[_randIndex].Toppings);
                pizza.Toppings = new();

                foreach (var item in _toppingslist)
                    pizza.Toppings.Add(item);

                pizza.Extras = new();
                foreach (var item in ExtrasList)
                    pizza.Extras.Add(item);

            }
        }
    }
}

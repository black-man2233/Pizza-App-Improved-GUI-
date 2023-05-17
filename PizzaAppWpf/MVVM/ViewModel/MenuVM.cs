using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PizzaAppWpf.Model;
using PizzaAppWpf.MVVM.Model;
using PizzaAppWpf.Utilities;

#pragma warning disable
namespace PizzaAppWpf.MVVM.ViewModel
{
    class MenuVM : Utilities.ViewModelBase
    {

        #region Properties
        private ObservableCollection<PizzaModel>? _pizzaList;
        public ObservableCollection<PizzaModel> PizzaList
        {
            get => _pizzaList;
            set
            {
                _pizzaList = value;
                OnPropertyChanged("PizzaList");
            }
        }

        public static ObservableCollection<OrderModel> _cart = new();
        public ObservableCollection<OrderModel> Cart
        {
            get
            {
                return _cart;
            }
            set
            {
                _cart = value;
                OnPropertyChanged("Cart");
            }
        }

        private ObservableCollection<SidesModel> _sides = new();
        public ObservableCollection<SidesModel> Sides
        {
            get
            {
                return _sides;
            }
            set
            {
                _sides = value;
                OnPropertyChanged("Sides");
            }
        }

        private ObservableCollection<ToppingsListModel> _toppingsList { get; set; } = new();
        private ObservableCollection<ExtrasModel> _extrasList { get; set; } = new();

        #endregion

        #region ICommands
        public ICommand PizzaListDoubleClickCommand { get; set; }
        public ICommand SidezListDoubleClickCommand { get; set; }
        #endregion

        private void AddToCart(Object sender)
        {


            if (sender is PizzaModel MenuSelectedItem)
            {

                if (_toppingsList.Count > MenuSelectedItem.Id - 1)
                {
                    var pizza = MenuSelectedItem;

                    var _toppingslist = (_toppingsList[MenuSelectedItem.Id - 1].Toppings);
                    pizza.Toppings = new();

                    foreach (ToppingsModel item in _toppingslist)
                        pizza.Toppings.Add(item);
                    //pizza.Toppings.Add((ToppingsModel)item.Clone());

                    pizza.Extras = new();
                    foreach (ExtrasModel item in _extrasList)
                        pizza.Extras.Add(item);
                    //pizza.Extras.Add((ExtrasModel)item.Clone());

                    Cart.Add(new OrderModel((PizzaModel)pizza.Clone()));
                }
                else
                {
                    var pizza = MenuSelectedItem;
                    Random _randomNumber = new Random();
                    int _randIndex = _randomNumber.Next(_toppingsList.Count);
                    var _toppingslist = (_toppingsList[_randIndex].Toppings);
                    pizza.Toppings = new();

                    foreach (var item in _toppingslist)
                        pizza.Toppings.Add((ToppingsModel)item.Clone());

                    pizza.Extras = new();
                    foreach (var item in _extrasList)
                        pizza.Extras.Add(item.Clone() as ExtrasModel);

                    Cart.Add(new OrderModel((PizzaModel)pizza.Clone()));

                }

            }
            if (sender is SidesModel s)
            {
                this.Cart.Add(new OrderModel((SidesModel)s.Clone()));
            }
        }

        public MenuVM()
        { 
            _pizzaList = new(DataBase.Database.Instance.GetAllPizzas());
            
            PizzaListDoubleClickCommand = new RelayCommand(AddToCart);
            SidezListDoubleClickCommand = new RelayCommand(AddToCart);
        }
    }
}

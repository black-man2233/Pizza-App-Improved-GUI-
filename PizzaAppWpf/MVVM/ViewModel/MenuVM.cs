using System;
using System.Collections.ObjectModel;
using System.Windows;
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

        public ObservableCollection<DrinkModel> _drinksList { get; set; }

        public ObservableCollection<DrinkModel> DrinksList
        {
            get { return _drinksList; }
            set
            {
                _drinksList = value;
                OnPropertyChanged("DrinksList");
            }
        }

        public static ObservableCollection<OrderModel> _cart = new();

        public ObservableCollection<OrderModel> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                OnPropertyChanged("Cart");
            }
        }

        #endregion

        #region ICommands & Command Functions

        public ICommand PizzaListDoubleClickCommand { get; set; }
        public ICommand SidezListDoubleClickCommand { get; set; }

        private void AddToCart(Object sender) => _cart.Add(new OrderModel(sender));

        private void Commands()
        {
            PizzaListDoubleClickCommand = new RelayCommand(AddToCart);
            SidezListDoubleClickCommand = new RelayCommand(AddToCart);
        }

        #endregion

        public MenuVM()
        {
            _pizzaList = new(DataBase.Database.Instance.GetAllPizzas());
            _drinksList = new(DataBase.Database.Instance.GetAllDrinks());

            Commands();
        }
    }
}
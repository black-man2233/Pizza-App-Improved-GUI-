using Page_Navigation_App.Model;
using Page_Navigation_App.Utilities;
using PizzaApp_WPF.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Page_Navigation_App.ViewModel
{
    class HomeVM : Utilities.ViewModelBase
    {
        static DataBaseModel db = new();

        #region Properties
        private ObservableCollection<PizzaModel>? _pizzaList = new(db.PizzaList);
        public ObservableCollection<PizzaModel> PizzaList
        {
            get => _pizzaList;
            set
            {
                _pizzaList = value;
                OnPropertyChanged("MyProperty");
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

        private ObservableCollection<SidesModel> _sides = new(db.Sides);
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
        #endregion

        #region ICommands
        public ICommand PizzaListDoubleClickCommand { get; set; }
        public ICommand SidezListDoubleClickCommand { get; set; }
        #endregion

        #region CommandsFunction
        private void AddToCart(Object sender)
        {
            if (sender is PizzaModel p)
            {
                this.Cart.Add(new OrderModel(p));
            }
            if (sender is SidesModel s)
            {
                this.Cart.Add(new OrderModel(s));
            }
        }

        #endregion
        public HomeVM()
        {
            PizzaListDoubleClickCommand = new RelayCommand(AddToCart);
            SidezListDoubleClickCommand = new RelayCommand(AddToCart);

        }







    }
}

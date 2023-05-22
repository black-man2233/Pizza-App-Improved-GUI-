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

        #region ICommands

        public ICommand PizzaListDoubleClickCommand { get; set; }
        public ICommand SidezListDoubleClickCommand { get; set; }

        #endregion

        private void AddToCart(Object sender)
        {
            MessageBox.Show("Add to cart");
        }

        public MenuVM()
        {
            _pizzaList = new(DataBase.Database.Instance.GetAllPizzas());

            PizzaListDoubleClickCommand = new RelayCommand(AddToCart);
            SidezListDoubleClickCommand = new RelayCommand(AddToCart);
        }
    }
}
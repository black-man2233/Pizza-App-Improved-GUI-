using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using PizzaAppWpf.Model;
using PizzaAppWpf.Utilities;
using PizzaAppWpf.View;

namespace PizzaAppWpf.ViewModel
{
    class CartVM : Utilities.ViewModelBase
    {
        #region Properties
        private ObservableCollection<OrderModel> _cartItems = new();
        public ObservableCollection<OrderModel> CartItems
        {
            get
            {
                return _cartItems;
            }
            set
            {
                _cartItems = value;
                OnPropertyChanged("CartItems");
            }
        }
        #endregion

        #region ICommand
        public ICommand DeleteFromCartCommand { get; set; }
        public ICommand EditPizzaCommand { get; set; }
        #endregion

        #region Command Functions
        void EditPizza(object sender)
        {
            if (sender is not null)
            {
                if (sender is OrderModel o)
                    if (o.Type is "PizzaModel")
                    {
                        EditWindow editWindow = new(o);
                        editWindow.ShowDialog();
                    }
                    else
                        MessageBox.Show("Vælge en venligste en Pizza");
            }
            else
                MessageBox.Show("Vælge venligste et item fra listen");

        }
        void Delete(object sender)
        {
            if (sender is not null)
                if (sender is OrderModel o)
                {
                    MenuVM._cart.Remove(o);
                    this.CartItems.Remove(o);
                }

        }
        #endregion

        #region Constructor
        public CartVM()
        {
            _cartItems.Clear();
            foreach (OrderModel item in MenuVM._cart)
            {
                _cartItems.Add(item);

            }

            EditPizzaCommand = new RelayCommand(EditPizza);
            DeleteFromCartCommand = new RelayCommand(Delete);
        }
        #endregion
    }
}


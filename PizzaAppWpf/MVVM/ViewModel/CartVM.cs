using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using PizzaAppWpf.MVVM.Model;
using PizzaAppWpf.MVVM.View;
using PizzaAppWpf.Utilities;

namespace PizzaAppWpf.MVVM.ViewModel
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
            MessageBox.Show("Edit Pizza");
        }
        void Delete(object sender)
        {
            MessageBox.Show("Delete Pizza");

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


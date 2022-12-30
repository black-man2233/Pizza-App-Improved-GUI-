using Page_Navigation_App.Model;
using Page_Navigation_App.Utilities;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Page_Navigation_App.ViewModel
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
                        MessageBox.Show("LEssgoo");
            }
            else
                MessageBox.Show("Vælge venligste et item fra listen");

            NavigationVM.ItemsCountUpdater();
        }
        void Delete(object sender)
        {
            if (sender is not null)
                if (sender is OrderModel o)
                {
                    HomeVM._cart.Remove(o);
                    this.CartItems.Remove(o);
                }

            NavigationVM.ItemsCountUpdater();
        }
        #endregion

        #region Constructor
        public CartVM()
        {
            _cartItems.Clear();
            foreach (OrderModel item in HomeVM._cart)
            {
                _cartItems.Add(item);

            }

            EditPizzaCommand = new RelayCommand(EditPizza);
            DeleteFromCartCommand = new RelayCommand(Delete);
        }
        #endregion
    }
}


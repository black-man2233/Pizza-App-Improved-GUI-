using Page_Navigation_App.Model;
using Page_Navigation_App.Utilities;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Page_Navigation_App.ViewModel
{
    class CartVM : Utilities.ViewModelBase
    {
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

        public ICommand DeleteFromCartCommand { get; set; }

        void Delete(object sender)
        {
            if (sender is not null)
                if (sender is OrderModel o)
                {
                    HomeVM._cart.Remove(o);
                    this.CartItems.Remove(o);
                }
        }

        public CartVM()
        {
            _cartItems.Clear();
            foreach (OrderModel item in HomeVM._cart)
            {
                _cartItems.Add(item);

            }

            DeleteFromCartCommand = new RelayCommand(Delete);



        }



    }
}

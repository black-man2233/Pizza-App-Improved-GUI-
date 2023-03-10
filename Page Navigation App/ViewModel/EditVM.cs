using Page_Navigation_App.Model;
using Page_Navigation_App.Utilities;

using System.Windows.Input;

namespace Page_Navigation_App.ViewModel
{
    class EditVM : Utilities.ViewModelBase
    {
        private OrderModel _selectedOrder;
        public OrderModel SelectedOrder
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }


        public ICommand ToppingsCheckedCommand { get; set; }
        public ICommand ToppingsUnCheckedCommand { get; set; }



        void ToppingChecked(object sender)
        {

        }
        void ToppingUnChecked(object sender)
        {

        }


        public EditVM(OrderModel o)
        {
            this.SelectedOrder = o;

            ToppingsCheckedCommand = new RelayCommand(ToppingChecked);
            ToppingsUnCheckedCommand = new RelayCommand(ToppingUnChecked);
        }



    }
}

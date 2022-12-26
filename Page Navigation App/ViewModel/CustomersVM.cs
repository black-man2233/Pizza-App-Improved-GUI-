using Page_Navigation_App.Model;

namespace Page_Navigation_App.ViewModel
{
    class CustomersVM : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;

        public int CustommerID
        {
            get { return _pageModel.CustommerCount; }
            set { _pageModel.CustommerCount = value; OnPropertyChanged(); }
        }

        public CustomersVM()
        {
            _pageModel = new PageModel();
            CustommerID = 100528;
        }

    }
}

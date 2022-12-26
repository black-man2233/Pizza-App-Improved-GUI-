using Page_Navigation_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Page_Navigation_App.ViewModel
{
    class TransactionsVM : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;

        public Decimal TransactionAmmount
        {
            get { return _pageModel.TransactionValue; }
            set { _pageModel.TransactionValue = value; OnPropertyChanged(); }
        }


        public TransactionsVM()
        {
            _pageModel = new PageModel();

            TransactionAmmount = 5638;
        }
    }
}

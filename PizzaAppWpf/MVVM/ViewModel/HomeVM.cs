using System;
using System.Windows.Controls;
using System.Windows.Input;
using PizzaAppWpf.MVVM.ViewModel;
using PizzaAppWpf.Utilities;

namespace PizzaAppWpf.ViewModel
{
    class HomeVM : Utilities.ViewModelBase
    {
        public ICommand VideoCLickedCommand { get; set; }

        void VideoClicked(object sender)
        {
            if (sender is HomeVM vm)
            {
               
            }
        }

        public HomeVM()
        {
            VideoCLickedCommand = new RelayCommand(VideoClicked);
        }
    }
}
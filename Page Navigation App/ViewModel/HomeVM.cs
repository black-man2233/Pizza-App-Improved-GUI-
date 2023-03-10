using Page_Navigation_App.Utilities;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Page_Navigation_App.ViewModel
{
    class HomeVM : Utilities.ViewModelBase
    {
        public System.Uri VideosUrl = new Uri("https://www.youtube.com/watch?v=p2SH_BRYKi8&ab_channel=KevinBamwesa");

        public ICommand VideoEndedCommand { get; set; }
        public ICommand VideoCLickedCommand { get; set; }

        void VideoClicked(object sender)
        {
            if (sender is not null)
                if (sender is MainWindow mw)
                {
                    if (mw.DataContext is NavigationVM nvm)
                    {
                        mw.MenuBtn.IsChecked = true;
                        nvm.CurrentView = new MenuVM();
                    }
                }

        }

        void VideoEnded(object sender)
        {
            if (sender is not null)
                if (sender is MediaElement m)
                {
                    m.LoadedBehavior = MediaState.Manual;
                    m.Position = new TimeSpan(0, 0, 1);
                    m.Play();
                }
        }

        public HomeVM()
        {
            VideoEndedCommand = new RelayCommand(VideoEnded);
            VideoCLickedCommand = new RelayCommand(VideoClicked);
        }
    }
}

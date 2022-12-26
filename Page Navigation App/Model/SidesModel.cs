using System.Collections.ObjectModel;

namespace Page_Navigation_App.Model
{
    class SidesModel
    {
        public string ImgUrl { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public ObservableCollection<ToppingsSizeModel> Sizes { get; set; }
    }
}

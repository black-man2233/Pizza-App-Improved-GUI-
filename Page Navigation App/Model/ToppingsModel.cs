using System;

namespace Page_Navigation_App.Model
{
    public class ToppingsModel : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        public ToppingsModel(int id, string name, bool isSelected)
        {
            Id = id;
            Name = name;
            IsSelected = isSelected;
        }

        public object Clone()
        {
            return new ToppingsModel(Id, Name, IsSelected);
        }
    }
}
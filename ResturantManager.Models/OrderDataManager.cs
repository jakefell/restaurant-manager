using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {
        private List<MenuItem> _menuItems = new List<MenuItem>();
        private List<MenuItem> _currentlySelectedMenuItems = new List<MenuItem>();
        
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5]
            };
        }

        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                if (_menuItems != value)
                {
                    _menuItems = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get { return _currentlySelectedMenuItems; }
            set
            {
                if (_currentlySelectedMenuItems != value)
                {
                    _currentlySelectedMenuItems = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

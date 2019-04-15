using RestaurantManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using Windows.UI.Popups;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private MenuItem _selectedMenuItem;
        private string _specialRequests;

        private List<MenuItem> _menuItems;
        private ObservableCollection<MenuItem> _currentlySelectedMenuItems;

        public OrderViewModel()
        {
            this.AddMenuItemCommand = new DelegateCommand(AddMenuItem);
            this.SubmitOrderCommand = new DelegateCommand(SubmitOrder);

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
        }

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;
            this.SelectedMenuItem = this.MenuItems.First();
        }

        public DelegateCommand AddMenuItemCommand { get; private set; }
        public DelegateCommand SubmitOrderCommand { get; private set; }

        public MenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                if (_selectedMenuItem != value)
                {
                    _selectedMenuItem = value;
                    NotifyPropertyChanged();
                } 
            }
        }

        public string SpecialRequests
        {
            get { return _specialRequests; }
            set
            {
                if (_specialRequests != value)
                {
                    _specialRequests = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                if (_menuItems != value)
                {
                    _menuItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get { return _currentlySelectedMenuItems; }
            set
            {
                if (_currentlySelectedMenuItems != value)
                {
                    _currentlySelectedMenuItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void AddMenuItem()
        {
            this.CurrentlySelectedMenuItems.Add(SelectedMenuItem);
        }

        private async void SubmitOrder()
        {
            // This is a test comment.

            base.Repository.Orders.Add(new Order
            {
                Complete = false,
                Expedite = false,
                Items = new List<MenuItem>(this.CurrentlySelectedMenuItems),
                SpecialRequests = this.SpecialRequests,
                Table = base.Repository.Tables.First()
            });

            this.CurrentlySelectedMenuItems.Clear();

            await new MessageDialog("Order Submitted").ShowAsync();
        }
    }
}

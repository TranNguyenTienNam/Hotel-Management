using System;
using HotelManagement.Core;

namespace HotelManagement.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand BookingsViewCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }

        public BookingsViewModel BookingsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            BookingsVM = new BookingsViewModel();
            
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeVM;
            });

            BookingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = BookingsVM;
            });
        }
    }
}

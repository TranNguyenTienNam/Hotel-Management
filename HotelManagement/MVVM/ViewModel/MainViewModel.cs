using System;
using System.Windows.Input;
using HotelManagement.Core;

namespace HotelManagement.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ICommand DashboardViewCommand { get; set; }

        public ICommand BookingsViewCommand { get; set; }

        public ICommand RoomsViewCommand { get; set; }

        public DashboardViewModel HomeVM { get; set; }

        public BookingsViewModel BookingsVM { get; set; }

        public RoomsViewModel RoomsVM { get; set; }

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
            HomeVM = new DashboardViewModel();
            BookingsVM = new BookingsViewModel();
            RoomsVM = new RoomsViewModel();
            
            CurrentView = HomeVM;

            DashboardViewCommand = new RelayCommand<object>((o) =>
            {
                return true;
            }, (o) =>
            {
                CurrentView = HomeVM; 
            });

            BookingsViewCommand = new RelayCommand<object>((o) =>
            {
                return true;
            }, (o) => 
            { 
                CurrentView = BookingsVM; 
            });

            RoomsViewCommand = new RelayCommand<object>((o) =>
            {
                return true;
            }, (o) =>
            { 
                CurrentView = RoomsVM; 
            });
        }
    }
}

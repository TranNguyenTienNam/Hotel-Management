using System;
using System.Windows.Input;
using HotelManagement.Core;

namespace HotelManagement.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ICommand HomeViewCommand { get; set; }

        public ICommand BookingsViewCommand { get; set; }

        public ICommand RoomsViewCommand { get; set; }

        public DashboardViewModel HomeVM { get; set; }

        public BookingViewModel BookingsVM { get; set; }

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
            BookingsVM = new BookingViewModel();
            RoomsVM = new RoomsViewModel();
            
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand<object>((o) =>
            {
                return true;
            }, (o) =>
            { CurrentView = HomeVM; });

            BookingsViewCommand = new RelayCommand<object>((o) =>
            {
                return true;
            }, (o) => 
            { CurrentView = BookingsVM; });

            RoomsViewCommand = new RelayCommand<object>((o) =>
            {
                return true;
            }, (o) =>
            { CurrentView = RoomsVM; });
        }
    }
}

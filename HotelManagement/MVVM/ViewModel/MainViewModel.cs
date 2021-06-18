using System;
using HotelManagement.Core;

namespace HotelManagement.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand DashboardViewCommand { get; set; }

        public RelayCommand BookingsViewCommand { get; set; }

        public RelayCommand RoomsViewCommand { get; set; }

        public DashboardViewModel DashboardVM { get; set; }

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
            DashboardVM = new DashboardViewModel();
            BookingsVM = new BookingsViewModel();
            RoomsVM = new RoomsViewModel();
            
            CurrentView = DashboardVM;

            DashboardViewCommand = new RelayCommand(o => 
            {
                CurrentView = DashboardVM;
            });

            BookingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = BookingsVM;
            });

            RoomsViewCommand = new RelayCommand(o =>
            {
                CurrentView = RoomsVM;
            });
        }
    }
}

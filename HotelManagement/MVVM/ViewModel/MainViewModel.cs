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

        public ICommand CheckOutViewCommand { get; set; }

        public DashboardViewModel DashboardVM { get; set; }

        public BookingsViewModel BookingsVM { get; set; }

        public RoomsViewModel RoomsVM { get; set; }

        public CheckOutViewModel CheckOutVM { get; set; }

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
            CheckOutVM = new CheckOutViewModel();
            
            CurrentView = DashboardVM;

            DashboardViewCommand = new RelayCommand<object>((o) =>
            {
                return true;
            }, (o) => { CurrentView = DashboardVM; });

            BookingsViewCommand = new RelayCommand<object>((o) =>
            {
                return true;
            }, (o) => { CurrentView = BookingsVM; });

            RoomsViewCommand = new RelayCommand<object>((o) =>
            {
                return true;
            }, (o) => { CurrentView = RoomsVM; });

            CheckOutViewCommand = new RelayCommand<object>((o) =>
            {
                return true;
            }, (o) => { CurrentView = CheckOutVM; });
        }
    }
}

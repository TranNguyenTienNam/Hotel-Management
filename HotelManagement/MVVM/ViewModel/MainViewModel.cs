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

        public ICommand StaffViewCommand { get; set; }

        //Button New Booking
        public ICommand NewBookingCommand { get; set; }

        public DashboardViewModel DashboardVM { get; set; }

        public BookingViewModel BookingsVM { get; set; }

        public RoomsViewModel RoomsVM { get; set; }

        public StaffViewModel StaffVM { get; set; }

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
            BookingsVM = new BookingViewModel();
            RoomsVM = new RoomsViewModel();
            StaffVM = new StaffViewModel();

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

            NewBookingCommand = new RelayCommand<object>((o) =>
            {
                return true;
            }, (o) =>
            {
                BookingWindows wd = new BookingWindows();
                wd.ShowDialog();
            });

            StaffViewCommand = new RelayCommand<object>((o) =>
            {
                return true;
            }, (o) => { CurrentView = StaffVM; });
        }
    }
}

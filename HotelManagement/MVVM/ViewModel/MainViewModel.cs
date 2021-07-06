using System;
using System.Windows;
using System.Windows.Input;
using HotelManagement.Core;
using HotelManagement.MVVM.Model;

namespace HotelManagement.MVVM.ViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class MainViewModel : ObservableObject
    {
        //Content of Chip card
        private string _nameContent;
        public string NameContent { get { return _nameContent; } set { _nameContent = value; OnPropertyChanged(); } }

        /// <summary>
        /// Permission of Account: 
        /// 0 => master(admin)
        /// 1 => Manager
        /// 2 => Staff
        /// </summary>
        int PermissionOfAccount { get; set; }

        public ICommand DashboardViewCommand { get; set; }

        public ICommand BookingsViewCommand { get; set; }

        public ICommand RoomsViewCommand { get; set; }

        //Button New Booking
        public ICommand NewBookingCommand { get; set; }

        public DashboardViewModel DashboardVM { get; set; }

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

        public MainViewModel(int UserId)
        {
            DashboardVM = new DashboardViewModel();
            BookingsVM = new BookingViewModel();
            RoomsVM = new RoomsViewModel();
            MainModel model = new MainModel();

            PermissionOfAccount = model.GetPermissionAccount(UserId);
            NameContent = model.GetNameAccount(UserId);
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
        }
    }
}

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

        //Collapse the button according to the permission
        private string _visibility;
        public string Visibility { get { return _visibility; } set { _visibility = value; OnPropertyChanged(); } }

        //Button New Booking
        public ICommand NewBookingCommand { get; set; }

        #region View and Command Binding

        public ICommand DashboardViewCommand { get; set; }

        public ICommand BookingsViewCommand { get; set; }

        public ICommand RoomsViewCommand { get; set; }

        public ICommand ProfileViewCommand { get; set; }
        
        public ICommand CheckOutViewCommand { get; set; }

        public DashboardViewModel DashboardVM { get; set; }

        public NewBookingViewModel BookingsVM { get; set; }

        public RoomsViewModel RoomsVM { get; set; }

        public ProfileViewModel ProfileVM { get; set; }

        public CheckOutViewModel CheckOutVM { get; set; }
        #endregion

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
            MainModel model = new MainModel();
            DashboardVM = new DashboardViewModel();
            BookingsVM = new NewBookingViewModel();
            RoomsVM = new RoomsViewModel();
            CheckOutVM = new CheckOutViewModel();
            
            ProfileVM = new ProfileViewModel(UserId);

            //Chưa phân quyền
            PermissionOfAccount = model.GetPermissionAccount(UserId);
            if (PermissionOfAccount == 2)
            {
                NameContent = model.GetNameAccount(UserId);
                Visibility = "Collapsed";
            }    
            else if (PermissionOfAccount == 1)
            {
                
            }    
            else
            {
                NameContent = "Admin";
            }    

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

            ProfileViewCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => { CurrentView = ProfileVM; });

            CheckOutViewCommand = new RelayCommand<object>((o) =>
            {
                return true;
            }, (o) => { CurrentView = CheckOutVM; });

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

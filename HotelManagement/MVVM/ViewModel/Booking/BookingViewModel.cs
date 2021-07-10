using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.MVVM.Model;
using System.Data;
using HotelManagement.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media;
using System.Text.RegularExpressions;

namespace HotelManagement.MVVM.ViewModel
{
    /// <summary>
    /// Interaction logic for BookingsView.xaml
    /// </summary>
    class BookingViewModel : ObservableObject
    {
        #region List Booking Element
        private ObservableCollection<BookingItemViewModel> _items;
        public ObservableCollection<BookingItemViewModel> Items { get { return _items; } set { _items = value; OnPropertyChanged(); } }

        //Item of combobox Search
        private string _itemSearchSelected;
        public string ItemSearchSelected { get { return _itemSearchSelected; } set { _itemSearchSelected = value; OnPropertyChanged(); } }

        /// <summary>
        /// Collapsed, Hidden, Visible
        /// </summary>
        //Visibility of Check-in Now Button
        private string _visibilityCheckinNow;
        public string VisibilityCheckinNow { get { return _visibilityCheckinNow; } set { _visibilityCheckinNow = value; OnPropertyChanged(); } }
        
        //Visibility of Save, Delete Button
        private string _visibilityEdit;
        public string VisibilityEdit { get { return _visibilityEdit; } set { _visibilityEdit = value; OnPropertyChanged(); } }
        
        public ICommand ToggleButtonClickCommand { get; set; }
        #endregion

        #region Checkin and Edit Information
        #region Client
        private string _clientName;
        public string ClientName { get { return _clientName; } set { _clientName = value; OnPropertyChanged(); } } 
        
        private string _idCardNumber;
        public string IdCardNumber { get { return _idCardNumber; } set { _idCardNumber = value; OnPropertyChanged(); } }
        
        private string _nationality;
        public string Nationality { get { return _nationality; } set { _nationality = value; OnPropertyChanged(); } }

        private string _phone;
        public string Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(); } }

        private string _gender;
        public string Gender { get { return _gender; } set { _gender = value; OnPropertyChanged(); } }
        
        private string _address;
        public string Address { get { return _address; } set { _address = value; OnPropertyChanged(); } }
        #endregion

        //readonly of textbox
        private bool _isReadOnly;
        public bool IsReadOnly { get { return _isReadOnly; } set { _isReadOnly = value; OnPropertyChanged(); } }

        //enable of combobox
        private bool _isEnabled;
        public bool IsEnabled { get { return _isEnabled; } set { _isEnabled = value; OnPropertyChanged(); } }
        #endregion

        public BookingViewModel()
        {
            Items = new ObservableCollection<BookingItemViewModel>();

            initProperty();
            LoadBooking();

            /// <summary>
            /// ChangePasswordCommand have 8 parameter (object[])
            /// 0 => <include file='BookingsView.xaml' path='[@ElementName="tgbtMode"]' type='ToggleButton'/>
            /// 1 => <include file='BookingsView.xaml' path='[@ElementName="cbbGender"]' type='ComboBox'/>
            /// 2 => <include file='BookingsView.xaml' path='[@ElementName="cbbNationality"]' type='ComboBox'/>
            /// 3 => <include file='BookingsView.xaml' path='[@ElementName="tbName"]' type='TextBox'/>
            /// 4 => <include file='BookingsView.xaml' path='[@ElementName="tbPhone"]' type='TextBox'/>
            /// 5 => <include file='BookingsView.xaml' path='[@ElementName="tbAddress"]' type='TextBox'/>
            /// 6 => <include file='BookingsView.xaml' path='[@ElementName="tbDeposit"]' type='TextBox'/>
            /// 7 => <include file='BookingsView.xaml' path='[@ElementName="tbAmountPeople"]' type='TextBox'/>
            /// </summary>
            ToggleButtonClickCommand = new RelayCommand<object[]>((p) =>
            {
                return true;
            }, (p) =>
            {
                ToggleButton tgbtMode = p[0] as ToggleButton;
                Brush orange = (Brush)new BrushConverter().ConvertFrom("#FE8704");
                Brush gray = (Brush)new BrushConverter().ConvertFrom("#878786");

                if (tgbtMode.IsChecked == true)    //Edit mode
                {
                    VisibilityCheckinNow = "Collapsed";
                    VisibilityEdit = "Visible";
                    IsReadOnly = false;
                    IsEnabled = true;
                    changeColorControl(p, orange, orange);
                }
                else                        //Check-in mode
                {
                    VisibilityCheckinNow = "Visible";
                    VisibilityEdit = "Collapsed";
                    IsReadOnly = true;
                    IsEnabled = false;
                    changeColorControl(p, Brushes.Red, gray);
                }
            });
        }

        void initProperty()
        {
            //Check-in mode
            VisibilityCheckinNow = "Visible";
            VisibilityEdit = "Collapsed";
            IsReadOnly = true;
            IsEnabled = false;
        }

        void LoadBooking()
        {
            if (Items.Count > 0)
                Items.Clear();

            BookingListModel model = new BookingListModel();
            DataTable data = new DataTable();
            data = model.Load_On();

            foreach (DataRow row in data.Rows)
            {
                var obj = new BookingItemViewModel()
                {
                    MaPhieuThue = (int)row["MaPhieuThue"],
                    MaPhong = (int)row["MaPhong"],
                    CMND = (string)row["CMND"],
                    NgayBatDau = (DateTime)row["NgayBatDau"],
                    NgayLapPhieu = (DateTime)row["NgayLapPhieu"],
                    TienCoc = (int)row["TienCoc"],
                    TenKH = (string)row["TenKH"],
                    SoDienThoai = (string)row["SoDienThoai"],
                };
                Items.Add(obj);
            }
        }

        #region View Event Handling

        //Không nhận ký tự khác ngoài số khi nhập textbox
        public void PreviewTextInputViewModel(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        #endregion

        //References by ToggleButtonClickCommand
        void changeColorControl(object[] p, Brush foreground, Brush borderBrush)
        {
            ComboBox cbbGender = p[1] as ComboBox;
            ComboBox cbbNationality = p[2] as ComboBox;
            TextBox tbName = p[3] as TextBox;
            TextBox tbPhone = p[4] as TextBox;
            TextBox tbAddress = p[5] as TextBox;
            TextBox tbDeposit = p[6] as TextBox;
            TextBox tbAmountPeople = p[7] as TextBox;

            cbbGender.Foreground = foreground;
            cbbGender.BorderBrush = borderBrush;
            cbbNationality.Foreground = foreground;
            cbbNationality.BorderBrush = borderBrush;
            tbName.Foreground = foreground;
            tbName.BorderBrush = borderBrush;
            tbPhone.Foreground = foreground;
            tbPhone.BorderBrush = borderBrush;
            tbAddress.Foreground = foreground;
            tbAddress.BorderBrush = borderBrush;
            tbDeposit.Foreground = foreground;
            tbDeposit.BorderBrush = borderBrush;
            tbAmountPeople.Foreground = foreground;
            tbAmountPeople.BorderBrush = borderBrush;
        }
    }
}

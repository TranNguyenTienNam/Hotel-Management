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
using System.Windows;

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
        public ICommand ListViewSelectionChangedCommand { get; set; }
        #endregion

        #region Checkin and Edit Information
        #region Client Information
        private string _clientName;
        public string ClientName { get { return _clientName; } set { _clientName = value; OnPropertyChanged(); } } 
        
        private string _idCardNumber;
        public string IdCardNumber { get { return _idCardNumber; } set { _idCardNumber = value; OnPropertyChanged(); } }

        private List<string> _listNationality;
        public List<string> ListNationality { get { return _listNationality; } set { _listNationality = value; OnPropertyChanged(); } }

        private string _nationality;
        public string Nationality { get { return _nationality; } set { _nationality = value; OnPropertyChanged(); } }

        private string _phone;
        public string Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(); } }

        private List<string> _listGender;
        public List<string> ListGender { get { return _listGender; } set { _listGender = value; OnPropertyChanged(); } }

        private string _gender;
        public string Gender { get { return _gender; } set { _gender = value; OnPropertyChanged(); } }
        
        private string _address;
        public string Address { get { return _address; } set { _address = value; OnPropertyChanged(); } }
        #endregion

        #region Rental Information
        private string _roomId;
        public string RoomId { get { return _roomId; } set { _roomId = value; OnPropertyChanged(); } }
        
        private string _roomType;
        public string RoomType { get { return _roomType; } set { _roomType = value; OnPropertyChanged(); } }
        
        private int _price;
        public int Price { get { return _price; } set { _price = value; OnPropertyChanged(); } }
        
        private int _deposit;
        public int Deposit { get { return _deposit; } set { _deposit = value; OnPropertyChanged(); } }
        
        private DateTime _createDate;
        public DateTime CreateDate { get { return _createDate; } set { _createDate = value; OnPropertyChanged(); } }

        private int _amountPeople;
        public int AmountPeople { get { return _amountPeople; } set { _amountPeople = value; OnPropertyChanged(); } }

        private string _creator;
        public string Creator { get { return _creator; } set { _creator = value; OnPropertyChanged(); } }
        
        private DateTime _checkInDate;
        public DateTime CheckInDate { get { return _checkInDate; } set { _checkInDate = value; OnPropertyChanged(); } }
        
        private DateTime _checkOutDate;
        public DateTime CheckOutDate { get { return _checkOutDate; } set { _checkOutDate = value; OnPropertyChanged(); } }
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

            ListViewSelectionChangedCommand = new RelayCommand<ListView>((p) =>
            {
                return !p.Items.IsEmpty;
            }, (p) => 
            {
                var values = p.SelectedItem as BookingItemViewModel;
                loadClientInformation(values.CMND, values.TenKH);
                loadRentalInformation(values.MaPhieuThue, values.NgayLapPhieu, values.NgayBatDau, values.TienCoc);
            });
        }

        void initProperty()
        {
            Items = new ObservableCollection<BookingItemViewModel>();
            ListNationality = new List<string>();
            ListNationality.Add("Viet Nam");
            ListNationality.Add("Foreign");
            ListGender = new List<string>();
            ListGender.Add("Male");
            ListGender.Add("Female");
            ListGender.Add("Other");
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
            data = model.LoadBooking();

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

        void loadClientInformation(string CMND, string TenKhachHang)
        {
            BookingListModel model = new BookingListModel();
            DataTable data = new DataTable();
            data = model.LoadClientInformation(CMND);

            DataRow row = data.Rows[0];

            ClientName = TenKhachHang;
            IdCardNumber = CMND;
            Nationality = (string)row["TenLoaiKhach"];
            Phone = (string)row["SoDienThoai"];
            Gender = (string)row["GioiTinh"];
            Address = (string)row["DiaChi"];
        }

        void loadRentalInformation(int MaPhieuThue, DateTime createDate, DateTime checkInDate, int deposit)
        {
            BookingListModel model = new BookingListModel();
            DataTable data = new DataTable();
            data = model.LoadRentalInformation(MaPhieuThue);

            DataRow row = data.Rows[0];

            RoomId = row["MaPhong"].ToString();
            RoomType = (string)row["TenLoaiPhong"];
            Price = (int)row["DonGia"];
            AmountPeople = (int)row["SoLuongKhach"];
            CheckOutDate = (DateTime)row["NgayTraPhong"];
            Creator = ((row["Ten"] == DBNull.Value) ? "" : (string)row["Ten"]) + " (" + row["MaNgDung"].ToString() + ")";
            CreateDate = createDate;
            CheckInDate = checkInDate;
            Deposit = deposit;
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

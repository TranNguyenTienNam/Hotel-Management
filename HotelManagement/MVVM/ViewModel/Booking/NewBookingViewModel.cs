/*
 * BookingViewModel Class
 *
 * v1.0
 *
 * 2021-07-10
 * 
 * Copyright (c) 2020-2021 UIT Team.
 */

using System;
using System.Collections.Generic;
using HotelManagement.Core;
using System.Data;
using HotelManagement.MVVM.Model;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;


namespace HotelManagement.MVVM.ViewModel
{
    /// <summary>
    /// BookingViewModel Class dùng để xử lý dữ liệu và các sự kiện ở cửa sở đặt phòng.
    /// </summary>
    public class NewBookingViewModel : ObservableObject
    {
        private ObservableCollection<NewBookingRoomItemViewModel> _items = new ObservableCollection<NewBookingRoomItemViewModel>();
        public ObservableCollection<NewBookingRoomItemViewModel> Items { get { return _items; } set { _items = value; OnPropertyChanged(); } }

        #region Info New Booking

        //Checkin and Checkout Date
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }

        //RoomID
        private int _id;
        public int RoomId { get { return _id; } set { _id = value; OnPropertyChanged(); } }

        //Phone
        private string _phone;
        public string Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(); } }

        //Nationaly ( Client Type)
        private string _nation;
        public string Nation { get { return _nation; } set { _nation = value; OnPropertyChanged(); } }

        //Name cllient
        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }

        //Gender
        private string _gender;
        public string Gender { get { return _gender; } set { _gender = value; OnPropertyChanged(); } }

        //Deposit booking
        private string _deposit;
        public string Deposit { get { return _deposit; } set { _deposit = value; OnPropertyChanged(); } }

        //Client ID
        private string _citizenID;
        public string CitizenID { get { return _citizenID; } set { _citizenID = value; OnPropertyChanged(); } }

        //Address 
        private string _address;
        public string Address { get { return _address; } set { _address = value; OnPropertyChanged(); } }

        //Amout People/Room
        private string _amount;
        public string Amount { get { return _amount; } set { _amount = value; OnPropertyChanged(); } }

        // Status Booked/Checkin
        private string _status;
        public string Status { get { return _status; } set { _status = value; OnPropertyChanged(); } }

        #endregion 

        #region Invalid textblock bottom textbox
        private string _invalidCheckin;
        public string InvalidCheckin { get { return _invalidCheckin; } set { _invalidCheckin = value; OnPropertyChanged(); } }
        
        private string _invalidCheckout;
        public string InvalidCheckout { get { return _invalidCheckout; } set { _invalidCheckout = value; OnPropertyChanged(); } }

        private string _invalidRoom;
        public string InvalidRoom { get { return _invalidRoom; } set { _invalidRoom = value; OnPropertyChanged(); } }

        private string _invalidName;
        public string InvalidName { get { return _invalidName; } set { _invalidName = value; OnPropertyChanged(); } }

        private string _invalidPhone;
        public string InvalidPhone { get { return _invalidPhone; } set { _invalidPhone = value; OnPropertyChanged(); } }

        private string _invalidCitizenID;
        public string InvalidCitizenID { get { return _invalidCitizenID; } set { _invalidCitizenID = value; OnPropertyChanged(); } } 

        private string _checkCitizent;
        public string CheckCitizent { get { return _checkCitizent; } set { _checkCitizent = value; OnPropertyChanged(); } }

        private string _invalidGender;
        public string InvalidGender { get { return _invalidGender; } set { _invalidGender = value; OnPropertyChanged(); } }

        private string _invalidAddress;
        public string InvalidAddress { get { return _invalidAddress; } set { _invalidAddress = value; OnPropertyChanged(); } }

        private string _invalidNationality;
        public string InvalidNationality { get { return _invalidNationality; } set { _invalidNationality = value; OnPropertyChanged(); } }

        private string _invalidDeposit;
        public string InvalidDeposit { get { return _invalidDeposit; } set { _invalidDeposit = value; OnPropertyChanged(); } }

        private string _invalidAmount;
        public string InvalidAmount { get { return _invalidAmount; } set { _invalidAmount = value; OnPropertyChanged(); } }

        private string _invalidStatus;
        public string InvalidStatus { get { return _invalidStatus; } set { _invalidStatus = value; OnPropertyChanged(); } }
        #endregion

        #region Some funcition
        // Numberic Textbok funcition 
        public void IsAllowedInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        //Funcition check valid client info
        bool IsValidInfo()
        {
             int i=0;
            if (string.IsNullOrEmpty(Name)) { InvalidName = "Please enter deposit!"; i++; }
            else
            {
                InvalidName = "";
            }

            if (string.IsNullOrEmpty(CitizenID)){ InvalidCitizenID = "Please enter citizen Id!"; i++;  }
            else
            {
                InvalidCitizenID = "";
            }

            if (string.IsNullOrEmpty(Phone)) { InvalidPhone = "Please enter phone number! "; i++;  }
            else
            {
                InvalidPhone = "";
            }

            if (string.IsNullOrEmpty(Gender)) { InvalidGender = "Please choose gender!"; i++;  }
            else
            {
                InvalidGender = "";
            }

            if (string.IsNullOrEmpty(Nation)) { InvalidNationality = "Please choose nationality!"; i++;  }
            else
            {
                InvalidNationality = "";
            }

            if (string.IsNullOrEmpty(Deposit)) { InvalidDeposit = "Please enter deposit!"; i++;  }
            else
            {
                InvalidDeposit = "";
            }

            if (string.IsNullOrEmpty(Amount)) { InvalidAmount = "Please enter the amount!"; i++; }
            else
            {
                InvalidAmount = "";
            }
            
            if (string.IsNullOrEmpty(Status)) { InvalidStatus = "Please choose status!"; i++;  }
            else
            {
                InvalidStatus = "";
            }

            if (i == 0) return true;
            return false;
        }

        // Handle invalid condition when date pick
        void HandleValidDatePick(DateTime _checkin , DateTime _checkout)
        {
            if (DateTime.Compare(DateTime.Today, _checkin) > 0
                     && _checkin.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
            {
                InvalidCheckin = "Check-in date must be later than or same today";
            }
            else InvalidCheckin = "";
            if (DateTime.Compare(_checkin, _checkout) > 0
                    && _checkout.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00") 
            {
                InvalidCheckout = "Check-out date must be later than or same as check-in and today";
            }
            else InvalidCheckout = "";

            if ((_checkout.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00") 
                    && (_checkin.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00"))
                loadListRoom(checkin, checkout);
            if (!(string.IsNullOrEmpty(InvalidCheckout) &&
                    string.IsNullOrEmpty(InvalidCheckin)))
                Items.Clear();
        }

        //Clear White Space in Numberic
        void ClearWhiteSpace()
        {
            if (!string.IsNullOrEmpty(CitizenID)) CitizenID = Regex.Replace(CitizenID, @"\s+", "");
            if(!string.IsNullOrEmpty(Phone)) Phone = Regex.Replace(Phone, @"\s+", "");
            if (!string.IsNullOrEmpty(Deposit)) Deposit = Regex.Replace(Deposit, @"\s+", "");
            if (!string.IsNullOrEmpty(Amount)) Amount = Regex.Replace(Amount, @"\s+", "");
        }

        //Load list room according to check-in date and check-out date
        void loadListRoom(DateTime _checkin, DateTime _checkout)
        {

            if (Items.Count > 0)
                Items.Clear();
            NewBookingModel model = new NewBookingModel();
            DataTable data = new DataTable();
            data = model.LoadAvailableRoom(_checkin.ToString("yyyy-MM-dd HH:mm:ss"),
                                    _checkout.ToString("yyyy-MM-dd HH:mm:ss"));

            foreach (DataRow row in data.Rows)
            {
                var obj = new NewBookingRoomItemViewModel()
                {
                    MaPhong = (int)row["MaPhong"],
                    TenPhong = (string)row["TenPhong"],
                    LoaiPhong = (string)row["TenLoaiPhong"],
                    DonGia = (int)row["DonGia"],
                    SoNgToiDa = (int)row["SoNgToiDa"],
                    GhiChu = (row["GhiChu"] != null) ? string.Empty : (string)row["GhiChu"]
                };
                Items.Add(obj);
            }
        }
        #endregion


        //Declare ICommand: handle event in View.
        #region Icommand
        public ICommand CheckOutDate { get; set; }
        public ICommand CheckInDate { get; set; }
        public ICommand SelectedListViewCommand { get; set; }
        public ICommand HandleBooking { get; set; }
        public ICommand HandleCheck { get; set; }
        public ICommand GenderChanged { get; set; }
        public ICommand StatusChanged { get; set; }
        public ICommand NationalityChanged { get; set; }
        public ICommand CitizentIdTextChange { get; set; }

        #endregion


       /// <summary>
       /// NewBookingViewModel load view for New Booking Windows
       /// </summary>
       /// <param name="UserID"></param>
        public NewBookingViewModel(int UserID)
        {
            NewBookingModel model = new NewBookingModel();
            DateTime today = DateTime.Today;
            DateTime tomorow = DateTime.Today.AddDays(+1);
            loadListRoom(today, tomorow);

            #region Handle Event

            CitizentIdTextChange = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
             {
                 CheckCitizent = "";
             });

            GenderChanged = new RelayCommand<ComboBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                var item = (ComboBoxItem)p.SelectedValue;
                var content = (string)item.Content;
                Gender = content;
            });

            StatusChanged = new RelayCommand<ComboBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                var item = (ComboBoxItem)p.SelectedValue;
                var content = (string)item.Content;
                Status = content;
            });

            NationalityChanged = new RelayCommand<ComboBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                var item = (ComboBoxItem)p.SelectedValue;
                var content = (string)item.Content;
                Nation = content;
            });

            CheckOutDate = new RelayCommand<DatePicker>((p) =>
            {
                return true;
            }, (p) =>
            {
                RoomId = 0;
                checkout = p.SelectedDate.Value;
                HandleValidDatePick(checkin, checkout);
            });

            CheckInDate = new RelayCommand<DatePicker>((p) =>
            {
                return true;
            }, (p) =>
            {
                RoomId = 0;
                checkin = p.SelectedDate.Value;
                HandleValidDatePick(checkin, checkout);
            });

            SelectedListViewCommand = new RelayCommand<ListView>((p) =>
            {
                return !p.Items.IsEmpty;

            }, (p) =>
            {
                var Item = p.SelectedItem as NewBookingRoomItemViewModel;
                RoomId = Item.MaPhong;

            });

            HandleCheck = new RelayCommand<object[]>((p) =>
            {
                if (string.IsNullOrEmpty(CitizenID) 
                     || CheckCitizent == "✔️") return false;
                return true;
            }, (p) =>
            {
                var value = (object[])p;
                var cbbGender = (ComboBox)value[0];
                var cbbNationlity = (ComboBox)value[1];
                ClearWhiteSpace();
                DataTable data = new DataTable();
                data = model.CheckInfo(CitizenID);
                if (data.Rows.Count == 0) { return; }
                else { CheckCitizent = "✔️"; } ;
                foreach (DataRow row in data.Rows)
                {
                    Name = (string)row["TenKH"];
                    Phone = (string)row["SoDienThoai"];
                    Address = (string)row["DiaChi"];
                    Gender = (string)row["GioiTinh"];
                    cbbNationlity.SelectedIndex = (int)row["MaLoaiKhach"] - 1;
                }
                if (Gender == "Male") { cbbGender.SelectedIndex = 0; return; };
                if (Gender == "Female") cbbGender.SelectedIndex = 1;
                else { cbbGender.SelectedIndex = 2; }                     
            });

            HandleBooking = new RelayCommand<object>((p) =>
            {
                if (checkout.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00" || (RoomId == 0)
                        || checkin.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00" )
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                ClearWhiteSpace();
                if (!IsValidInfo()) { 
                    return; 
                };
                int _nation = 2;
                if (Nation == "Other") _nation = 1;
                DateTime now = DateTime.Now;
                try
                {
                    if (model.Save_Client(Name, _nation, CitizenID, Phone, Address, Gender) &&
                        model.Save_Booking(RoomId, CitizenID, now.ToString("yyyy-MM-dd HH:mm:ss"),
                        checkin.ToString("yyyy-MM-dd HH:mm:ss"), checkout.ToString("yyyy-MM-dd HH:mm:ss"),
                        Amount, Status, UserID, Deposit)) {
                        MessageBox.Show("Booking Created","Notify");
                    }
                    RoomId = 0;
                    loadListRoom(checkin,checkout);
                }
                catch
                {
                    model.Update_Client(Name, _nation, CitizenID, Phone, Address, Gender);

                    if (model.Save_Booking(RoomId, CitizenID, now.ToString("yyyy-MM-dd HH:mm:ss"),
                        checkin.ToString("yyyy-MM-dd HH:mm:ss"),checkout.ToString("yyyy-MM-dd HH:mm:ss"),
                        Amount, Status, UserID, Deposit))
                    {
                        MessageBox.Show("Booking Created", "Notify");
                    }
                    RoomId = 0;
                    loadListRoom(checkin, checkout);
                }
            });
 
        }        
        #endregion
    }
}


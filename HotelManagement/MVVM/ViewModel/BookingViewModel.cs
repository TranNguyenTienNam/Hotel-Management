/*
 * BookingViewModel Class
 *
 * v1.0
 *
 * 2011-11-29
 * 
 * Copyright (c) 1994-1999 UIT Team.
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
    public class BookingViewModel : ObservableObject
    {

        public static BookingViewModel Insance => new BookingViewModel();

        

        private ObservableCollection<BookRoomItemViewModel> _items = new ObservableCollection<BookRoomItemViewModel>();
        public ObservableCollection<BookRoomItemViewModel> Items { get { return _items; } set { _items = value; OnPropertyChanged(); } }

        #region Biến
        public int CreatorID = 1000;

        //RoomID
        private int _id;
        public int RoomId { get { return _id; } set { _id = value; OnPropertyChanged(); } }


        //Phone
        private int _phone;
        public int Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(); } }


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
        private int _deposit;
        public int Deposit { get { return _deposit; } set { _deposit = value; OnPropertyChanged(); } }

        //Client ID
        private int _citizenID;
        public int CitizenID { get { return _citizenID; } set { _citizenID = value; OnPropertyChanged(); }   }
        
        //Address 
        private string _address;
        public string Address { get { return _address; } set { _address = value; OnPropertyChanged(); } }

        //Amout People/Room
        private int _amount;
        public int Amount { get { return _amount; } set { _amount = value; OnPropertyChanged(); } }

        // Status Booked/Checkin
        private string _status;
        public string Status { get { return _status; } set { _status = value; OnPropertyChanged(); } }

        #endregion
        // Numberic Textbok funcition 
        public void IsAllowedInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// ICommand handle event in View.
        /// </summary>
        #region Icommand
        public ICommand CheckOutDate { get; set; }
        public ICommand CheckInDate { get; set; }
        public ICommand SelectedChangedCommand { get; set; }
        public ICommand HandleBooking { get; set; }
        public ICommand GenderChanged { get; set; }
        public ICommand StatusChanged { get; set; }
        public ICommand NationalityChanged { get; set; }
        public ICommand HandleOnlyNumber { get; set; }
        #endregion
        //Checkin and Checkout Date
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }

        //BookingView Method
        public BookingViewModel()
        {
            DateTime today = DateTime.Today;
            DateTime tomorow = DateTime.Today.AddDays(+1);
            loadListRoom(today,tomorow);

            #region Handle
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
                if (checkin.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
                     loadListRoom(checkin, checkout);
            });

            CheckInDate = new RelayCommand<DatePicker>((p) =>
            {
                return true;
            }, (p) =>
            {
                RoomId = 0;
                checkin = p.SelectedDate.Value;
                if (checkout.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00") 
                      loadListRoom(checkin, checkout);
            });

            SelectedChangedCommand = new RelayCommand<ListView>((p) =>
            {
                return true;
            }, (p) =>
            {
                var Item = p.SelectedItem as BookRoomItemViewModel;
                RoomId = Item.MaPhong;
            });
            #endregion
            HandleBooking = new RelayCommand<object>((p) =>
            {

                if ((Deposit == 0)||(Amount == 0)||(RoomId == 0)||(CitizenID == 0)||(Phone == 0)
                        || string.IsNullOrEmpty(Gender) || string.IsNullOrEmpty(Address)
                        || string.IsNullOrEmpty(Nation) || string.IsNullOrEmpty(Name)
                        || string.IsNullOrEmpty(Status) || checkout.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00"
                        || checkin.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00" ) {  
                    return false;
                }             
                return true;
            }, (p) =>
            {
                int ination = 2;
                if (Nation == "Other") ination = 1;
                //MessageBox.Show(checkin,"Nhận phòng");
                //MessageBox.Show( checkout,"Trả phòng");

                BookingRoomModel md = new BookingRoomModel();
                int i = md.Save_Client(Name,ination, CitizenID, Phone, Address, "Nam");
                if (i != 0)
                {
                    MessageBox.Show("Client Created","Notify");
                };

                DateTime now = DateTime.Now;
                #region Test
                //MessageBox.Show(now.ToString("yyyy-MM-dd HH:mm:ss"));
                //MessageBox.Show(CitizenID.ToString(),"CitizenID:");
                //MessageBox.Show(Phone.ToString(),"Phone:");
                //MessageBox.Show(Amount.ToString(),"Amount:");
                //MessageBox.Show(Deposit.ToString(),"Deposit:");
                #endregion
                if (md.Save_Booking(RoomId,i,now.ToString("yyyy-MM-dd HH:mm:ss"),checkin.ToString("yyyy-MM-dd HH:mm:ss"),
                                    checkout.ToString("yyyy-MM-dd HH:mm:ss"), Amount,Status,CreatorID,Deposit)) 
                {
                    MessageBox.Show("Booking Created","Notify");
                }
            })
            {

            };
        }


        //Load table room
        void loadListRoom(DateTime _checkin, DateTime _checkout )
        {
         
            if (Items.Count > 0)
                Items.Clear();
            BookingRoomModel model = new BookingRoomModel();
            DataTable data = new DataTable();
            data = model.Load_On(_checkin.ToString("yyyy-MM-dd HH:mm:ss"),
                                    _checkout.ToString("yyyy-MM-dd HH:mm:ss"));
                
            foreach (DataRow row in data.Rows)
            {
                var obj = new BookRoomItemViewModel()
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
    }
}


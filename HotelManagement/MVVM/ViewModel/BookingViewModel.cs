using HotelManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core;
using System.Data;
using HotelManagement.MVVM.Model;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;

namespace HotelManagement.MVVM.ViewModel
{
    public class BookingViewModel : ObservableObject
    {
        public static BookRoomItemViewModel Insance => new BookRoomItemViewModel();
        public List<BookRoomItemViewModel> Items { get; set; }

        public int CreatorID = 1000;

        private int _id;
        public int RoomId { get { return _id; } set { _id = value; OnPropertyChanged(); } }


        private int _phone;
        public int Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(); } }


        private string _nation;
        public string Nation { get { return _nation; } set { _nation = value; OnPropertyChanged(); } }


        private string _name;
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(); } }


        private string _gender;
        public string Gender { get { return _gender; } set { _gender = value; OnPropertyChanged(); } }


        private int _deposit;
        public int Deposit { get { return _deposit; } set { _deposit = value; OnPropertyChanged(); } }


        
        private int _citizenID;
        public int CitizenID { get { return _citizenID; } set { _citizenID = value; OnPropertyChanged(); }   }
        
        private string _address;
        public string Address { get { return _address; } set { _address = value; OnPropertyChanged(); } }


        private int _amount;
        public int Amount { get { return _amount; } set { _amount = value; OnPropertyChanged(); } }

        private string _status;
        public string Status { get { return _status; } set { _status = value; OnPropertyChanged(); } }

        public ICommand CheckOutDate { get; set; }
        public ICommand CheckInDate { get; set; }
        public ICommand SelectedChangedCommand { get; set; }
        public ICommand HandleBooking { get; set; }
        public ICommand GenderChanged { get; set; }
        public ICommand StatusChanged { get; set; }
        public ICommand NationalityChanged { get; set; }

        public string checkout { get; set; }
        public string checkin { get; set; }

        public BookingViewModel()
        {
            loadListRoom();


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
                checkout = p.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            });

            CheckInDate = new RelayCommand<DatePicker>((p) =>
            {
                return true;
            }, (p) =>
            {
                checkin = p.SelectedDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            });

            SelectedChangedCommand = new RelayCommand<ListView>((p) =>
            {
                return true;
            }, (p) =>
            {
                var Item = p.SelectedItem as BookRoomItemViewModel;
                RoomId = Item.MaPhong;
            });

            HandleBooking = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                int ination = 2;
                if (Nation == "Other") ination = 1;
                MessageBox.Show(checkin,"Nhận phòng");
                MessageBox.Show( checkout,"Trả phòng");

                BookingRoomModel md = new BookingRoomModel();
                int i = md.Save_Client(Name, ination, CitizenID, Phone, Address, "Nam");
                if (i != 0)
                {
                    MessageBox.Show(i.ToString());
                };

                DateTime now = DateTime.Now;
                MessageBox.Show(now.ToString("yyyy-MM-dd HH:mm:ss"));


                if (md.Save_Booking(RoomId,i,now.ToString("yyyy-MM-dd HH:mm:ss"),checkin,checkout,Amount,Status,CreatorID,Deposit))
                {
                    MessageBox.Show("Booking Created");
                }
            })
            {

            };
        }

        void loadListRoom()
        {
            Items = new List<BookRoomItemViewModel>();

            BookingRoomModel model = new BookingRoomModel();
            DataTable data = new DataTable();
            data = model.Load_On();

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


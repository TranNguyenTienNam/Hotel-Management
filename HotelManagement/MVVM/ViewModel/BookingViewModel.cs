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

        public ICommand SelectedDateChangedCommand { get; set; }
        public ICommand SelectedChangedCommand { get; set; }
        public ICommand HandleBooking { get; set; }

        public BookingViewModel()
        {
            loadListRoom();

            SelectedDateChangedCommand = new RelayCommand<DatePicker>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBox.Show(p.Text);
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
               
                    int n = 1;
                    BookingRoomModel md = new BookingRoomModel();
                    int i = md.Save_Client(Name, n, CitizenID, Phone, Address, "Nam");
                    if (i!=0)
                    {
                        MessageBox.Show(i.ToString());
                     };



            });


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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core;
using System.Data;
using HotelManagement.MVVM.Model;
using System.Collections.ObjectModel;
using HotelManagement.Object;
using System.Windows.Input;

namespace HotelManagement.MVVM.ViewModel
{
    public class NewBookingRoomItemViewModel : ObservableObject
    {
        public static NewBookingRoomItemViewModel Instance => new NewBookingRoomItemViewModel();

        private int _maphong;
        public int MaPhong { get { return _maphong; } set { _maphong = value; OnPropertyChanged(); } }

        private string _tenphong;
        public string TenPhong { get { return _tenphong; } set { _tenphong = value; OnPropertyChanged(); } }

        private string _loaiphong;
        public string LoaiPhong { get { return _loaiphong; } set { _loaiphong = value; OnPropertyChanged(); } }

        private int _dongia;
        public int DonGia { get { return _dongia; } set { _dongia = value; OnPropertyChanged(); } }

        private int _soNgtoida;
        public int SoNgToiDa { get { return _soNgtoida; } set { _soNgtoida = value; OnPropertyChanged(); } }

        private string _ghichu;
        public string GhiChu { get { return _ghichu; } set { _ghichu = value; OnPropertyChanged(); } }


    }
}

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core;
using System.Data;
using HotelManagement.MVVM.Model;
using System.Collections.ObjectModel;
using HotelManagement.Object;
using System.Windows.Input;
using HotelManagement.MVVM.View;
using System.Windows;
using System.Windows.Threading;
using System;

namespace HotelManagement.MVVM.ViewModel.CheckOutViewModels
{
    public class RentInfoViewModel:ObservableObject
    {   
        public static RentInfoViewModel Instance => new RentInfoViewModel();
        private ObservableCollection<RentInfoViewModel> _items;
        public ObservableCollection<RentInfoViewModel> Items { get { return _items; } set { _items = value;OnPropertyChanged("Items"); } }
        int _maPhieuThue;
        public int MaPhieuThue { get { return _maPhieuThue; } set { _maPhieuThue = value; OnPropertyChanged(); } }

        int _maphong;
        public int MaPhong { get { return _maphong; } set { _maphong = value; OnPropertyChanged(); } }

        int _maKH;
        public int MaKhachHang { get { return _maKH; } set { _maKH = value;OnPropertyChanged(); } }

        DateTime _ngayBatDau;
        public DateTime NgayBatDau { get { return _ngayBatDau; } set { _ngayBatDau = value;OnPropertyChanged(); } }

        DateTime _ngayTraPhong;
        public DateTime NgayTraPhong { get { return _ngayTraPhong; } set { _ngayTraPhong = value;OnPropertyChanged(); } }

        int _soLuongKhach;
        public int SoLuongKhach { get { return _soLuongKhach; } set { _soLuongKhach = value;OnPropertyChanged(); } }

        String _tinhTrang;
        public String TinhTrang { get { return _tinhTrang; } set { _tinhTrang = value;OnPropertyChanged(); } }

        int _nguoiLapPhieu;
        public int NguoiLapPhieu { get { return _nguoiLapPhieu; } set { _nguoiLapPhieu = value;OnPropertyChanged(); } }

        decimal _tiencoc;
        public decimal TienCoc { get { return _tiencoc; } set { _tiencoc = value;OnPropertyChanged(); } }

        DateTime _ngayLapPhieu;
        public DateTime NgayLapPhieu { get { return _ngayLapPhieu; } set { _ngayLapPhieu = value;OnPropertyChanged(); } }

        String _tenKhachHang;
        public String TenKhachHang { get { return _tenKhachHang; } set { _tenKhachHang = value;OnPropertyChanged(); } }

        String _loaiKhachHang;
        public String LoaiKhachHang { get { return _loaiKhachHang; } set { _loaiKhachHang = value;OnPropertyChanged(); } }

        String _CMND;
        public String CMND { get { return _CMND; } set { _CMND = value;OnPropertyChanged(); } }

        String _soDienThoai;
        public String SoDienThoai { get { return _soDienThoai; } set { _soDienThoai = value;OnPropertyChanged(); } }

        String _diaChi;
        public String DiaChi { get { return _diaChi; } set { _diaChi = value;OnPropertyChanged(); } }

        String _gioiTinh;
        public String GioiTinh { get { return _gioiTinh; } set { _gioiTinh = value;OnPropertyChanged(); } }

        int _maLoaiKhach;
        public int MaLoaiKhach { get { return _maLoaiKhach; } set { _maLoaiKhach = value;OnPropertyChanged(); } }

        String _tenLoaiKhach;
        public String TenLoaiKhach { get { return _tenLoaiKhach; } set { _tenLoaiKhach = value;OnPropertyChanged(); } }

        String _tenPhong;
        public String TenPhong { get { return _tenPhong; } set { _tenPhong = value;OnPropertyChanged(); } }

        decimal _donGia;
        public decimal DonGia { get { return _donGia; } set { _donGia = value;OnPropertyChanged(); } }

        int _soNguoiToiDa;
        public int SoNguoiToiDa { get { return _soNguoiToiDa; } set { _soNguoiToiDa = value;OnPropertyChanged(); } }

        String _ghiChu;
        public String GhiChu { get { return _ghiChu; } set { _ghiChu = value;OnPropertyChanged(); } }

        int _maLoaiPhong;
        public int MaLoaiPhong { get { return _maLoaiPhong; } set { _maLoaiPhong = value;OnPropertyChanged(); } }

        String _tenLoaiPhong;
        public String TenLoaiPhong { get { return _tenLoaiPhong; } set { _tenLoaiPhong = value;OnPropertyChanged(); } }
        
    }
}

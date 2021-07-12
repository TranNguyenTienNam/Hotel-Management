using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelManagement.Core;
using HotelManagement.MVVM.Model;
using HotelManagement.MVVM.Model.CheckOut;
using HotelManagement.Object;

namespace HotelManagement.MVVM.ViewModel
{
    class ExportBillViewModel : ObservableObject
    {
        //thuộc tính phiếu thuê
        private int _maPhieuThue;
        public int MaPhieuThue { get { return _maPhieuThue; } set { _maPhieuThue = value; OnPropertyChanged(); } }

        private int _maphong;
        public int MaPhong { get { return _maphong; } set { _maphong = value; OnPropertyChanged(); } }

        private DateTime _ngayBatDau;
        public DateTime NgayBatDau { get { return _ngayBatDau; } set { _ngayBatDau = value; OnPropertyChanged(); } }

        private DateTime _ngayTraPhong;
        public DateTime NgayTraPhong { get { return _ngayTraPhong; } set { _ngayTraPhong = value; OnPropertyChanged(); } }

        private int _soLuongKhach;
        public int SoLuongKhach { get { return _soLuongKhach; } set { _soLuongKhach = value; OnPropertyChanged(); } }

        private String _tinhTrang;
        public String TinhTrang { get { return _tinhTrang; } set { _tinhTrang = value; OnPropertyChanged(); } }

        private string _nguoiLapPhieu;
        public string NguoiLapPhieu { get { return _nguoiLapPhieu; } set { _nguoiLapPhieu = value; OnPropertyChanged(); } }

        private int _tiencoc;
        public int TienCoc { get { return _tiencoc; } set { _tiencoc = value; OnPropertyChanged(); } }

        private DateTime _ngayLapPhieu;
        public DateTime NgayLapPhieu { get { return _ngayLapPhieu; } set { _ngayLapPhieu = value; OnPropertyChanged(); } }

        private String _tenKhachHang;
        public String TenKH { get { return _tenKhachHang; } set { _tenKhachHang = value; OnPropertyChanged(); } }

        private String _CMND;
        public String CMND { get { return _CMND; } set { _CMND = value; OnPropertyChanged(); } }

        private String _soDienThoai;
        public String SoDienThoai { get { return _soDienThoai; } set { _soDienThoai = value; OnPropertyChanged(); } }

        private String _diaChi;
        public String DiaChi { get { return _diaChi; } set { _diaChi = value; OnPropertyChanged(); } }

        private String _gioiTinh;
        public String GioiTinh { get { return _gioiTinh; } set { _gioiTinh = value; OnPropertyChanged(); } }

        int _maLoaiKhach;
        public int MaLoaiKhach { get { return _maLoaiKhach; } set { _maLoaiKhach = value; OnPropertyChanged(); } }

        private String _tenLoaiKhach;
        public String TenLoaiKhach { get { return _tenLoaiKhach; } set { _tenLoaiKhach = value; OnPropertyChanged(); } }

        private String _tenPhong;
        public String TenPhong { get { return _tenPhong; } set { _tenPhong = value; OnPropertyChanged(); } }

        private int _donGia;
        public int DonGia { get { return _donGia; } set { _donGia = value; OnPropertyChanged(); } }

        private int _soNguoiToiDa;
        public int SoNgToiDa { get { return _soNguoiToiDa; } set { _soNguoiToiDa = value; OnPropertyChanged(); } }

        private String _ghiChu;
        public String GhiChu { get { return _ghiChu; } set { _ghiChu = value; OnPropertyChanged(); } }

        private int _maLoaiPhong;
        public int MaLoaiPhong { get { return _maLoaiPhong; } set { _maLoaiPhong = value; OnPropertyChanged(); } }

        private String _tenLoaiPhong;
        public String TenLoaiPhong { get { return _tenLoaiPhong; } set { _tenLoaiPhong = value; OnPropertyChanged(); } }

        // thuộc tính dựa vào phiếu thuê tính được 
        private int _soNgayThue;
        public int SoNgayThue { get { return _soNgayThue; } set { _soNgayThue = value; OnPropertyChanged(); } }

        private int _phuThu;
        public int PhuThu { get { return _phuThu; } set { _phuThu = value; OnPropertyChanged(); } }

        private int _tongTienPhong;
        public int TongTienPhong { get { return _tongTienPhong; } set { _tongTienPhong = value; OnPropertyChanged(); } }

        private int _tongTien;
        public int TongTien { get { return _tongTien; } set { _tongTien = value; OnPropertyChanged(); } }

        //ngày tạo bill
        public String DateOfIssue { get; set; }

        public ExportBillViewModel(Rental currentRental)
        {
            MaPhieuThue = currentRental.MaPhieuThue;
            TenKH = currentRental.TenKH;
            GioiTinh = currentRental.GioiTinh;
            MaLoaiKhach = currentRental.MaLoaiKhach;
            TenLoaiKhach = currentRental.TenLoaiKhach;
            DiaChi = currentRental.DiaChi;
            CMND = currentRental.CMND;
            SoDienThoai = currentRental.SoDienThoai;
            TenPhong = currentRental.TenPhong;
            TenLoaiPhong = currentRental.TenLoaiPhong;
            DonGia = currentRental.DonGia;
            SoNgToiDa = currentRental.SoNgToiDa;
            SoLuongKhach = currentRental.SoLuongKhach;
            NgayLapPhieu = currentRental.NgayLapPhieu;
            NgayBatDau = currentRental.NgayBatDau;
            NgayTraPhong = currentRental.NgayTraPhong;
            TienCoc = currentRental.TienCoc;
            SoNgayThue = GetDays(currentRental.NgayBatDau, currentRental.NgayTraPhong);
            TongTienPhong = currentRental.DonGia * SoNgayThue;
            PhuThu = GetSurchargeMoney(SoLuongKhach, SoNgayThue, TongTienPhong, SoNgToiDa);
            TongTien = TongTienPhong + PhuThu - TienCoc;
            DateOfIssue = DateTime.Now.ToString();
            NguoiLapPhieu = currentRental.NguoiLapPhieu;
            DateOfIssue = DateTime.Now.ToString();
        }

        private int GetDays(DateTime ngayBD, DateTime ngayTP)
        {
            DateTime bd = ngayBD.Date;
            DateTime tp = ngayTP.Date;
            string re = tp.Subtract(bd).TotalDays.ToString();
            return int.Parse(re);
        }

        private int GetSurchargeMoney(int soLuongkhach, int soNgayThue, int tongTienPhong, int soNguoiToiDa)
        {
            SurchargeModel surchargeModel = new SurchargeModel();
            int tyLePhuThu = surchargeModel.Get_surcharge_more_client();
            if (soLuongkhach > soNguoiToiDa)
            {
                return (soLuongkhach - soNguoiToiDa) * tyLePhuThu * tongTienPhong / 100;
            }
            return 0;
        }
    }
}

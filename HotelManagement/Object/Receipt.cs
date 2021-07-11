using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Object
{
    class Receipt
    {
        private int _maHoaDon;
        public int MaHoaDon { get { return _maHoaDon; } set { _maHoaDon = value; } }

        private int _phuThu;
        public int PhuThu { get { return _phuThu; } set { _phuThu = value; } }

        private int _tongTien;
        public int TongTien { get { return _tongTien; } set { _tongTien = value; } }

        private int _maPhieuThue;
        public int MaPhieuThue { get { return _maPhieuThue; } set { _maPhieuThue = value; } }

        private int _maphong;
        public int MaPhong { get { return _maphong; } set { _maphong = value; } }

        private DateTime _ngayBatDau;
        public DateTime NgayBatDau { get { return _ngayBatDau; } set { _ngayBatDau = value; } }

        private DateTime _ngayTraPhong;
        public DateTime NgayTraPhong { get { return _ngayTraPhong; } set { _ngayTraPhong = value; } }

        private int _soLuongKhach;
        public int SoLuongKhach { get { return _soLuongKhach; } set { _soLuongKhach = value; } }

        private String _tinhTrang;
        public String TinhTrang { get { return _tinhTrang; } set { _tinhTrang = value; } }

        private int _nguoiLapPhieu;
        public int NguoiLapPhieu { get { return _nguoiLapPhieu; } set { _nguoiLapPhieu = value; } }

        private int _tiencoc;
        public int TienCoc { get { return _tiencoc; } set { _tiencoc = value; } }

        private DateTime _ngayLapPhieu;
        public DateTime NgayLapPhieu { get { return _ngayLapPhieu; } set { _ngayLapPhieu = value; } }

        private String _tenKhachHang;
        public String TenKH { get { return _tenKhachHang; } set { _tenKhachHang = value; } }

        private String _CMND;
        public String CMND { get { return _CMND; } set { _CMND = value; } }

        private String _soDienThoai;
        public String SoDienThoai { get { return _soDienThoai; } set { _soDienThoai = value; } }

        private String _diaChi;
        public String DiaChi { get { return _diaChi; } set { _diaChi = value; } }

        private String _gioiTinh;
        public String GioiTinh { get { return _gioiTinh; } set { _gioiTinh = value; } }

        int _maLoaiKhach;
        public int MaLoaiKhach { get { return _maLoaiKhach; } set { _maLoaiKhach = value; } }

        private String _tenLoaiKhach;
        public String TenLoaiKhach { get { return _tenLoaiKhach; } set { _tenLoaiKhach = value; } }

        private String _tenPhong;
        public String TenPhong { get { return _tenPhong; } set { _tenPhong = value; } }

        private int _donGia;
        public int DonGia { get { return _donGia; } set { _donGia = value; } }

        private int _soNguoiToiDa;
        public int SoNgToiDa { get { return _soNguoiToiDa; } set { _soNguoiToiDa = value; } }

        private String _ghiChu;
        public String GhiChu { get { return _ghiChu; } set { _ghiChu = value; } }

        private int _maLoaiPhong;
        public int MaLoaiPhong { get { return _maLoaiPhong; } set { _maLoaiPhong = value; } }

        private String _tenLoaiPhong;
        public String TenLoaiPhong { get { return _tenLoaiPhong; } set { _tenLoaiPhong = value; } }
    }
}

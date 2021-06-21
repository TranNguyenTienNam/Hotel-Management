using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Object.minh_objects
{
    public class billFullInfo
    {
        int maHoaDon;
        int maPhieuThue;
        decimal phuThu;
        decimal tongTien;

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public int MaPhieuThue { get => maPhieuThue; set => maPhieuThue = value; }
        public decimal PhuThu { get => phuThu; set => phuThu = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }

        string maKH;
        string tenKH;
        string loaiKhach;
        string cMND;
        string soDienThoai;
        string diaChi;
        string gioiTinh;

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string LoaiKhach { get => loaiKhach; set => loaiKhach = value; }
        public string CMND { get => cMND; set => cMND = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }

        int maLoaiKhach;
        string tenLoaiKhach;

        public int MaLoaiKhach { get => maLoaiKhach; set => maLoaiKhach = value; }
        public string TenLoaiKhach { get => tenLoaiKhach; set => tenLoaiKhach = value; }

        int maPhong;
        DateTime ngayBatDau;
        DateTime ngayTraPhong;
        int soLuongKhach;
        string tinhTrang;
        int nguoiLapPhieu;
        decimal tienCoc;

        public int MaPhong { get => maPhong; set => maPhong = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayTraPhong { get => ngayTraPhong; set => ngayTraPhong = value; }
        public int SoLuongKhach { get => soLuongKhach; set => soLuongKhach = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public int NguoiLapPhieu { get => nguoiLapPhieu; set => nguoiLapPhieu = value; }
        public decimal TienCoc { get => tienCoc; set => tienCoc = value; }

        int maLoaiPhong;
        string tenLoaiPhong;
        decimal donGia;
        int soNgToiDa;

        public int MaLoaiPhong { get => maLoaiPhong; set => maLoaiPhong = value; }
        public string TenLoaiPhong { get => tenLoaiPhong; set => tenLoaiPhong = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public int SoNgToiDa { get => soNgToiDa; set => soNgToiDa = value; }
    }
}

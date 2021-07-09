using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HotelManagement.MVVM.ViewModel;
using System.Windows;

namespace HotelManagement.MVVM.Model.CheckOut
{
    class BillsModel
    {
        public DataTable Load_List_Bills()
        {
            DataTable re;
            string query = "SELECT MaHoaDon, PhuThu, TongTien, " +
                "HOADON.MaPhieuThue, NgayLapPhieu, NgayBatDau, NgayTraPhong, SoLuongKhach, TinhTrang, NguoiLapPhieu, TienCoc, " +
                " PHIEUTHUEPHONG.MaKH, TenKH, CMND, SoDienThoai, DiaChi, GioiTinh, " +
                "LOAIKHACHHANG.MaLoaiKhach, TenLoaiKhach, " +
                "PHIEUTHUEPHONG.MaPhong, TenPhong, GhiChu, " +
                "LOAIPHONG.MaLoaiPhong, TenLoaiPhong, DonGia,SoNgToiDa " +
                "FROM HOADON " +
                "inner join PHIEUTHUEPHONG on PHIEUTHUEPHONG.MaPhieuThue = HOADON.MaPhieuThue " +
                "inner join KHACHHANG on KHACHHANG.MaKH = PHIEUTHUEPHONG.MaKH " +
                "inner join LOAIKHACHHANG on LOAIKHACHHANG.MaLoaiKhach=KHACHHANG.MaLoaiKhach " +
                "inner join PHONG on PHONG.MaPhong=PHIEUTHUEPHONG.MaPhong " +
                "inner join LOAIPHONG on LOAIPHONG.MaLoaiPhong=PHONG.MaLoaiPhong " +
                "inner join NGUOIDUNG on NGUOIDUNG.MaNgDung=PHIEUTHUEPHONG.NguoiLapPhieu ";
            re = Process.createTable(query);
            return re;
        }
        public DataTable Load_Search_CMND(string _cmnd)
        {
            DataTable re;
            string query = "SELECT MaHoaDon, PhuThu, TongTien, " +
                "HOADON.MaPhieuThue, NgayLapPhieu, NgayBatDau, NgayTraPhong, SoLuongKhach, TinhTrang, NguoiLapPhieu, TienCoc, " +
                " PHIEUTHUEPHONG.MaKH, TenKH, CMND, SoDienThoai, DiaChi, GioiTinh, " +
                "LOAIKHACHHANG.MaLoaiKhach, TenLoaiKhach, " +
                "PHIEUTHUEPHONG.MaPhong, TenPhong, GhiChu, " +
                "LOAIPHONG.MaLoaiPhong, TenLoaiPhong, DonGia,SoNgToiDa " +
                "FROM HOADON " +
                "inner join PHIEUTHUEPHONG on PHIEUTHUEPHONG.MaPhieuThue = HOADON.MaPhieuThue " +
                "inner join KHACHHANG on KHACHHANG.MaKH = PHIEUTHUEPHONG.MaKH " +
                "inner join LOAIKHACHHANG on LOAIKHACHHANG.MaLoaiKhach=KHACHHANG.MaLoaiKhach " +
                "inner join PHONG on PHONG.MaPhong=PHIEUTHUEPHONG.MaPhong " +
                "inner join LOAIPHONG on LOAIPHONG.MaLoaiPhong=PHONG.MaLoaiPhong " +
                "inner join NGUOIDUNG on NGUOIDUNG.MaNgDung=PHIEUTHUEPHONG.NguoiLapPhieu " +
                "and CHARINDEX(N'" + _cmnd + "', CMND) != 0";
            re = Process.createTable(query);
            return re;
        }
    }
}
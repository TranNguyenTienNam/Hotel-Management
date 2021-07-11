using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HotelManagement.MVVM.ViewModel;
using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using HotelManagement.Object;

namespace HotelManagement.MVVM.Model
{
    class CheckOutModel
    {
        public static string con_string = ConfigurationManager.ConnectionStrings["con"].ToString();
        public DataTable Load_List_Rent()
        {
            DataTable re;
            string query = "SELECT MaPhieuThue, NgayLapPhieu, NgayBatDau, NgayTraPhong, SoLuongKhach, TinhTrang, NguoiLapPhieu, TienCoc, " +
                "TenKH, PHIEUTHUEPHONG.CMND, SoDienThoai, DiaChi, GioiTinh, " +
                "LOAIKHACHHANG.MaLoaiKhach, TenLoaiKhach, " +
                "PHIEUTHUEPHONG.MaPhong, TenPhong, GhiChu, " +
                "LOAIPHONG.MaLoaiPhong, TenLoaiPhong, DonGia, SoNgToiDa " +
                "FROM PHIEUTHUEPHONG " +
                "inner join KHACHHANG on PHIEUTHUEPHONG.CMND=KHACHHANG.CMND " +
                "inner join LOAIKHACHHANG on LOAIKHACHHANG.MaLoaiKhach=KHACHHANG.MaLoaiKhach " +
                "inner join PHONG on PHONG.MaPhong=PHIEUTHUEPHONG.MaPhong " +
                "inner join LOAIPHONG on LOAIPHONG.MaLoaiPhong=PHONG.MaLoaiPhong " +
                "inner join NGUOIDUNG on NGUOIDUNG.MaNgDung=PHIEUTHUEPHONG.NguoiLapPhieu " +
                "WHERE TinhTrang = 'Checkin'";
            re = Process.createTable(query);
            return re;
        }

        public DataTable Load_List_Rent_By_Room(string _tenPhong)
        {
            DataTable re;
            string query = "SELECT MaPhieuThue, NgayLapPhieu, NgayBatDau, NgayTraPhong, SoLuongKhach, TinhTrang, NguoiLapPhieu, TienCoc, " +
                "TenKH, PHIEUTHUEPHONG.CMND, SoDienThoai, DiaChi, GioiTinh, " +
                "LOAIKHACHHANG.MaLoaiKhach, TenLoaiKhach, " +
                "PHIEUTHUEPHONG.MaPhong, TenPhong, GhiChu, " +
                "LOAIPHONG.MaLoaiPhong, TenLoaiPhong, DonGia,SoNgToiDa " +
                "FROM PHIEUTHUEPHONG " +
                "inner join KHACHHANG on PHIEUTHUEPHONG.CMND=KHACHHANG.CMND " +
                "inner join LOAIKHACHHANG on LOAIKHACHHANG.MaLoaiKhach=KHACHHANG.MaLoaiKhach " +
                "inner join PHONG on PHONG.MaPhong=PHIEUTHUEPHONG.MaPhong " +
                "inner join LOAIPHONG on LOAIPHONG.MaLoaiPhong=PHONG.MaLoaiPhong " +
                "inner join NGUOIDUNG on NGUOIDUNG.MaNgDung=PHIEUTHUEPHONG.NguoiLapPhieu " +
                "WHERE TinhTrang = 'Checkin' " +
                "and CHARINDEX(N'" + _tenPhong + "', TenPhong) != 0";
            re = Process.createTable(query);
            return re;
        }

        public DataTable Change_Checkout_Date_And_Set_Checkout(DateTime date, int maPhieuThue) //date dạng yyyy/mm/dd
        {
            DataTable re;
            string query = "UPDATE PHIEUTHUEPHONG " +
                "SET NgayTraPhong = '" + date + "', " +
                "TinhTrang = 'Checkout' " +
                "WHERE MaPhieuThue = " + maPhieuThue;
            re = Process.createTable(query);
            return re;
        }

    }
}

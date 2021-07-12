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

namespace HotelManagement.MVVM.Model.CheckOut
{
    class BillsModel
    {
        public static string con_string = ConfigurationManager.ConnectionStrings["con"].ToString();

        public DataTable Load_List_Bills()
        {
            DataTable re;
            string query = "SELECT MaHoaDon, PhuThu, TongTien, " +
                "HOADON.MaPhieuThue, NgayLapPhieu, NgayBatDau, NgayTraPhong, SoLuongKhach, TinhTrang, TTNguoiDung.Ten, TienCoc, " +
                "TenKH, PHIEUTHUEPHONG.CMND, KHACHHANG.SoDienThoai, DiaChi, KHACHHANG.GioiTinh, " +
                "LOAIKHACHHANG.MaLoaiKhach, TenLoaiKhach, " +
                "PHIEUTHUEPHONG.MaPhong, TenPhong, GhiChu, " +
                "LOAIPHONG.MaLoaiPhong, TenLoaiPhong, DonGia,SoNgToiDa " +
                "FROM HOADON " +
                "inner join PHIEUTHUEPHONG on PHIEUTHUEPHONG.MaPhieuThue = HOADON.MaPhieuThue " +
                "inner join KHACHHANG on KHACHHANG.CMND = PHIEUTHUEPHONG.CMND " +
                "inner join LOAIKHACHHANG on LOAIKHACHHANG.MaLoaiKhach=KHACHHANG.MaLoaiKhach " +
                "inner join PHONG on PHONG.MaPhong=PHIEUTHUEPHONG.MaPhong " +
                "inner join LOAIPHONG on LOAIPHONG.MaLoaiPhong=PHONG.MaLoaiPhong " +
                "inner join TTNguoiDung on TTNguoiDung.MaNgDung=PHIEUTHUEPHONG.NguoiLapPhieu ";
            re = Process.createTable(query);
            return re;
        }
        public DataTable Load_Search_CMND(string _cmnd)
        {
            DataTable re;
            string query = "SELECT MaHoaDon, PhuThu, TongTien, " +
                "HOADON.MaPhieuThue, NgayLapPhieu, NgayBatDau, NgayTraPhong, SoLuongKhach, TinhTrang, TTNguoiDung.Ten, TienCoc, " +
                "TenKH, PHIEUTHUEPHONG.CMND, KHACHHANG.SoDienThoai, DiaChi, KHACHHANG.GioiTinh, " +
                "LOAIKHACHHANG.MaLoaiKhach, TenLoaiKhach, " +
                "PHIEUTHUEPHONG.MaPhong, TenPhong, GhiChu, " +
                "LOAIPHONG.MaLoaiPhong, TenLoaiPhong, DonGia,SoNgToiDa " +
                "FROM HOADON " +
                "inner join PHIEUTHUEPHONG on PHIEUTHUEPHONG.MaPhieuThue = HOADON.MaPhieuThue " +
                "inner join KHACHHANG on KHACHHANG.CMND = PHIEUTHUEPHONG.CMND " +
                "inner join LOAIKHACHHANG on LOAIKHACHHANG.MaLoaiKhach=KHACHHANG.MaLoaiKhach " +
                "inner join PHONG on PHONG.MaPhong=PHIEUTHUEPHONG.MaPhong " +
                "inner join LOAIPHONG on LOAIPHONG.MaLoaiPhong=PHONG.MaLoaiPhong " +
                "inner join TTNguoiDung on TTNguoiDung.MaNgDung = PHIEUTHUEPHONG.NguoiLapPhieu " +
                "and CHARINDEX(N'" + _cmnd + "', PHIEUTHUEPHONG.CMND) != 0";
            re = Process.createTable(query);
            return re;
        }
        public void Delete_Bills(int _maHoaDon)
        {
            SqlConnection con = new SqlConnection(con_string);
            con.Open();
            String query = "DELETE FROM HOADON WHERE MaHoaDon = " + _maHoaDon;
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteReader();
        }
        public void Insert_Bill(int _maPhieuThue, int _phuThu, int _tongTien)
        {
            SqlConnection con = new SqlConnection(con_string);
            con.Open();
            String query = "insert into HOADON " +
                "values (" + _maPhieuThue + ", " + _phuThu + ", " + _tongTien + ")";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteReader();
        }
    }
}
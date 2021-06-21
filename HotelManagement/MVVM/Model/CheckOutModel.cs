using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class CheckOutModel
    {
        public DataTable get_list_bills()
        {
            DataTable re;
            string query = "select *" +
                "from HOADON" +
                "inner join PHIEUTHUEPHONG on HOADON.MaPhieuThue=PHIEUTHUEPHONG.MaPhieuThue" +
                "inner join PHONG on PHIEUTHUEPHONG.MaPhong=PHONG.MaPhong" +
                "inner join KHACHHANG on KHACHHANG.MaKH = PHIEUTHUEPHONG.MaKH" +
                "inner join LOAIKHACHHANG on LOAIKHACHHANG.MaLoaiKhach = KHACHHANG.MaLoaiKhach";
            re = Process.createTable(query);
            return re;
        }
        public DataTable get_list_checkout()
        {
            DataTable re;
            string query = "select MaPhieuThue, NgayBatDau, NgayTraPhong, SoLuongKhach, TinhTrang, NguoiLapPhieu, TienCoc, " +
                "PHIEUTHUEPHONG.MaKH, TenKH, CMND, SoDienThoai, DiaChi, GioiTinh, " +
                "LOAIKHACHHANG.MaLoaiKhach, TenLoaiKhach, " +
                "PHIEUTHUEPHONG.MaPhong, TenPhong, GhiChu, " +
                "LOAIPHONG.MaLoaiPhong, TenLoaiPhong, DonGia,SoNgToiDa " +
                "from PHIEUTHUEPHONG " +
                "inner join KHACHHANG on PHIEUTHUEPHONG.MaKH=KHACHHANG.MaKH " +
                "inner join LOAIKHACHHANG on LOAIKHACHHANG.MaLoaiKhach=KHACHHANG.MaLoaiKhach " +
                "inner join PHONG on PHONG.MaPhong=PHIEUTHUEPHONG.MaPhong " +
                "inner join LOAIPHONG on LOAIPHONG.MaLoaiPhong=PHONG.MaLoaiPhong " +
                "inner join NGUOIDUNG on NGUOIDUNG.MaNgDung=PHIEUTHUEPHONG.NguoiLapPhieu " +
                "where TinhTrang='Checkin'";

            re = Process.createTable(query);
            return re;
        }
    }
}

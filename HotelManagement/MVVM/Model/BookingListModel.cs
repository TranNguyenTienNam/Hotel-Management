using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HotelManagement.MVVM.Model
{
    class BookingListModel
    {
        public DataTable LoadBooking()
        {
            string sql_select = "select * from KHACHHANG k,PHIEUTHUEPHONG p where k.CMND = p.CMND";

            return Process.createTable(sql_select);
        }

        public DataTable LoadClientInformation(string CMND)
        {
            string sql_select = "select lkh.TenLoaiKhach as TenLoaiKhach, kh.SoDienThoai as SoDienThoai, kh.GioiTinh as GioiTinh, kh.DiaChi as DiaChi "
                + "from KHACHHANG kh, LOAIKHACHHANG lkh where kh.MaLoaiKhach = lkh.MaLoaiKhach and kh.CMND = '" + CMND + "'";

            return Process.createTable(sql_select);
        }

        public DataTable LoadRentalInformation(int MaPhieuThue)
        {
            string sql_select = "select p.MaPhong as MaPhong, lp.TenLoaiPhong as TenLoaiPhong, lp.DonGia as DonGia, " +
                "ptp.SoLuongKhach as SoLuongKhach, ptp.NgayTraPhong as NgayTraPhong, ttng.MaNgDung as MaNgDung, ttng.Ten as Ten " +
                "from PHIEUTHUEPHONG ptp, PHONG p, LOAIPHONG lp, TTNguoiDung ttng " +
                "where ptp.MaPhong = p.MaPhong and p.MaLoaiPhong = lp.MaLoaiPhong and ttng.MaNgDung = ptp.NguoiLapPhieu " +
                "and ptp.MaPhieuThue = " + MaPhieuThue;
            return Process.createTable(sql_select);
        }



        public bool Update_Rental(int RentalID,int Deposit,int Amount)
        {
            string sql_update = "UPDATE PHIEUTHUEPHONG " +
                "SET TienCoc ="+ Deposit +" , SoLuongKhach = " + Amount +
                "WHERE MaPhieuThue =" + RentalID;
            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;
            return false;
        }
        public bool Delete_Rental(int RentalID)
        {
            string sql_update = "DELETE FROM PHIEUTHUEPHONG " +
                                "WHERE MaPhieuThue =" + RentalID;
            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;
            return false;
        }

        public string GetUsernameAccount(int MaNgDung)
        {
            string sql_select = "SELECT TenTaiKhoan FROM NGUOIDUNG WHERE MaNgDung=" + MaNgDung;

            return Process.getString(sql_select);
        }


    }
}
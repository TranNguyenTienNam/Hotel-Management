using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HotelManagement.MVVM.ViewModel;
using System.Windows;

namespace HotelManagement.MVVM.Model
{
    class StaffModel
    {
        public DataTable Load_Accounts(string Mode)   //Đầu vào cần 1 mã Ukey 
        {
            DataTable re;
            string sql_select = "select nd.MaNgDung as MaNguoiDung, nd.TenTaiKhoan as TenTaiKhoan, ttnd.Ho as Ho, ttnd.Ten as Ten, "
                + "ttnd.SoDienThoai as SoDienThoai, ttnd.GioiTinh as GioiTinh, ttnd.Email as Email, ttnd.NgaySinh as NgaySinh, "
                + "nd.TinhTrangTK as TinhTrang, ttnd.QuyenHan as QuyenHan from NGUOIDUNG nd, TTNguoiDung ttnd "
                + "where nd.MaNgDung = ttnd.MaNgDung and ttnd.QuyenHan in (2, 1) "
                + SelectedMode(Mode) + "order by nd.TinhTrangTK desc"; 
            re = Process.createTable(sql_select);
            return re;  
        }

        public bool BlockStaff(int MaNgDung)
        {
            string sql_update = "update NGUOIDUNG set TinhTrangTK = 0 where MaNgDung = " + MaNgDung;

            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;
            return false;
        }

        public bool UnblockStaff(int MaNgDung)
        {
            string sql_update = "update NGUOIDUNG set TinhTrangTK = 1 where MaNgDung = " + MaNgDung;

            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;
            return false;
        }

        public bool PromoteStaff(int MaNgDung)
        {
            string sql_update = "update TTNguoiDung set QuyenHan = 1 where MaNgDung = " + MaNgDung;

            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;
            return false;
        }

        public bool DemoteStaff(int MaNgDung)
        {
            string sql_update = "update TTNguoiDung set QuyenHan = 2 where MaNgDung = " + MaNgDung;

            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;
            return false;
        }

        public DataTable Search_StaffID(string MaNgDung, string Mode)
        {
            DataTable re;
            string sql_select = "select nd.MaNgDung as MaNguoiDung, nd.TenTaiKhoan as TenTaiKhoan, ttnd.Ho as Ho, ttnd.Ten as Ten, "
                + "ttnd.SoDienThoai as SoDienThoai, ttnd.GioiTinh as GioiTinh, ttnd.Email as Email, ttnd.NgaySinh as NgaySinh, "
                + "nd.TinhTrangTK as TinhTrang, ttnd.QuyenHan as QuyenHan from NGUOIDUNG nd, TTNguoiDung ttnd "
                + "where nd.MaNgDung = ttnd.MaNgDung and ttnd.QuyenHan in (2, 1) " + SelectedMode(Mode) 
                + "and CHARINDEX('" + MaNgDung + "', nd.MaNgDung) != 0"
                + "order by nd.TinhTrangTK desc";
            re = Process.createTable(sql_select);
            return re;
        }

        public DataTable Search_StaffUsername(string TenTK, string Mode)
        {
            DataTable re;
            string sql_select = "select nd.MaNgDung as MaNguoiDung, nd.TenTaiKhoan as TenTaiKhoan, ttnd.Ho as Ho, ttnd.Ten as Ten, "
                + "ttnd.SoDienThoai as SoDienThoai, ttnd.GioiTinh as GioiTinh, ttnd.Email as Email, ttnd.NgaySinh as NgaySinh, "
                + "nd.TinhTrangTK as TinhTrang, ttnd.QuyenHan as QuyenHan from NGUOIDUNG nd, TTNguoiDung ttnd "
                + "where nd.MaNgDung = ttnd.MaNgDung and ttnd.QuyenHan in (2, 1) " + SelectedMode(Mode)
                + "and CHARINDEX('" + TenTK + "', nd.TenTaiKhoan) != 0"
                + "order by nd.TinhTrangTK desc";
            re = Process.createTable(sql_select);
            return re;
        }

        public DataTable Search_StaffLastName(string Ten, string Mode)
        {
            DataTable re;
            string sql_select = "select nd.MaNgDung as MaNguoiDung, nd.TenTaiKhoan as TenTaiKhoan, ttnd.Ho as Ho, ttnd.Ten as Ten, "
                + "ttnd.SoDienThoai as SoDienThoai, ttnd.GioiTinh as GioiTinh, ttnd.Email as Email, ttnd.NgaySinh as NgaySinh, "
                + "nd.TinhTrangTK as TinhTrang, ttnd.QuyenHan as QuyenHan from NGUOIDUNG nd, TTNguoiDung ttnd "
                + "where nd.MaNgDung = ttnd.MaNgDung and ttnd.QuyenHan in (2, 1) " + SelectedMode(Mode)
                + "and CHARINDEX('" + Ten + "', ttnd.Ten) != 0"
                + "order by nd.TinhTrangTK desc";
            re = Process.createTable(sql_select);
            return re;
        }

        public DataTable Search_StaffPhone(string sdt, string Mode)
        {
            DataTable re;
            string sql_select = "select nd.MaNgDung as MaNguoiDung, nd.TenTaiKhoan as TenTaiKhoan, ttnd.Ho as Ho, ttnd.Ten as Ten, "
                 + "ttnd.SoDienThoai as SoDienThoai, ttnd.GioiTinh as GioiTinh, ttnd.Email as Email, ttnd.NgaySinh as NgaySinh, "
                 + "nd.TinhTrangTK as TinhTrang, ttnd.QuyenHan as QuyenHan from NGUOIDUNG nd, TTNguoiDung ttnd "
                 + "where nd.MaNgDung = ttnd.MaNgDung and ttnd.QuyenHan in (2, 1) " + SelectedMode(Mode)
                 + "and CHARINDEX('" + sdt + "', ttnd.SoDienThoai) != 0"
                 + "order by nd.TinhTrangTK desc";
            re = Process.createTable(sql_select);
            return re;
        }

        private string SelectedMode(string Mode)
        {
            switch (Mode)
            {
                case "All":
                    return "";
                case "Active":
                    return "and nd.TinhTrangTK = 1 ";
                case "Blocked":
                    return "and nd.TinhTrangTK = 0 ";
                default:
                    return "";
            }
        }
    }
}
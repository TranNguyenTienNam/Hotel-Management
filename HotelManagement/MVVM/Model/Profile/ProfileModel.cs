using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class ProfileModel
    {
        public user Load_Profile(int MaNgDung)
        {
            string sql_select = "select TTNguoiDung.MaNgDung, Ho, Ten, SoDienThoai, GioiTinh, Email, NgaySinh, QuyenHan, NGUOIDUNG.TenTaiKhoan, TinhTrangTK " +
                "from TTNguoiDung inner join NGUOIDUNG on TTNguoiDung.MaNgDung = NGUOIDUNG.MaNgDung " +
                "where TTNguoiDung.MaNgDung = " + MaNgDung;

            return Process.getInfo(sql_select);
        }

        public bool CheckCurrentPassword(int MaNgDung, string MatKhau)
        {
            string sql_select = "select MaNgDung from NGUOIDUNG where MaNgDung = " + MaNgDung + 
                " and MatKhau = '" + Process.Encrypt(MatKhau) + "'";

            if (Process.ExecutiveReader(sql_select) > 0)
                return true;
            return false;
        }

        public bool ChangePassword(int MaNgDung, string MatKhau)
        {
            string sql_update = "update NGUOIDUNG set MatKhau = '" + Process.Encrypt(MatKhau) + "' where MaNgDung = " + MaNgDung;

            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;
            return false;
        }

        public bool EditProfile(user user)
        {
            string sql_update = "update TTNguoiDung set Ho = N'" + user.Ho + "', Ten = N'" + user.Ten + 
                "', SoDienThoai = '" + user.SoDienThoai + "', GioiTinh = '" + user.GioiTinh + 
                "', Email = '" + user.Email + "', NgaySinh = " + user.NgaySinh.ToString("yyyy-MM-dd") + " where MaNgDung = " + user.MaNgDung;

            if (Process.ExecutiveNonQuery(sql_update) > 0)
                return true;
            return false;
        }
    }
}

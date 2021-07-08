using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class RegisterModel
    {
        public bool CheckExistUsername(string Username)
        {
            string sql_select = "select MaNgDung from NGUOIDUNG where TenTaiKhoan = '" + Username + "'";

            if (Process.ExecutiveReader(sql_select) > 0)
            {
                return true;
            }
            return false;
        }

        public int RegisterWithUsernameAndPassword(string Username, string Password)
        {
            string sql_insert = "insert NGUOIDUNG(TenTaiKhoan, MatKhau, TinhTrangTK) values " +
                "('" + Username + "', '" + Process.Encrypt(Password) + "', 1)";

            //Lấy MaNgDung mới insert vào
            string sql_select = "select MaNgDung from NGUOIDUNG where TenTaiKhoan = '" + Username + "'";
            if (Process.ExecutiveNonQuery(sql_insert) > 0)
            {
                return Process.getNumber(sql_select);
            }
            return -1;
        }

        public bool InsertInfoUser(int MaNgDung, string Ho, string Ten, string Email)
        {
            string sql_insert = "insert TTNguoiDung(MaNgDung, Ho, Ten, Email, QuyenHan) values " +
                "(" + MaNgDung + ", N'" + Ho + "', N'" + Ten + "', '" + Email + "', 2)";
            if (Process.ExecutiveNonQuery(sql_insert) > 0)
            {
                return true;
            }
            return false;
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool IsSpecialChar(string text)
        {
            if (string.IsNullOrEmpty(text))
                return true;
            if (Process.CheckSpecialChar(text))
                return true;
            return false;
        }

        public bool IsVietKey(string text)
        {
            if (string.IsNullOrEmpty(text))
                return true;
            if (Process.CheckVietKey(text))
                return true;
            return false;
        }
    }
}

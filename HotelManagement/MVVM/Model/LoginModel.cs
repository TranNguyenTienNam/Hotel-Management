using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace HotelManagement.MVVM.Model
{
    class LoginModel
    {
        public bool LoginWithUsernameAndPassword(string Username, string Password)
        {
            string sql_select = "select MaNgDung from NGUOIDUNG where TenTaiKhoan = '" + Username + "' and MatKhau = '" + Password + "'";

            if (Process.ExecutiveReader(sql_select) > 0)
            {
                return true;
            }
            return false;
        }

        public int GetStatusAccount(string Username)
        {
            string sql_select = "select TinhTrangTK from NGUOIDUNG where TenTaiKhoan = '" + Username + "'";

            return Process.getNumber(sql_select);
        }

        public int GetIdAccount(string Username)
        {
            string sql_select = "select MaNgDung from NGUOIDUNG where TenTaiKhoan = '" + Username + "'";

            return Process.getNumber(sql_select);
        }
    }
}

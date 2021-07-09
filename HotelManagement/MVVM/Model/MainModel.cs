using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class MainModel
    {
        public string GetNameAccount(int MaNgDung)
        {
            string sql_select = "select Ten from TTNguoiDung where MaNgDung = "+ MaNgDung;

            return Process.getString(sql_select);
        }

        public int GetPermissionAccount(int MaNgDung)
        {
            string sql_select = "select QuyenHan from TTNguoiDung where MaNgDung = " + MaNgDung;

            return Process.getNumber(sql_select);
        }
    }
}

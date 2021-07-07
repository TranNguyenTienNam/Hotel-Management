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
        public DataTable Load_Profile(int MaNgDung)
        {
            DataTable re;
            string sql_select = "select * from TTNguoiDung where MaNgDung = " + MaNgDung;

            re = Process.createTable(sql_select);
            return re;  //Trả về 1 DataTable Thông tin người dùng
        }
    }
}

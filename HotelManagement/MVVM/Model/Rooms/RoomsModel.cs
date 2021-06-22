using HotelManagement.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelManagement.MVVM.Model
{
    class RoomsModel
    {
        public DataTable Load_RoomType()
        {
            DataTable re;
            string sql_select = "select * from LOAIPHONG";

            re = Process.createTable(sql_select);
            return re;  //Trả về 1 DataTable loại phòng
        }

        public bool Insert_Room(string TenPhong, int MaLoaiPhong, string GhiChu)
        {
            string sql_insert = "insert PHONG(TenPhong, MaLoaiPhong, GhiChu) values " +
                "(N'" + TenPhong + "'," + MaLoaiPhong + ",N'" + GhiChu + "')";
            try
            {
                if (Process.ExecutiveNonQuery(sql_insert) > 0)
                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

    }
}

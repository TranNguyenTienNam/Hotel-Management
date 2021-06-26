using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class TypesListModel
    {
        public DataTable Load_On()   //Đầu vào cần 1 mã Ukey 
        {
            DataTable re;
            string sql_select = "select * "
                + "from LOAIPHONG";

            re = Process.createTable(sql_select);
            return re;  //Trả về 1 DataTable
        }

        public bool CheckTypeIdExistInRoom(int MaLoaiPhong)
        {
            string sql_select = "select * from PHONG where MaLoaiPhong= " + MaLoaiPhong;

            if (Process.ExecutiveReader(sql_select) > 0)
            {
                return true;
            }
            return false;
        }

        public bool RemoveType(int MaLoaiPhong)
        {
            string sql_delete = "delete from LOAIPHONG where MaLoaiPhong= " + MaLoaiPhong;

            if (Process.ExecutiveNonQuery(sql_delete) > 0)
                return true;
            return false;
        }

        public bool Insert_Type(string TenLoaiPhong, ulong DonGia, uint SoNgToiDa)
        {
            string sql_insert = "";


            return true;
        }
    }
}

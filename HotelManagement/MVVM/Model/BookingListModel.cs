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
        public DataTable Load_On()  
        {
            DataTable re;
            string sql_select = "select *from KHACHHANG k,PHIEUTHUEPHONG p where k.MaKH = p.MaKH";
            re = Process.createTable(sql_select);
            return re; 
        }
    }
}

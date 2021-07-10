using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model.CheckOut
{
    class SurchargeModel
    {
        public DataTable load_surcharge()
        {
            DataTable re;
            string query = "select * from PHUTHU";
            re = Process.createTable(query);
            return re;
        }

        public DataTable update_surcharge(int _khachthu3, int _khachnuocngoai)
        {
            DataTable re;
            string query = "update PHUTHU " +
                "set KhachThu3 = " + _khachthu3 + ", KhachNuocNgoai = " + _khachnuocngoai;
            re = Process.createTable(query);
            return re;
        }
    }
}

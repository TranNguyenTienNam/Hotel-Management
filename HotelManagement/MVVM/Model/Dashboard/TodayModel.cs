using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class TodayModel
    {
        public int NumCheckin()
        {
            int Revenue;
            string sql_select =
                "SELECT count(*) from PHIEUTHUEPHONG where NgayBatDau = '" 
                + ConvertTimeFormat(DateTime.Today) + "' and TinhTrang = 'Check-in'";
            Revenue = Process.getNumber(sql_select);
            return Revenue;
        }
        public int NumCheckOut()
        {
            int value;
            string sql_select =
                "SELECT count(*) from PHIEUTHUEPHONG where NgayTraPhong = '" 
                + ConvertTimeFormat(DateTime.Today) + "' and TinhTrang = 'Check-out'";
            value = Process.getNumber(sql_select);
            return value;
        }
        public int NumMaxCheckin()
        {
            int value;
            string sql_select =
                "SELECT count(*) from PHIEUTHUEPHONG where NgayBatDau = '" + ConvertTimeFormat(DateTime.Today) + "'";
            value = Process.getNumber(sql_select);
            return value;
        }
        public int NumMaxCheckOut()
        {
            int value;
            string sql_select =
                "SELECT count(*) from PHIEUTHUEPHONG where NgayTraPhong = '" + ConvertTimeFormat(DateTime.Today) + "'";
            value = Process.getNumber(sql_select);
            return value;
        }
        private string ConvertTimeFormat(DateTime dateTime)
        {
            return dateTime.Month.ToString() + '-' + dateTime.Day.ToString() + '-' + dateTime.Year.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class GuestsModel
    {
        public int SelectedDateGuests(string selectedDate)
        {
            int Guests;
            string sql_select = 
                "SELECT sum(SoLuongKhach) from PHIEUTHUEPHONG where NgayTraPhong >= '" 
                + selectedDate + "' and NgayBatDau <= '" + selectedDate + "'";
            Guests = Process.getNumber(sql_select);
            return Guests;
        }
        public int SelectedMonthGuests(string selectedMonth)
        {
            int Guests;
            string sql_select =
                "SELECT sum(SoLuongKhach) from PHIEUTHUEPHONG where (MONTH(NgayTraPhong) = MONTH('"
                + selectedMonth + "') and YEAR(NgayTraPhong) = YEAR('" + selectedMonth
                + "')) or (MONTH(NgayBatDau) = MONTH('" + selectedMonth 
                + "') and YEAR(NgayBatDau) = YEAR('" + selectedMonth + "'))";
            Guests = Process.getNumber(sql_select);
            return Guests;
        }
        public int SelectedYearGuests(string selectedYear)
        {
            int Guests;
            string sql_select =
                "SELECT sum(SoLuongKhach) from PHIEUTHUEPHONG where (YEAR(NgayTraPhong) = YEAR('" + selectedYear
                + "')) or (YEAR(NgayBatDau) = YEAR('" + selectedYear + "'))";
            Guests = Process.getNumber(sql_select);
            return Guests;
        }
        public int PreviousDateGuests(string selectedDate)
        {
            int Guests;
            string sql_select =
                "SELECT sum(SoLuongKhach) from PHIEUTHUEPHONG where NgayTraPhong >= DATEADD(DAY,-1,'"
                + selectedDate + "') and NgayBatDau <= DATEADD(DAY,-1,'" + selectedDate + "')";
            Guests = Process.getNumber(sql_select);
            return Guests;
        }
        public int PreviousMonthGuests(string selectedMonth)
        {
            int Guests;
            string sql_select =
                "SELECT sum(SoLuongKhach) from PHIEUTHUEPHONG where (MONTH(NgayTraPhong) = MONTH(DATEADD(MONTH,-1,'"
                + selectedMonth + "')) and YEAR(NgayTraPhong) = YEAR('" + selectedMonth
                + "')) or (MONTH(NgayBatDau) = MONTH(DATEADD(MONTH,-1,'" + selectedMonth
                + "')) and YEAR(NgayBatDau) = YEAR('" + selectedMonth + "'))";
            Guests = Process.getNumber(sql_select);
            return Guests;
        }
        public int PreiousYearGuests(string selectedYear)
        {
            int Guests;
            string sql_select =
                "SELECT sum(SoLuongKhach) from PHIEUTHUEPHONG where (YEAR(NgayTraPhong) = YEAR(DATEADD(YEAR,-1,'" + selectedYear
                + "'))) or (YEAR(NgayBatDau) = YEAR(DATEADD(YEAR,-1,'" + selectedYear + "')))";
            Guests = Process.getNumber(sql_select);
            return Guests;
        }
    }
}

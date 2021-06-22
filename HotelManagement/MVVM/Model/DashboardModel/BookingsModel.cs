using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class BookingsModel
    {
        public DataTable DailyBookings(string selectedMonth)
        {
            DataTable Bookings;
            string sql_select =
                "SELECT TOP 100 PERCENT DAY(NgayLapPhieu) as N'Date', MONTH(NgayLapPhieu) as N'Month', YEAR(NgayLapPhieu) as N'Year', "
                + "count(*) as N'Bookings' from PHIEUTHUEPHONG where MONTH(NgayLapPhieu) = MONTH('"
                + selectedMonth + "') and YEAR(NgayLapPhieu) = YEAR('" + selectedMonth + "') "
                + "group by DAY(NgayLapPhieu), MONTH(NgayLapPhieu), YEAR(NgayLapPhieu) "
                + "order by DAY(NgayLapPhieu), MONTH(NgayLapPhieu), YEAR(NgayLapPhieu) asc";
            Bookings = Process.createTable(sql_select);
            return Bookings;
        }
        public DataTable MonthlyBookings(string selectedYear)
        {
            DataTable Bookings;
            string sql_select =
                "SELECT TOP 100 PERCENT MONTH(NgayLapPhieu) as N'Month', YEAR(NgayLapPhieu) as N'Year', "
                + "count(*) as N'Bookings' from PHIEUTHUEPHONG where YEAR(NgayLapPhieu) = YEAR('" + selectedYear + "') "
                + "group by MONTH(NgayLapPhieu), YEAR(NgayLapPhieu) "
                + "order by MONTH(NgayLapPhieu), YEAR(NgayLapPhieu) asc";
            Bookings = Process.createTable(sql_select);
            return Bookings;
        }
        public DataTable AnnualBookings()
        {
            DataTable Bookings;
            string sql_select =
                "SELECT TOP 100 PERCENT YEAR(NgayLapPhieu) as N'Year', "
                + "count(*) as N'Bookings' from PHIEUTHUEPHONG "
                + "group by YEAR(NgayLapPhieu) order by YEAR(NgayLapPhieu) asc";
            Bookings = Process.createTable(sql_select);
            return Bookings;
        }
        public DataTable DailyBookingsByRoomType(string TargetMonth)
        {
            DataTable BookingsByRoomType;
            string sql_select =
                "select top 100 percent TenLoaiPhong as N'RoomType', count(*) as N'Bookings' from PHIEUTHUEPHONG join " 
                + "(PHONG join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong) on PHIEUTHUEPHONG.MaPhong = PHONG.MaPhong "
                + "where MONTH(NgayLapPhieu) = MONTH('" + TargetMonth + "') and YEAR(NgayLapPhieu) = YEAR('" + TargetMonth + "') "
                + "group by TenLoaiPhong order by TenLoaiPhong asc";
            BookingsByRoomType = Process.createTable(sql_select);
            return BookingsByRoomType;
        }
        public DataTable MonthlyBookingsByRoomType(string TargetYear)
        {
            DataTable BookingsByRoomType;
            string sql_select =
                "select top 100 percent TenLoaiPhong as N'RoomType', count(*) as N'Bookings' from PHIEUTHUEPHONG join "
                + "(PHONG join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong) on PHIEUTHUEPHONG.MaPhong = PHONG.MaPhong "
                + "where YEAR(NgayLapPhieu) = YEAR('" + TargetYear + "') group by TenLoaiPhong order by TenLoaiPhong asc";
            BookingsByRoomType = Process.createTable(sql_select);
            return BookingsByRoomType;
        }
        public DataTable AnnualBookingsByRoomType()
        {
            DataTable BookingsByRoomType;
            string sql_select =
                "select top 100 percent TenLoaiPhong as N'RoomType', count(*) as N'Bookings' from PHIEUTHUEPHONG join "
                + "(PHONG join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong) on PHIEUTHUEPHONG.MaPhong = PHONG.MaPhong "
                + "group by TenLoaiPhong order by TenLoaiPhong asc";
            BookingsByRoomType = Process.createTable(sql_select);
            return BookingsByRoomType;
        }
        public int SelectedDateBookings(string selectedDate)
        {
            int Bookings;
            string sql_select = 
                "SELECT count(*) from PHIEUTHUEPHONG where NgayLapPhieu = '" + selectedDate + "'";
            Bookings = Process.getNumber(sql_select);
            return Bookings;
        }
        public int SelectedMonthBookings(string selectedMonth)
        {
            int Bookings;
            string sql_select = 
                "SELECT count(*) from PHIEUTHUEPHONG where MONTH(NgayLapPhieu) = MONTH('" 
                + selectedMonth + "') and YEAR(NgayLapPhieu) = YEAR('" + selectedMonth + "')";
            Bookings = Process.getNumber(sql_select);
            return Bookings;
        }
        public int SelectedYearBookings(string selectedYear)
        {
            int Bookings;
            string sql_select =
                "SELECT count(*) from PHIEUTHUEPHONG where YEAR(NgayLapPhieu) = YEAR('" + selectedYear + "')";
            Bookings = Process.getNumber(sql_select);
            return Bookings;
        }
        public int PreviousDateBookings(string selectedDate)
        {
            int Bookings;
            string sql_select =
                "SELECT count(*) from PHIEUTHUEPHONG where NgayLapPhieu = DATEADD(DAY,-1,'" + selectedDate + "')";
            Bookings = Process.getNumber(sql_select);
            return Bookings;
        }
        public int PreviousMonthBookings(string selectedMonth)
        {
            int Bookings;
            string sql_select =
                "SELECT count(*) from PHIEUTHUEPHONG where MONTH(NgayLapPhieu) = MONTH(DATEADD(MONTH,-1,'"
                + selectedMonth + "')) and YEAR(NgayLapPhieu) = YEAR('" + selectedMonth + "')";
            Bookings = Process.getNumber(sql_select);
            return Bookings;
        }
        public int PreviousYearBookings(string selectedYear)
        {
            int Bookings;
            string sql_select =
                "SELECT count(*) from PHIEUTHUEPHONG where YEAR(NgayLapPhieu) = YEAR(DATEADD(YEAR,-1,'" + selectedYear + "'))";
            Bookings = Process.getNumber(sql_select);
            return Bookings;
        }
    }
}

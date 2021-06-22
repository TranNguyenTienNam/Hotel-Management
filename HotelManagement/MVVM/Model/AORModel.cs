using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class AORModel
    {
        public int NumRooms()
        {
            int numRooms;
            string sql_select = "SELECT COUNT(*) from PHONG";
            numRooms = Process.getNumber(sql_select);
            return numRooms;
        }
        public int SelectedDateAOR(string selectedDate)
        {
            int AOR;
            string sql_select =
                "SELECT COUNT(PHONG.MaPhong) from PHONG inner join PHIEUTHUEPHONG on PHONG.MaPhong = PHIEUTHUEPHONG.MaPhong "
                + "where NgayTraPhong >= '" + selectedDate + "' and NgayBatDau <= '" + selectedDate + "' and PHIEUTHUEPHONG.TinhTrang <> 'booked'";
            AOR = Process.getNumber(sql_select);
            return AOR;
        }
        public int SelectedMonthAOR(string selectedMonth)
        {
            int AOR;
            string sql_select =
                "SELECT COUNT(PHONG.MaPhong) from PHONG inner join PHIEUTHUEPHONG on PHONG.MaPhong = PHIEUTHUEPHONG.MaPhong "
                + "where (MONTH(NgayTraPhong) = MONTH('" + selectedMonth + "') and YEAR(NgayTraPhong) = YEAR('" + selectedMonth
                + "')) or (MONTH(NgayBatDau) = MONTH('" + selectedMonth + "') and YEAR(NgayBatDau) = YEAR('" 
                + selectedMonth + "')) and PHIEUTHUEPHONG.TinhTrang <> 'booked'";
            AOR = Process.getNumber(sql_select);
            return AOR;
        }
        public int SelectedYearAOR(string selectedYear)
        {
            int AOR;
            string sql_select =
                "SELECT COUNT(PHONG.MaPhong) from PHONG inner join PHIEUTHUEPHONG on PHONG.MaPhong = PHIEUTHUEPHONG.MaPhong "
                + "where (YEAR(NgayTraPhong) = YEAR('" + selectedYear + "') or YEAR(NgayBatDau) = YEAR('"                
                + selectedYear + "')) and PHIEUTHUEPHONG.TinhTrang <> 'booked'";
            AOR = Process.getNumber(sql_select);
            return AOR;
        }
        public int PreviousDateAOR(string selectedDate)
        {
            int AOR;
            string sql_select =
                "SELECT COUNT(PHONG.MaPhong) from PHONG inner join PHIEUTHUEPHONG on PHONG.MaPhong = PHIEUTHUEPHONG.MaPhong "
                + "where NgayTraPhong >= DATEADD(DAY,-1,'" + selectedDate + "') and NgayBatDau <=  DATEADD(DAY,-1,'" 
                + selectedDate + "') and PHIEUTHUEPHONG.TinhTrang <> 'booked'";
            AOR = Process.getNumber(sql_select);
            return AOR;
        }
        public int PreviousMonthAOR(string selectedMonth)
        {
            int AOR;
            string sql_select =
                "SELECT COUNT(PHONG.MaPhong) from PHONG inner join PHIEUTHUEPHONG on PHONG.MaPhong = PHIEUTHUEPHONG.MaPhong "
                + "where (MONTH(NgayTraPhong) = MONTH(DATEADD(MONTH,-1,'" + selectedMonth + "')) and YEAR(NgayTraPhong) = YEAR('" + selectedMonth
                + "')) or (MONTH(NgayBatDau) = MONTH(DATEADD(MONTH,-1,'" + selectedMonth + "')) and YEAR(NgayBatDau) = YEAR('"
                + selectedMonth + "')) and PHIEUTHUEPHONG.TinhTrang <> 'booked'";
            AOR = Process.getNumber(sql_select);
            return AOR;
        }
        public int PreiousYearAOR(string selectedYear)
        {
            int AOR;
            string sql_select =
                "SELECT COUNT(PHONG.MaPhong) from PHONG inner join PHIEUTHUEPHONG on PHONG.MaPhong = PHIEUTHUEPHONG.MaPhong "
                + "where (YEAR(NgayTraPhong) = YEAR(DATEADD(YEAR,-1,'" + selectedYear + "')) or YEAR(NgayBatDau) = YEAR(DATEADD(YEAR,-1,'"
                + selectedYear + "'))) and PHIEUTHUEPHONG.TinhTrang <> 'booked'";
            AOR = Process.getNumber(sql_select);
            return AOR;
        }
    }
}

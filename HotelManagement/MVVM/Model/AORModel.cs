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
        public DataTable DailyAOR(string TargetMonth)
        {
            DataTable AOR;
            string sql_select =
                "SELECT TOP 100 PERCENT DAY(NgayTraPhong) as N'Date', MONTH(NgayTraPhong) as N'Month', YEAR(NgayTraPhong) as N'Year', "
                + "CAST(COUNT(PHONG.MaPhong) as float)/CAST((SELECT COUNT(*) from PHONG) as float)*100 as N'AOR' "
                + "from PHONG inner join PHIEUTHUEPHONG on PHONG.MaPhong = PHIEUTHUEPHONG.MaPhong "
                + "where MONTH(NgayTraPhong) = MONTH('" + TargetMonth + "') and YEAR(NgayTraPhong) = YEAR('" + TargetMonth + "') "
                + "and PHIEUTHUEPHONG.TinhTrang <> 'booked' "
                + "group by DAY(NgayTraPhong), MONTH(NgayTraPhong), YEAR(NgayTraPhong) "
                + "order by DAY(NgayTraPhong), MONTH(NgayTraPhong), YEAR(NgayTraPhong) asc";
            AOR = Process.createTable(sql_select);
            return AOR;
        }
        public DataTable MonthlyAOR(string TargetYear)
        {
            DataTable AOR;
            string sql_select =
                "SELECT TOP 100 PERCENT MONTH(NgayTraPhong) as N'Month', YEAR(NgayTraPhong) as N'Year', "
                + "CAST(COUNT(PHONG.MaPhong) as float)/CAST((SELECT COUNT(*) from PHONG) as float)*100 as N'AOR' "
                + "from PHONG inner join PHIEUTHUEPHONG on PHONG.MaPhong = PHIEUTHUEPHONG.MaPhong "
                + "where YEAR(NgayTraPhong) = YEAR('" + TargetYear + "') "
                + "and PHIEUTHUEPHONG.TinhTrang <> 'booked' "
                + "group by MONTH(NgayTraPhong), YEAR(NgayTraPhong) "
                + "order by MONTH(NgayTraPhong), YEAR(NgayTraPhong) asc";
            AOR = Process.createTable(sql_select);
            return AOR;
        }
        public DataTable AnnualAOR()
        {
            DataTable AOR;
            string sql_select =
                "SELECT TOP 100 PERCENT YEAR(NgayTraPhong) as N'Year', "
                + "CAST(COUNT(PHONG.MaPhong) as float)/CAST((SELECT COUNT(*) from PHONG) as float)*100 as N'AOR' "
                + "from PHONG inner join PHIEUTHUEPHONG on PHONG.MaPhong = PHIEUTHUEPHONG.MaPhong "
                + "where PHIEUTHUEPHONG.TinhTrang <> 'booked' "
                + "group by YEAR(NgayTraPhong) order by YEAR(NgayTraPhong) asc";
            AOR = Process.createTable(sql_select);
            return AOR;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class RevenueModel
    {
        public DataTable DailyRevenue(string TargetMonth)
        {
            DataTable Revenue;
            string sql_select =
                ";with RevenueShow as (SELECT TOP 100 PERCENT DAY(NgayTraPhong) as N'Date', MONTH(NgayTraPhong) as N'Month', YEAR(NgayTraPhong) as N'Year', "
                + "sum(TongTien) as N'Revenue' from HOADON join PHIEUTHUEPHONG on HOADON.MaPhieuThue = PHIEUTHUEPHONG.MaPhieuThue "
                + "where MONTH(NgayTraPhong) = MONTH('" + TargetMonth + "') and YEAR(NgayTraPhong) = YEAR('" + TargetMonth + "') "
                + "group by DAY(NgayTraPhong), MONTH(NgayTraPhong), YEAR(NgayTraPhong) "
                + "order by DAY(NgayTraPhong), MONTH(NgayTraPhong), YEAR(NgayTraPhong) asc) "
                + "select * from RevenueShow";
            Revenue = Process.createTable(sql_select);
            return Revenue;
        }
        public DataTable MonthlyRevenue(string TargetYear)
        {
            DataTable Revenue;
            string sql_select =
                ";with RevenueShow as (SELECT TOP 100 PERCENT MONTH(NgayTraPhong) as N'Month', YEAR(NgayTraPhong) as N'Year', "
                + "sum(TongTien) as N'Revenue' from HOADON join PHIEUTHUEPHONG on HOADON.MaPhieuThue = PHIEUTHUEPHONG.MaPhieuThue "
                + "where YEAR(NgayTraPhong) = YEAR('" + TargetYear + "') " 
                + "group by MONTH(NgayTraPhong), YEAR(NgayTraPhong) "
                + "order by MONTH(NgayTraPhong), YEAR(NgayTraPhong) asc) "
                + "select * from RevenueShow";
            Revenue = Process.createTable(sql_select);
            return Revenue;
        }
        public DataTable AnnualRevenue()
        {
            DataTable Revenue;
            string sql_select =
                ";with RevenueShow as (SELECT TOP 100 PERCENT YEAR(NgayTraPhong) as N'Year', "
                + "sum(TongTien) as N'Revenue' from HOADON join PHIEUTHUEPHONG on HOADON.MaPhieuThue = PHIEUTHUEPHONG.MaPhieuThue "
                + "group by YEAR(NgayTraPhong) order by YEAR(NgayTraPhong) asc) "
                + "select * from RevenueShow";
            Revenue = Process.createTable(sql_select);
            return Revenue;
        }
        public DataTable DailyRevByRoomType(string TargetMonth)
        {
            DataTable RevByRoomType;
            string sql_select =
                "select top 100 percent TenLoaiPhong as N'RoomType', sum(TongTien) as N'Revenue' "
                + "from HOADON join (PHIEUTHUEPHONG join (PHONG join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong) "
                + "on PHIEUTHUEPHONG.MaPhong = PHONG.MaPhong) on HOADON.MaPhieuThue = PHIEUTHUEPHONG.MaPhieuThue "
                + "where MONTH(NgayTraPhong) = MONTH('" + TargetMonth + "') and YEAR(NgayTraPhong) = YEAR('" + TargetMonth + "') "
                + "group by TenLoaiPhong order by sum(TongTien) asc";
            RevByRoomType = Process.createTable(sql_select);
            return RevByRoomType;
        }
        public DataTable MonthlyRevByRoomType(string TargetYear)
        {
            DataTable RevByRoomType;
            string sql_select =
                "select top 100 percent TenLoaiPhong as N'RoomType', sum(TongTien) as N'Revenue' "
                + "from HOADON join (PHIEUTHUEPHONG join (PHONG join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong) "
                + "on PHIEUTHUEPHONG.MaPhong = PHONG.MaPhong) on HOADON.MaPhieuThue = PHIEUTHUEPHONG.MaPhieuThue "
                + "where YEAR(NgayTraPhong) = YEAR('" + TargetYear + "') "
                + "group by TenLoaiPhong order by sum(TongTien) asc";
            RevByRoomType = Process.createTable(sql_select);
            return RevByRoomType;
        }
        public DataTable AnnualRevByRoomType()
        {
            DataTable RevByRoomType;
            string sql_select =
                "select top 100 percent TenLoaiPhong as N'RoomType', sum(TongTien) as N'Revenue' "
                + "from HOADON join (PHIEUTHUEPHONG join (PHONG join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong) "
                + "on PHIEUTHUEPHONG.MaPhong = PHONG.MaPhong) on HOADON.MaPhieuThue = PHIEUTHUEPHONG.MaPhieuThue "
                + "group by TenLoaiPhong order by sum(TongTien) asc";
            RevByRoomType = Process.createTable(sql_select);
            return RevByRoomType;
        }
    }
}

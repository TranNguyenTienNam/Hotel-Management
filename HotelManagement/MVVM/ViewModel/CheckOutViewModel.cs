using HotelManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core;
using System.Data;
using HotelManagement.MVVM.Model;
using HotelManagement.Object.minh_objects;


namespace HotelManagement.MVVM.ViewModel
{
    class CheckOutViewModel : ObservableObject
    {
        private ObservableCollection<rentFullInfo> _rentFullInfos;
        public ObservableCollection<rentFullInfo> rentFullInfos { get => _rentFullInfos; set { _rentFullInfos = value; OnPropertyChanged(); } }

        public CheckOutViewModel()
        {
            loadListCheckin();
        }

        void loadListCheckin()
        {
            rentFullInfos = new ObservableCollection<rentFullInfo>();

            CheckOutModel model = new CheckOutModel();
            DataTable data = new DataTable();
            data = model.get_list_checkout();

            foreach (DataRow row in data.Rows)
            {
                var obj = new rentFullInfo()
                {
                    
                    MaPhieuThue=(int)row["MaPhieuThue"],
                    NgayBatDau = (DateTime)row["NgayBatDau"],
                    NgayTraPhong = (row["NgayTraPhong"] == DBNull.Value ? DateTime.Now.Date : (DateTime)row["NgayTraPhong"]),
                    SoLuongKhach = (int)row["SoLuongKhach"],
                    TinhTrang = (string)row["TinhTrang"],
                    NguoiLapPhieu = (int)row["NguoiLapPhieu"],
                    TienCoc = (decimal)row["TienCoc"],

                    MaKH=(int)row["MaKH"],
                    TenKH = (string)row["TenKH"],
                    CMND = (string)row["CMND"],
                    SoDienThoai = (string)row["SoDienThoai"],
                    DiaChi = (string)row["DiaChi"],
                    GioiTinh = (string)row["GioiTinh"],

                    MaLoaiKhach = (int)row["MaLoaiKhach"],
                    TenLoaiKhach = (string)row["TenLoaiKhach"],

                    MaPhong = (int)row["MaPhong"],
                    TenPhong = (string)row["TenPhong"],
              
                    GhiChu = (row["GhiChu"] != null) ? string.Empty : (string)row["GhiChu"],

                    MaLoaiPhong = (int)row["MaLoaiPhong"],
                    TenLoaiPhong = (string)row["TenLoaiPhong"],
                    DonGia = (decimal)row["DonGia"],
                    SoNgToiDa = (int)row["SoNgToiDa"],

                };
                rentFullInfos.Add(obj);
            }
        }
    }

}

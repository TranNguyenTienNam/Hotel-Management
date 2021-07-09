using HotelManagement.Object;
using System;
using System.Collections.ObjectModel;
using HotelManagement.Core;
using System.Data;
using HotelManagement.MVVM.Model;
using System.Windows.Input;
using HotelManagement.MVVM.View.CheckOutViews;
using HotelManagement.MVVM.ViewModel.CheckOutViewModels;

namespace HotelManagement.MVVM.ViewModel
{
    class CheckOutViewModel : ObservableObject
    {
        public static CheckOutViewModel Instance => new CheckOutViewModel();
        private ObservableCollection<CheckOutItemViewModel> _items;
        public ObservableCollection<CheckOutItemViewModel> Items { get { return _items; } set { _items = value; OnPropertyChanged("Items"); } }

        public ICommand BillsCommand { get; set; }
        public ICommand SurchargeCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand CheckOutCommand { get; set; }

        public CheckOutViewModel()
        {
            //loadListRent();

            BillsCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                //showBillsView();
            });

            SurchargeCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                //showSurchargeView();
            });
        }

        void loadListRent()
        {
            Items = new ObservableCollection<CheckOutItemViewModel>();
            DataTable data = new DataTable();
            CheckOutModel model = new CheckOutModel();

            data = model.Load_List_Rent();

            foreach (DataRow row in data.Rows)
            {
                var obj = new CheckOutItemViewModel()
                {
                    MaPhieuThue = (int)row["MaPhieuThue"],
                    NgayLapPhieu = (DateTime)row["NgayLapPhieu"],
                    NgayBatDau = (DateTime)row["NgayBatDau"],
                    NgayTraPhong = (row["NgayTraPhong"] == DBNull.Value ? DateTime.Now.Date : (DateTime)row["NgayTraPhong"]),
                    SoLuongKhach = (int)row["SoLuongKhach"],
                    TinhTrang = (string)row["TinhTrang"],
                    NguoiLapPhieu = (int)row["NguoiLapPhieu"],
                    TienCoc = (int)row["TienCoc"],

                    MaKH = (int)row["MaKH"],
                    TenKH = (string)row["TenKH"],
                    CMND = (string)row["CMND"],
                    SoDienThoai = (string)row["SoDienThoai"],
                    DiaChi = (string)row["DiaChi"],
                    GioiTinh = (string)row["GioiTinh"],

                    MaLoaiKhach = (int)row["MaLoaiKhach"],
                    TenLoaiKhach = (string)row["TenLoaiKhach"],

                    MaPhong = (int)row["MaPhong"],
                    TenPhong = (string)row["TenPhong"],

                    GhiChu = (row["GhiChu"] == DBNull.Value) ? string.Empty : (string)row["GhiChu"],

                    MaLoaiPhong = (int)row["MaLoaiPhong"],
                    TenLoaiPhong = (string)row["TenLoaiPhong"],
                    DonGia = (int)row["DonGia"],
                    SoNgToiDa = (int)row["SoNgToiDa"]
                };
                Items.Add(obj);
            }
        }
        void showBillsView()
        {
            BillsView bv = new BillsView();
            bv.ShowDialog();
        }
        void showSurchargeView()
        {
            SurchargeView sv = new SurchargeView();
            sv.ShowDialog();
        }
    }
}

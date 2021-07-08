using HotelManagement.Object;
using System;
using System.Collections.ObjectModel;
using HotelManagement.Core;
using System.Data;
using HotelManagement.MVVM.Model;
using System.Windows.Controls;
using System.Windows.Input;
using HotelManagement.MVVM.View.CheckOutViews;
using HotelManagement.MVVM.ViewModel.CheckOutViewModels;
using HotelManagement.MVVM.Model.CheckOut;
using System.Windows;

namespace HotelManagement.MVVM.ViewModel
{
    class CheckOutViewModel : ObservableObject
    {
        public static CheckOutViewModel Instance => new CheckOutViewModel();
        private ObservableCollection<CheckOutItemViewModel> _items;
        public ObservableCollection<CheckOutItemViewModel> Items { get { return _items; } set { _items = value; OnPropertyChanged("Items"); } }

        private int _maPhieuThue;
        public int MaPhieuThue { get { return _maPhieuThue; } set { _maPhieuThue = value; OnPropertyChanged(); } }

        private int _maphong;
        public int MaPhong { get { return _maphong; } set { _maphong = value; OnPropertyChanged(); } }

        private int _maKH;
        public int MaKH { get { return _maKH; } set { _maKH = value; OnPropertyChanged(); } }

        private DateTime _ngayBatDau;
        public DateTime NgayBatDau { get { return _ngayBatDau; } set { _ngayBatDau = value; OnPropertyChanged(); } }

        private DateTime _ngayTraPhong;
        public DateTime NgayTraPhong { get { return _ngayTraPhong; } set { _ngayTraPhong = value; OnPropertyChanged(); } }

        private int _soLuongKhach;
        public int SoLuongKhach { get { return _soLuongKhach; } set { _soLuongKhach = value; OnPropertyChanged(); } }

        private String _tinhTrang;
        public String TinhTrang { get { return _tinhTrang; } set { _tinhTrang = value; OnPropertyChanged(); } }

        private int _nguoiLapPhieu;
        public int NguoiLapPhieu { get { return _nguoiLapPhieu; } set { _nguoiLapPhieu = value; OnPropertyChanged(); } }

        private int _tiencoc;
        public int TienCoc { get { return _tiencoc; } set { _tiencoc = value; OnPropertyChanged(); } }

        private DateTime _ngayLapPhieu;
        public DateTime NgayLapPhieu { get { return _ngayLapPhieu; } set { _ngayLapPhieu = value; OnPropertyChanged(); } }

        private String _tenKhachHang;
        public String TenKH { get { return _tenKhachHang; } set { _tenKhachHang = value; OnPropertyChanged(); } }

        private String _CMND;
        public String CMND { get { return _CMND; } set { _CMND = value; OnPropertyChanged(); } }

        private String _soDienThoai;
        public String SoDienThoai { get { return _soDienThoai; } set { _soDienThoai = value; OnPropertyChanged(); } }

        private String _diaChi;
        public String DiaChi { get { return _diaChi; } set { _diaChi = value; OnPropertyChanged(); } }

        private String _gioiTinh;
        public String GioiTinh { get { return _gioiTinh; } set { _gioiTinh = value; OnPropertyChanged(); } }

        int _maLoaiKhach;
        public int MaLoaiKhach { get { return _maLoaiKhach; } set { _maLoaiKhach = value; OnPropertyChanged(); } }

        private String _tenLoaiKhach;
        public String TenLoaiKhach { get { return _tenLoaiKhach; } set { _tenLoaiKhach = value; OnPropertyChanged(); } }

        private String _tenPhong;
        public String TenPhong { get { return _tenPhong; } set { _tenPhong = value; OnPropertyChanged(); } }

        private int _donGia;
        public int DonGia { get { return _donGia; } set { _donGia = value; OnPropertyChanged(); } }

        private int _soNguoiToiDa;
        public int SoNgToiDa { get { return _soNguoiToiDa; } set { _soNguoiToiDa = value; OnPropertyChanged(); } }

        private String _ghiChu;
        public String GhiChu { get { return _ghiChu; } set { _ghiChu = value; OnPropertyChanged(); } }

        private int _maLoaiPhong;
        public int MaLoaiPhong { get { return _maLoaiPhong; } set { _maLoaiPhong = value; OnPropertyChanged(); } }

        private String _tenLoaiPhong;
        public String TenLoaiPhong { get { return _tenLoaiPhong; } set { _tenLoaiPhong = value; OnPropertyChanged(); } }
        // thuộc tính thêm 
        private int _soNgayThue;
        public int SoNgayThue { get { return _soNgayThue; } set { _soNgayThue = value; OnPropertyChanged(); } }

        private int _phuThu;
        public int PhuThu { get { return _phuThu; } set { _phuThu = value; OnPropertyChanged(); } }

        private int _tongTienPhong;
        public int TongTienPhong { get { return _tongTienPhong; } set { _tongTienPhong = value; OnPropertyChanged(); } }

        private int _tongTien;
        public int TongTien { get { return _tongTien; } set { _tongTien = value; OnPropertyChanged(); } }

        public ICommand BillsCommand { get; set; }
        public ICommand SurchargeCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand CheckOutCommand { get; set; }

        public ICommand SelectRowCommand { get; set; }
        public ICommand PickCheckOutDate { get; set; }

        public CheckOutViewModel()
        {
            loadListRent();

            BillsCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                showBillsView();
            });

            SurchargeCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                showSurchargeView();
            });

            SelectRowCommand = new RelayCommand<ListView>((p) =>
            {               
                if(p.Items.IsEmpty)
                {
                    return false;
                }                
                return true;
            }, (p) =>
            {
                var Item = p.SelectedItem as CheckOutItemViewModel;
                TenKH = Item.TenKH;
                GioiTinh = Item.GioiTinh;
                TenLoaiKhach = Item.TenLoaiKhach;
                DiaChi = Item.DiaChi;
                CMND = Item.CMND;
                SoDienThoai = Item.SoDienThoai;
                TenPhong = Item.TenPhong;
                TenLoaiPhong = Item.TenLoaiPhong;
                DonGia = Item.DonGia;
                SoLuongKhach = Item.SoLuongKhach;
                NgayBatDau = Item.NgayBatDau;
                NgayTraPhong = Item.NgayTraPhong;
                TienCoc = Item.TienCoc;
                SoNgayThue = getDays(Item.NgayBatDau, Item.NgayTraPhong);
                TongTienPhong = Item.DonGia * SoNgayThue;
                PhuThu = getSurchargeMoney(SoLuongKhach, SoNgayThue, TongTienPhong, Item.MaLoaiPhong);
                TongTien = TongTienPhong + PhuThu - TienCoc;
            });

            PickCheckOutDate = new RelayCommand<DatePicker>((p) =>
            {
                if (p.SelectedDate < NgayBatDau)
                {
                    MessageBox.Show("Ngày Check-out không được nhỏ hơn ngày Check-in !");
                    return false;
                }
                if(string.IsNullOrEmpty(TenKH))
                {
                    return false;
                }

                return true;
            }, (p) =>
            {
                NgayTraPhong = (p.SelectedDate.HasValue ? p.SelectedDate.Value.Date : NgayBatDau);
                SoNgayThue = getDays(NgayBatDau, NgayTraPhong);
                TongTienPhong = DonGia * SoNgayThue;
                PhuThu = getSurchargeMoney(SoLuongKhach, SoNgayThue, TongTienPhong, MaLoaiPhong);
                TongTien = TongTienPhong + PhuThu - TienCoc;
            });

        }
        public int getDays(DateTime ngayBD, DateTime ngayTP )
        {
            DateTime bd = ngayBD.Date;
            DateTime tp = ngayTP.Date;
            string re = tp.Subtract(bd).TotalDays.ToString();
            return int.Parse(re);
        }
        public int getSurchargeMoney(int soLuongkhach, int soNgayThue, int tongTienPhong, int maLoaiPhog)
        {
            int re = 0;
            SurchargeModel surchargeModel = new SurchargeModel();
            int tyLePhuThu = surchargeModel.Get_surcharge_more_client();
            int soNguoiToiDa = surchargeModel.Get_maximun_clients(maLoaiPhog);
            if(soLuongkhach > soNguoiToiDa)
            {
                re = (soLuongkhach - soNguoiToiDa) * tyLePhuThu * tongTienPhong;
            }
            return re/100;
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

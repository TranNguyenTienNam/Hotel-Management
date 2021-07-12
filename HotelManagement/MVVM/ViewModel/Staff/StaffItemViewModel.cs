using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Core;
using System.Data;
using HotelManagement.MVVM.Model;
using System.Collections.ObjectModel;
using HotelManagement.Object;
using System.Windows.Input;
using HotelManagement.MVVM.View;
using System.Windows;
using System.Windows.Threading;
using HotelManagement.MVVM.View.Staff;
using HotelManagement.MVVM.ViewModel.Staff;

namespace HotelManagement.MVVM.ViewModel
{
    public class StaffItemViewModel : ObservableObject
    {
        public static StaffItemViewModel Instance => new StaffItemViewModel();
        
        private int maNguoiDung;
        public int MaNguoiDung { get { return maNguoiDung; } set { maNguoiDung = value; OnPropertyChanged(); } }

        private string tenTaiKhoan;
        public string TenTaiKhoan { get { return tenTaiKhoan; } set { tenTaiKhoan = value; OnPropertyChanged(); } }

        private string tenNhanVien;
        public string TenNhanVien { get { return tenNhanVien; } set { tenNhanVien = value; OnPropertyChanged(); } }

        private string soDienThoai;
        public string SoDienThoai { get { return soDienThoai; } set { soDienThoai = value; OnPropertyChanged(); } }

        private string gioiTinh;
        public string GioiTinh { get { return gioiTinh; } set { gioiTinh = value; OnPropertyChanged(); } }

        private string email;
        public string Email { get { return email; } set { email = value; OnPropertyChanged(); } }

        private string ngaySinh;
        public string NgaySinh { get { return ngaySinh; } set { ngaySinh = value; OnPropertyChanged(); } }

        private string quyenHan;
        public string QuyenHan { get { return quyenHan; } set { quyenHan = value; OnPropertyChanged(); } }

        private bool isBlocked;
        public bool IsBlocked { get { return isBlocked; } set { isBlocked = value; OnPropertyChanged(); } }

        private bool isPromoted;
        public bool IsPromoted { get { return isPromoted; } set { isPromoted = value; OnPropertyChanged(); } }

        public bool IsSelected { get; set; }

        public ICommand SendMailCommand { get; set; }
        public ICommand BlockOrUnblockStaffAccountCommand { get; set; }
        public ICommand PromoteOrDemoteStaffAccountCommand { get; set; }

        public StaffItemViewModel()
        {
            SendMailCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                SendMail();
            });

            BlockOrUnblockStaffAccountCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                BlockOrUnblockStaffAccount();            
            });

            PromoteOrDemoteStaffAccountCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => 
            {
                PromoteOrDemoteStaffAccount();
            });
        }

        void SendMail()
        {
            NewMessageView wd = new NewMessageView();
            wd.DataContext = new NewMessageViewModel(Email);
            wd.Show();
        }

        void BlockOrUnblockStaffAccount()
        {
            StaffModel model = new StaffModel();
            if (IsBlocked)
            {
                model.UnblockStaff(MaNguoiDung);
                IsBlocked = false;
            }
            else
            {
                model.BlockStaff(MaNguoiDung);
                IsBlocked = true;
            }
        }

        void PromoteOrDemoteStaffAccount()
        {
            StaffModel model = new StaffModel();
            if (IsPromoted)
            {
                model.DemoteStaff(MaNguoiDung);
                QuyenHan = "Staff";
                IsPromoted = false;
            }
            else
            {
                model.PromoteStaff(MaNguoiDung);
                QuyenHan = "Manager";
                IsPromoted = true;
            }
        }
    }
}

﻿using System;
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

        private string hoNhanVien;
        public string HoNhanVien { get { return hoNhanVien; } set { hoNhanVien = value; OnPropertyChanged(); } }

        private string soDienThoai;
        public string SoDienThoai { get { return soDienThoai; } set { soDienThoai = value; OnPropertyChanged(); } }

        private string gioiTinh;
        public string GioiTinh { get { return gioiTinh; } set { gioiTinh = value; OnPropertyChanged(); } }

        private string email;
        public string Email { get { return email; } set { email = value; OnPropertyChanged(); } }

        private DateTime ngaySinh;
        public DateTime NgaySinh { get { return ngaySinh; } set { ngaySinh = value; OnPropertyChanged(); } }

        private bool isBlocked;
        public bool IsBlocked { get { return isBlocked; } set { isBlocked = value; OnPropertyChanged(); } }

        public bool IsSelected { get; set; }

        public ICommand EditRoomCommand { get; set; }
        public ICommand BlockOrUnblockStaffAccountCommand { get; set; }

        public StaffItemViewModel()
        {
            BlockOrUnblockStaffAccountCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                BlockOrUnblockStaffAccount();            
            });
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
    }
}
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
    public class RoomListItemViewModel : ObservableObject
    {
        public static RoomListItemViewModel Instance => new RoomListItemViewModel();
        
        private int _maphong;
        public int MaPhong { get { return _maphong; } set { _maphong = value; OnPropertyChanged(); } }

        private string _tenphong;
        public string TenPhong { get { return _tenphong; } set { _tenphong = value; OnPropertyChanged(); } }

        private string _loaiphong;
        public string LoaiPhong { get { return _loaiphong; } set { _loaiphong = value; OnPropertyChanged("LoaiPhong"); } }

        private decimal _dongia;
        public decimal DonGia { get { return _dongia; } set { _dongia = value; OnPropertyChanged(); } }

        private int _soNgtoida;
        public int SoNgToiDa { get { return _soNgtoida; } set { _soNgtoida = value; OnPropertyChanged(); } }

        private string _ghichu;
        public string GhiChu { get { return _ghichu; } set { _ghichu = value; OnPropertyChanged(); } }

        public bool IsSelected { get; set; }

        public ICommand EditRoomCommand { get; set; }
        public ICommand RemoveRoomCommand { get; set; }

        public RoomListItemViewModel()
        {
            EditRoomCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => 
            {
                //check room còn trống hay không?
                
                EditRoomView wd = new EditRoomView(MaPhong, TenPhong, LoaiPhong, DonGia, SoNgToiDa, GhiChu);
                wd.ShowDialog();
            });

            RemoveRoomCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                //check room còn trống hay không?

                RoomsListModel model = new RoomsListModel();
                //RoomListViewModel.Instance.Items.Remove(RoomListViewModel.Instance.Items.Where(X => X.MaPhong == MaPhong).Single());
                //MessageBox.Show(RoomListViewModel.Instance.Items.Where(X => X.MaPhong == MaPhong).Single().MaPhong.ToString());
                //RoomListViewModel.Instance.Items.RemoveAt();
                
                if (model.RemoveRoom(MaPhong))
                {
                    MessageBox.Show("Room has been Removed");
                }    
                
            });
        }

        
    }
}
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

namespace HotelManagement.MVVM.ViewModel
{
    public class RoomListItemViewModel : ObservableObject
    {
        public static RoomListItemViewModel Instance => new RoomListItemViewModel();
        
        //danh sach loai phong
        public List<string> types { get; set; }

        private int _maphong;
        public int MaPhong { get { return _maphong; } set { _maphong = value; OnPropertyChanged(); } }

        private string _tenphong;
        public string TenPhong { get { return _tenphong; } set { _tenphong = value; OnPropertyChanged(); } }

        private string _loaiphong;
        public string LoaiPhong { get { return _loaiphong; } set { _loaiphong = value; OnPropertyChanged("Type"); } }

        private decimal _dongia;
        public decimal DonGia { get { return _dongia; } set { _dongia = value; OnPropertyChanged(); } }

        private int _soNgtoida;
        public int SoNgToiDa { get { return _soNgtoida; } set { _soNgtoida = value; OnPropertyChanged(); } }

        private string _ghichu;
        public string GhiChu { get { return _ghichu; } set { _ghichu = value; OnPropertyChanged(); } }

        public bool IsSelected { get; set; }

        public ICommand EditRoomCommand { get; set; }
        public ICommand SaveEditCommand { get; set; }

        public RoomListItemViewModel()
        {
            types = RoomsViewModel.Instance.Types;

            EditRoomCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) => 
            {
                //check room còn trống hay không?
                
                EditRoomView wd = new EditRoomView(MaPhong, TenPhong, LoaiPhong, DonGia, SoNgToiDa, GhiChu);
                wd.ShowDialog();
            });

            SaveEditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenPhong))
                    return false;
                else
                    return true;
            }, (p) => 
            {
                try
                {
                    RoomListModel model = new RoomListModel();
                    int MaLoaiPhong = -1;
                    foreach (roomtype rt in RoomsViewModel.Instance.roomTypes)
                    {
                        if (LoaiPhong == rt.TenLoaiPhong)
                        {
                            MaLoaiPhong = rt.MaLoaiPhong;
                            break;
                        }
                    }

                    MessageBox.Show(MaPhong + TenPhong + MaLoaiPhong + GhiChu);
                    if (model.Save_RoomEdited(MaPhong, TenPhong, MaLoaiPhong, GhiChu))
                    {
                        MessageBox.Show("Room has been edited.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    
            });
        }

        private void OnPropertyChanged(string propertyName)
        {
            try
            {
                foreach (roomtype rt in RoomsViewModel.Instance.roomTypes)
                {
                    if (LoaiPhong == rt.TenLoaiPhong)
                    {
                        DonGia = rt.DonGia;
                        SoNgToiDa = rt.SoNgToiDa;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

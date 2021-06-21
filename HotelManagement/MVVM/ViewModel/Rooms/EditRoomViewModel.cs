using HotelManagement.Core;
using HotelManagement.MVVM.Model;
using HotelManagement.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelManagement.MVVM.ViewModel
{
    class EditRoomViewModel : ObservableObject
    {
        public static EditRoomViewModel Instance => new EditRoomViewModel();
        private RoomListItemViewModel _item;
        public RoomListItemViewModel Item { get { return _item; } set { _item = value; OnPropertyChanged(); } }

        //danh sach loai phong
        public List<string> types { get; set; }

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

        public ICommand SaveEditCommand { get; set; }
        public ICommand testcommand { get; set; }

        public EditRoomViewModel()
        {
            types = RoomsViewModel.Instance.Types;
            Item = RoomListItemViewModel.Instance;
            MessageBox.Show(MaPhong + TenPhong);
            SaveEditCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(TenPhong) || GhiChu == null)
                    return false;
                else
                    return true;

            }, (p) =>
            {
                try
                {
                    RoomsListModel model = new RoomsListModel();

                    //get MaLoaiPhong
                    int MaLoaiPhong = -1;
                    foreach (roomtype rt in RoomsViewModel.Instance.roomTypes)
                    {
                        if (LoaiPhong == rt.TenLoaiPhong)
                        {
                            MaLoaiPhong = rt.MaLoaiPhong;
                            break;
                        }
                    }
                    MessageBox.Show(TenPhong + GhiChu);
                    /*
                    if (model.Save_RoomEdited(MaPhong, TenPhong, MaLoaiPhong, GhiChu))
                    {
                        MessageBox.Show("Room has been edited.");
                    }
                    */
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            });

            testcommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                TenPhong = p.Text;
                MessageBox.Show(p.Text + TenPhong);
            });
        }

        public void loadRoom(int MaPhong)
        {
            RoomsListModel model = new RoomsListModel();
            DataTable dataTable = new DataTable();
            dataTable = model.getRoom(MaPhong);
            foreach (DataRow row in dataTable.Rows)
            {
                TenPhong = (string)row["TenPhong"];
                LoaiPhong = (string)row["TenLoaiPhong"];
                DonGia = (decimal)row["DonGia"];
                SoNgToiDa = (int)row["SoNgToiDa"];
                GhiChu = (row["GhiChu"] == DBNull.Value) ? "" : (string)row["GhiChu"];
            }    
        }

        private void OnPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case "LoaiPhong":
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
                    break;
                default:
                    break;
            }

        }
    }
}

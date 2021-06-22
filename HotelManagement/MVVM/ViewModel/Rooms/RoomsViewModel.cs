using HotelManagement.Object;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using HotelManagement.Core;
using System.Data;
using HotelManagement.MVVM.Model;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using HotelManagement.MVVM.View;

namespace HotelManagement.MVVM.ViewModel
{
    class RoomsViewModel : ObservableObject
    {
        public static RoomsViewModel Instance => new RoomsViewModel();
        private ObservableCollection<roomtype> _roomTypes;
        public ObservableCollection<roomtype> roomTypes { get { return _roomTypes; } set { _roomTypes = value; OnPropertyChanged(); } }

        //Combobox Room type:
        private List<string> _types;
        public List<string> Types { get { return _types; } set { _types = value; OnPropertyChanged(); } }

        //Textbox Room name
        private string _rname;
        public string RName { get { return _rname; } set { _rname = value; OnPropertyChanged("RName"); } }

        //Textbox Notes
        private string _notes;
        public string Notes { get { return _notes; } set { _notes = value; OnPropertyChanged(); } }

        //Selected value of combobox
        private string _type;
        public string Type { get { return _type; } set { _type = value; OnPropertyChanged("Type"); } }

        //Textbox Price/Day
        private string _price;
        public string Price { get { return _price; } set { _price = value; OnPropertyChanged(); } }

        //Textbox Max People
        private string _maxPeople;
        public string MaxPeople { get { return _maxPeople; } set { _maxPeople = value; OnPropertyChanged(); } }

        private bool _isEnabled;
        public bool IsEnabled { get { return _isEnabled; } set { _isEnabled = value; OnPropertyChanged(); } }

        public ICommand AddRoomCommand { get; set; }
        public ICommand RegulationsCommand { get; set; }

        public RoomsViewModel()
        {
            LoadRoomTypes();
            LoadTypes();

            AddRoomCommand = new RelayCommand<object>((o) =>
            {
                if (string.IsNullOrEmpty(RName) || string.IsNullOrEmpty(Type)
                    || string.IsNullOrEmpty(Price) || (string.IsNullOrEmpty(MaxPeople)))
                    return false;
                else
                    return true;
            }, (p) =>
            {
                RoomsModel model = new RoomsModel();
                int roomTypeID = -1;
                foreach (roomtype rt in roomTypes)
                {
                    if (rt.TenLoaiPhong == Type)
                    {
                        roomTypeID = rt.MaLoaiPhong;
                        break;
                    }
                }
                if (model.Insert_Room(RName, roomTypeID, Notes))
                {
                    //send message
                    EventSystem.Publish<Message>(new Message { message = "refresh" });
                    MessageBox.Show("Room has been added!");
                }
            });

            RegulationsCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                RegulationsView wd = new RegulationsView();
                wd.ShowDialog();
            });
        }

        void LoadRoomTypes()
        {
            roomTypes = new ObservableCollection<roomtype>();

            DataTable dataTable = new DataTable();
            RoomsModel model = new RoomsModel();
            dataTable = model.Load_RoomType();

            foreach (DataRow row in dataTable.Rows)
            {
                var obj = new roomtype()
                {
                    MaLoaiPhong = (int)row["MaLoaiPhong"],
                    TenLoaiPhong = (string)row["TenLoaiPhong"],
                    DonGia = (int)row["DonGia"],
                    SoNgToiDa = (int)row["SoNgToiDa"]
                };
                roomTypes.Add(obj);
            }
        }

        void LoadTypes()
        {
            Types = new List<string>();

            try
            {
                foreach (roomtype rt in roomTypes)
                {
                    string type = rt.TenLoaiPhong;
                    Types.Add(type);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            switch (propertyName)
            {
                case "RName":
                    {
                        checkEnabled();
                    }
                    break;
                case "Type":
                    {
                        try
                        {
                            foreach (roomtype rt in roomTypes)
                            {
                                if (Type == rt.TenLoaiPhong)
                                {
                                    Price = rt.DonGia.ToString();
                                    MaxPeople = rt.SoNgToiDa.ToString();
                                    if (string.IsNullOrEmpty(RName))
                                        IsEnabled = false;
                                    else
                                        IsEnabled = true;
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

        void checkEnabled()
        {
            if (string.IsNullOrEmpty(RName) || string.IsNullOrEmpty(Type)
                || string.IsNullOrEmpty(Price) || (string.IsNullOrEmpty(MaxPeople)))
                IsEnabled = false;
            else
                IsEnabled = true;
        }
    }
}

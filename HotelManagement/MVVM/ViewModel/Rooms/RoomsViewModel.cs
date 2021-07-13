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
using System.Windows.Controls;

namespace HotelManagement.MVVM.ViewModel
{
    /// <summary>
    /// Interaction logic for RoomsView.xaml
    /// </summary>
    class RoomsViewModel : ObservableObject
    {
        private ObservableCollection<roomtype> _roomTypes;
        public ObservableCollection<roomtype> RoomTypes { get { return _roomTypes; } set { _roomTypes = value; OnPropertyChanged(); } }

        //Combobox Room type:
        private int indexOfTypes { get; set; }
        private ObservableCollection<string> _types;
        public ObservableCollection<string> Types { get { return _types; } set { _types = value; OnPropertyChanged(); } }

        #region Search box element
        //Search
        private List<string> _itemsSearch;
        public List<string> ItemsSearch { get { return _itemsSearch; } set { _itemsSearch = value; OnPropertyChanged(); } }
        //Item search
        private string _itemSearchSelected;
        public string ItemSearchSelected { get { return _itemSearchSelected; } set { _itemSearchSelected = value; OnPropertyChanged(); } }
        //Search text
        private string _searchText;
        public string SearchText { get { return _searchText; } set { _searchText = value; OnPropertyChanged(); } }
        #endregion

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

        //Collapsed, Hidden, Visible
        private string _visibilityRegulations;
        public string VisibilityRegulations { get { return _visibilityRegulations; } set { _visibilityRegulations = value; OnPropertyChanged(); } }

        public ICommand AddRoomCommand { get; set; }
        public ICommand RegulationsCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RoomTypeSelectionChangedCommand { get; set; }

        public RoomsViewModel(int Position)
        {
            if (Position == 2)
            {
                VisibilityRegulations = "Collapsed";
            }    
            else
            {
                VisibilityRegulations = "Visible";
            }    
            RoomTypes = new ObservableCollection<roomtype>();
            Types = new ObservableCollection<string>();
            ItemsSearch = new List<string>();
            ItemsSearch.Add("Room Name");
            ItemsSearch.Add("Room ID");

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
                addRoom();
            });

            RegulationsCommand = new RelayCommand<ComboBox>((p) =>
            {
                //Phan quyen
                return true;
            }, (p) =>
            {
                showRegulationView(p);
            });

            SearchCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(ItemSearchSelected))
                    return false;
                return true;
            }, (p) =>
            {
                //Gửi message đến RoomListViewModel
                sendMessageToSearch();
            });

            RoomTypeSelectionChangedCommand = new RelayCommand<ComboBox>((p) =>
            {
                return true;
            }, (p) =>
            {
                try
                {
                    indexOfTypes = p.SelectedIndex;
                    if (indexOfTypes >= 0 && indexOfTypes < RoomTypes.Count)
                    {
                        Price = RoomTypes[indexOfTypes].DonGia.ToString();
                        MaxPeople = RoomTypes[indexOfTypes].SoNgToiDa.ToString();
                    }    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("RoomsViewModel RoomTypeSelectionChangedCommand\n" + ex.Message);
                }
            });

            EventSystem.Subscribe<Message>(getMessages);    //Nhận message từ RegulationsViewModel
        }

        public void getMessages(Message message)
        {
            if (message.message == "TypeAdded" || message.message.Contains("RemoveType|"))
            {
                LoadRoomTypes();
                LoadTypes();
            }
        }

        void sendMessageToSearch()
        {
            if (ItemSearchSelected == "Room ID")
            {
                //send message
                EventSystem.Publish<Message>(new Message { message = "ID|" + SearchText });
            }
            else
            {
                //send message
                EventSystem.Publish<Message>(new Message { message = "Name|" + SearchText });
            }
        }

        void addRoom()
        {
            RoomsModel model = new RoomsModel();

            if (indexOfTypes < 0 && indexOfTypes >= RoomTypes.Count)
                return;

            if (model.Insert_Room(RName, RoomTypes[indexOfTypes].MaLoaiPhong, Notes))
            {
                //send message
                EventSystem.Publish<Message>(new Message { message = "refresh" });
                MessageBox.Show("Room has been added!");
            }
        }

        void showRegulationView(ComboBox p)
        {
            Types.Clear();
            p.SelectedItem = null;
            Price = "";
            MaxPeople = "";
            RegulationsView wd = new RegulationsView();
            wd.ShowDialog();
        }

        void LoadRoomTypes()
        {
            if (RoomTypes.Count > 0)
                RoomTypes.Clear();
            RoomTypes = new ObservableCollection<roomtype>();

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
                RoomTypes.Add(obj);
            }
        }

        void LoadTypes()
        {
            try
            {
                if (Types.Count > 0)
                    Types.Clear();
                Types = new ObservableCollection<string>();
                foreach (roomtype rt in RoomTypes)
                {
                    string type = rt.TenLoaiPhong;
                    Types.Add(type);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("RoomsViewModel LoadTypes\n" + ex.Message);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {

        }
    }
}

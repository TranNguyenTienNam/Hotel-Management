using HotelManagement.Core;
using HotelManagement.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagement.MVVM.ViewModel
{
    class ListTypeViewModel : ObservableObject
    {
        public static ListTypeViewModel Instance => new ListTypeViewModel();
        private ObservableCollection<ListTypeItemViewModel> _items;
        public ObservableCollection<ListTypeItemViewModel> Items { get { return _items; } set { _items = value; OnPropertyChanged("Items"); } }

        public ICommand RefreshListRoom { get; set; }

        public ListTypeViewModel()
        {
            Items = new ObservableCollection<ListTypeItemViewModel>();
            loadListRoomType();

            RefreshListRoom = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                loadListRoomType();
            });

            EventSystem.Subscribe<Message>(getMessages);
        }

        public void getMessages(Message message)
        {
            try
            {
                if (message.message == "RefreshType")
                {
                    loadListRoomType();
                }    
                else if (message.message.Contains("RemoveType|"))
                {
                    string[] vs = message.message.Split('|');
                    Items.Remove(Items.Where(X => X.Id == Convert.ToInt32(vs[1])).Single());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void loadListRoomType()
        {
            if (Items.Count > 0)
                Items.Clear();
            RegulationsModel model = new RegulationsModel();
            DataTable data = new DataTable();
            data = model.Load_On();
            foreach (DataRow row in data.Rows)
            {
                var obj = new ListTypeItemViewModel()
                {
                    Id = (int)row["MaLoaiPhong"],
                    TypeName = (string)row["TenLoaiPhong"],
                    Price = (int)row["DonGia"],
                    MaxPeople = (int)row["SoNgToiDa"]
                };
                Items.Add(obj);
            }
        }
    }
}

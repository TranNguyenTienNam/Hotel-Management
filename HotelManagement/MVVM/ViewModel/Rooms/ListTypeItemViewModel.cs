using HotelManagement.Core;
using HotelManagement.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelManagement.MVVM.ViewModel
{
    class ListTypeItemViewModel : ObservableObject
    {
        public static ListTypeItemViewModel Instance => new ListTypeItemViewModel();

        private int _id;
        public int Id { get { return _id; } set { _id = value; OnPropertyChanged(); } }

        private string _typeName;
        public string TypeName { get { return _typeName; } set { _typeName = value; OnPropertyChanged(); } }

        private int _price;
        public int Price { get { return _price; } set { _price = value; OnPropertyChanged(); } }

        private int _maxPeople;
        public int MaxPeople { get { return _maxPeople; } set { _maxPeople = value; OnPropertyChanged(); } }

        public ICommand RemoveRoomCommand { get; set; }

        public ListTypeItemViewModel()
        {
            RegulationsModel model = new RegulationsModel();
            RemoveRoomCommand = new RelayCommand<object>((p) =>
            {
                if (model.CheckTypeIdExistInRoom(Id))
                    return false;
                else
                    return true;
            }, (p) =>
            {
                //check room còn trống hay không?

                
                if (model.RemoveType(Id))
                {
                    EventSystem.Publish<Message>(new Message { message = Id.ToString() });
                    MessageBox.Show("Room has been Removed");
                }

            });
        }
    }
}

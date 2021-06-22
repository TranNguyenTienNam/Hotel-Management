using HotelManagement.Core;
using HotelManagement.MVVM.Model;
using HotelManagement.Object;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HotelManagement.MVVM.ViewModel
{
    class RegulationsViewModel : ObservableObject
    {
        public static RegulationsViewModel Instance => new RegulationsViewModel();
        private string _id;
        public string Id { get { return _id; } set { _id = value; OnPropertyChanged(); } }

        private string _typeName;
        public string TypeName { get { return _typeName; } set { _typeName = value; OnPropertyChanged(); } }

        private decimal _price;
        public decimal Price { get { return _price; } set { _price = value; OnPropertyChanged(); } }

        private int _maxPeople;
        public int MaxPeople { get { return _maxPeople; } set { _maxPeople = value; OnPropertyChanged(); } }

        private bool _isChecked;
        public bool IsChecked { get { return _isChecked; } set { _isChecked = value; OnPropertyChanged("IsChecked"); } }

        public ICommand AddRoomTypeCommand { get; set; }
        public ICommand EditRoomTypeCommand { get; set; }
        public ICommand InputNumericCommand { get; set; }

        public RegulationsViewModel()
        {
            //Edit mode
            IsChecked = true;

            AddRoomTypeCommand = new RelayCommand<object>((p) =>
            {
                return !IsChecked;
            }, (p) =>
            {
                MessageBox.Show(TypeName + Price.ToString() + MaxPeople.ToString());
            });

            EditRoomTypeCommand = new RelayCommand<object>((p) =>
            {
                return IsChecked;
            }, (p) =>
            {
                //
            });

            InputNumericCommand = new RelayCommand<TextBox>((p) =>
            {
                return true;
            }, (p) => 
            { 

            });

            
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (IsChecked == false)
                Id = "Automatically Generated";
            else
                Id = "";
        }
    }
}

using HotelManagement.MVVM.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using HotelManagement.Core;

namespace HotelManagement.MVVM.ViewModel
{
    class DashboardViewModel : ObservableObject
    {
        public DashboardViewModel()
        {
            this.SelectedDate = DateTime.Today;
            this.SelectedMode = "Daily";
            this.SelectedPerformance = "Revenue";

            this.CartesianChartModel = new CartesianChartModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode, this.selectedPerformance);
            this.PieChartModel = new PieChartModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode);
        }
        // Cartesian Chart
        private CartesianChartModel cartesianChartModel;
        public CartesianChartModel CartesianChartModel { get { return cartesianChartModel; } set { cartesianChartModel = value; OnPropertyChanged(); } }

        // Cartesian Chart
        private PieChartModel pieChartModel;
        public PieChartModel PieChartModel { get { return pieChartModel; } set { pieChartModel = value; OnPropertyChanged(); } }

        // DatePicker
        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                Console.WriteLine("Datepicker {0}", ConvertTimeFormat(SelectedDate));
                OnPropertyChanged("date");
            }
        }

        private string ConvertTimeFormat(DateTime dateTime)
        {
            return dateTime.Month.ToString() + '-' + dateTime.Day.ToString() + '-' + dateTime.Year.ToString();
        }

        // RadioButton Mode
        private string selectedMode;
        public string SelectedMode
        {
            get { return selectedMode; }
            set
            {
                selectedMode = value;
                OnPropertyChanged("mode");
            }
        }
        public DelegateCommand ModeRadCommand
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    SelectedMode = (string)p;
                });
            }
        }

        // RadioButton Performance
        private string selectedPerformance;
        public string SelectedPerformance
        {
            get { return selectedPerformance; }
            set
            {
                selectedPerformance = value;
                OnPropertyChanged("performance");
            }
        }
        
        public DelegateCommand PerformanceRadCommand
        {
            get
            {
                return new DelegateCommand((p) =>
                {
                    SelectedPerformance = (string)p;
                });
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            this.CartesianChartModel = new CartesianChartModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode, this.selectedPerformance);
            this.PieChartModel = new PieChartModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode);
        }
    }
}

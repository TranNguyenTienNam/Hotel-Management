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

            this.RevenueCardModel = new RevenueCardModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode);
            this.AORCardModel = new AORCardModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode);
            this.BookingsCardModel = new BookingsCardModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode);
            this.GuestsCardModel = new GuestsCardModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode);
            this.TodayCardModel = new TodayCardModel();

            this.CartesianChartModel = new CartesianChartModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode, this.selectedPerformance);
            this.PieChartModel = new PieChartModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode, this.SelectedPerformance);
        }
        // Cartesian Chart
        private CartesianChartModel cartesianChartModel;
        public CartesianChartModel CartesianChartModel { get { return cartesianChartModel; } set { cartesianChartModel = value; OnPropertyChanged(); } }

        // Cartesian Chart
        private PieChartModel pieChartModel;
        public PieChartModel PieChartModel { get { return pieChartModel; } set { pieChartModel = value; OnPropertyChanged(); } }

        // Revenue Card
        private RevenueCardModel revenueCardModel;
        public RevenueCardModel RevenueCardModel { get { return revenueCardModel; } set { revenueCardModel = value; OnPropertyChanged(); } }

        // AOR Card
        private AORCardModel aorCardModel;
        public AORCardModel AORCardModel { get { return aorCardModel; } set { aorCardModel = value; OnPropertyChanged(); } }

        // Bookings Card
        private BookingsCardModel bookingsCardModel;
        public BookingsCardModel BookingsCardModel { get { return bookingsCardModel; } set { bookingsCardModel = value; OnPropertyChanged(); } }

        // Guests Card
        private GuestsCardModel guestsCardModel;
        public GuestsCardModel GuestsCardModel { get { return guestsCardModel; } set { guestsCardModel = value; OnPropertyChanged(); } }

        // Today Card
        private TodayCardModel todayCardModel;
        public TodayCardModel TodayCardModel { get { return todayCardModel; } set { todayCardModel = value; OnPropertyChanged(); } }

        // DatePicker
        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
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
            this.RevenueCardModel = new RevenueCardModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode);
            this.AORCardModel = new AORCardModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode);
            this.BookingsCardModel = new BookingsCardModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode);
            this.GuestsCardModel = new GuestsCardModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode);
            this.TodayCardModel = new TodayCardModel();

            this.CartesianChartModel = new CartesianChartModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode, this.selectedPerformance);
            this.PieChartModel = new PieChartModel(ConvertTimeFormat(this.SelectedDate), this.SelectedMode, this.SelectedPerformance);
        }
    }
}

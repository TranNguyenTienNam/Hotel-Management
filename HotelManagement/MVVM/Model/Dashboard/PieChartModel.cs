using HotelManagement.Core;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class PieChartModel : ObservableObject
    {
        public SeriesCollection PieSeriesCollection { get; set; }

        public PieChartModel(string selectedDate, string selectedMode, string selectedPerformance)
        {
            ReloadChart(selectedDate, selectedMode, selectedPerformance);
        }
        public void ReloadChart(string selectedDate, string selectedMode, string selectedPerformance)
        {
            // Initialize chart
            this.PieSeriesCollection = new SeriesCollection();
            DataTable dataTable = new DataTable();
            switch (selectedPerformance)
            {
                case "Revenue":
                    RevenueModel revenueModel = new RevenueModel();
                    switch (selectedMode)
                    {
                        case "Daily":
                            dataTable = revenueModel.DailyRevByRoomType(selectedDate);
                            LoadData(dataTable, selectedPerformance);
                            break;
                        case "Monthly":
                            dataTable = revenueModel.MonthlyRevByRoomType(selectedDate);
                            LoadData(dataTable, selectedPerformance);
                            break;
                        case "Annual":
                            dataTable = revenueModel.AnnualRevByRoomType();
                            LoadData(dataTable, selectedPerformance);
                            break;
                        default:
                            break;
                    }
                    break;
                case "Bookings":
                    BookingsModel bookingsModel = new BookingsModel();
                    switch (selectedMode)
                    {
                        case "Daily":
                            dataTable = bookingsModel.DailyBookingsByRoomType(selectedDate);
                            LoadData(dataTable, selectedPerformance);
                            break;
                        case "Monthly":
                            dataTable = bookingsModel.MonthlyBookingsByRoomType(selectedDate);
                            LoadData(dataTable, selectedPerformance);
                            break;
                        case "Annual":
                            dataTable = bookingsModel.AnnualBookingsByRoomType();
                            LoadData(dataTable, selectedPerformance);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        private void LoadData(DataTable dataTable, string selectedPerformance)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                double.TryParse(row[selectedPerformance].ToString(), out double value);
                var values = new ChartValues<ObservableValue>();
                values.Add(new ObservableValue(value));

                string title = row["RoomType"].ToString();

                this.PieSeriesCollection.Add(new PieSeries
                {
                    Title = title,
                    Values = values,
                });
            }
        }
    }
}

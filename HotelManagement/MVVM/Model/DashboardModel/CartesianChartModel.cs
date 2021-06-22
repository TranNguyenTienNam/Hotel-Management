using HotelManagement.Core;
using System.Collections.Generic;
using HotelManagement.MVVM.Model;
using System.Data;
using System.ComponentModel;
using LiveCharts.Configurations;
using LiveCharts;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System;

namespace HotelManagement.MVVM.Model
{
    class CartesianChartModel : ObservableObject
    {
        public CartesianMapper<ChartDataModel> LineSeriesConfiguration { get; set; }
        public ChartValues<ChartDataModel> LineSeries { get; set; }
        public ObservableCollection<string> LineSeriesLabels { get; set; }

        public CartesianChartModel(string selectedDate, string selectedMode, string selectedPerformance)
        {
            ReloadChart(selectedDate, selectedMode, selectedPerformance);
        }

        public void ReloadChart(string selectedDate, string selectedMode, string selectedPerformance)
        {
            // Initialize chart
            this.LineSeries = new ChartValues<ChartDataModel>();
            this.LineSeriesLabels = new ObservableCollection<string>();
            DataTable dataTable = new DataTable();
            switch (selectedPerformance)
            {
                case "Revenue":
                    RevenueModel revenueModel = new RevenueModel();
                    switch (selectedMode)
                    {
                        case "Daily":
                            dataTable = revenueModel.DailyRevenue(selectedDate);
                            LoadData(dataTable, selectedMode, selectedPerformance);
                            break;
                        case "Monthly":
                            dataTable = revenueModel.MonthlyRevenue(selectedDate);
                            LoadData(dataTable, selectedMode, selectedPerformance);
                            break;
                        case "Annual":
                            dataTable = revenueModel.AnnualRevenue();
                            LoadData(dataTable, selectedMode, selectedPerformance);
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
                            dataTable = bookingsModel.DailyBookings(selectedDate);
                            LoadData(dataTable, selectedMode, selectedPerformance);
                            break;
                        case "Monthly":
                            dataTable = bookingsModel.MonthlyBookings(selectedDate);
                            LoadData(dataTable, selectedMode, selectedPerformance);
                            break;
                        case "Annual":
                            dataTable = bookingsModel.AnnualBookings();
                            LoadData(dataTable, selectedMode, selectedPerformance);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }


            // DatModel to value mapping
            this.LineSeriesConfiguration = new CartesianMapper<ChartDataModel>()
              .Y(dataModel => dataModel.Value);
        }
        private void LoadData(DataTable dataTable, string selectedMode, string selectedPerformance)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                if (double.TryParse(row[selectedPerformance].ToString(), out double value))
                {
                    string label;
                    ChartDataModel newDataModel;
                    switch (selectedMode)
                    {
                        case "Daily":
                            label = row["Date"].ToString();
                            newDataModel = new ChartDataModel(value, label);
                            this.LineSeries.Add(newDataModel);
                            this.LineSeriesLabels.Add(newDataModel.Label);
                            break;
                        case "Monthly":
                            label = row["Month"].ToString();
                            newDataModel = new ChartDataModel(value, label);
                            this.LineSeries.Add(newDataModel);
                            this.LineSeriesLabels.Add(newDataModel.Label);
                            break;
                        case "Annual":
                            label = row["Year"].ToString();
                            newDataModel = new ChartDataModel(value, label);
                            this.LineSeries.Add(newDataModel);
                            this.LineSeriesLabels.Add(newDataModel.Label);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace HotelManagement.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();

            // Pie Chart
            PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            DataContext = this;

            // Line Chart
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Revenue",
                    Values = new ChartValues<double> { 4, 6, 5, 2, 4, 6, 5, 2, 4, 6, 5, 2 },
                    LineSmoothness = 0,
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,
                },
                new LineSeries
                {
                    Title = "Guests",
                    Values = new ChartValues<double> { 6, 7, 3, 4, 6, 7, 3, 4, 6, 7, 3, 4 },
                    LineSmoothness = 0,
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 10,
                },
                new LineSeries
                {
                    Title = "Bookings",
                    Values = new ChartValues<double> { 4, 2, 7, 2, 4, 2, 7, 2, 4, 2, 7, 2, },
                    LineSmoothness = 0,
                    PointGeometry = DefaultGeometries.Cross,
                    PointGeometrySize = 10,
                }
            };

            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "June", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
            YFormatter = value => value.ToString("C");

            SeriesCollection.Add(new LineSeries
            {
                Title = "Series 4",
                Values = new ChartValues<double> { 5, 3, 2, 4, 5, 3, 2, 4, 5, 3, 2, 4 },
                LineSmoothness = 0,
                PointGeometry = DefaultGeometries.Diamond,
                PointGeometrySize = 10,
            });

            DataContext = this;
        }
        // Pie Chart
        public Func<ChartPoint, string> PointLabel { get; set; }
        private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }
        // Line Chart
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }
    }
}

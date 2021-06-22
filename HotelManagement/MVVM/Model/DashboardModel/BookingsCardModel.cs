using HotelManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class BookingsCardModel : ObservableObject
    {
        public int SelectedBookings { get; set; }
        public int PreviousBookings { get; set; }
        public string BookingsRate { get; set; }
        public string Icon { get; set; }
        public BookingsCardModel(string selectedDate, string selectedMode)
        {
            ReloadCard(selectedDate, selectedMode);
        }
        public void ReloadCard(string selectedDate, string selectedMode)
        {
            BookingsModel bookingsModel = new BookingsModel();
            switch (selectedMode)
            {
                case "Daily":
                    this.SelectedBookings = bookingsModel.SelectedDateBookings(selectedDate);
                    this.PreviousBookings = bookingsModel.PreviousDateBookings(selectedDate);
                    CalcRate(this.SelectedBookings, this.PreviousBookings);
                    break;
                case "Monthly":
                    this.SelectedBookings = bookingsModel.SelectedMonthBookings(selectedDate);
                    this.PreviousBookings = bookingsModel.PreviousMonthBookings(selectedDate);
                    CalcRate(this.SelectedBookings, this.PreviousBookings);
                    break;
                case "Annual":
                    this.SelectedBookings = bookingsModel.SelectedYearBookings(selectedDate);
                    this.PreviousBookings = bookingsModel.PreviousYearBookings(selectedDate);
                    CalcRate(this.SelectedBookings, this.PreviousBookings);
                    break;
                default:
                    break;
            }
        }
        private void CalcRate(int sel, int pre)
        {
            if (sel == 0 || pre == 0) return;
            this.BookingsRate = Math.Round((((float)Math.Max(sel, pre) / (float)Math.Min(sel, pre) - 1) * 100), 2).ToString() + "%";
            if (sel >= pre)
            {
                this.Icon = "/HotelManagement;component/Images/caret-arrow-up.png";
            }
            else
            {
                this.Icon = "/HotelManagement;component/Images/caret-arrow-down.png";
            }
        }
    }
}

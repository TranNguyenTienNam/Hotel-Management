using HotelManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class GuestsCardModel : ObservableObject
    {
        public int SelectedGuests { get; set; }
        public int PreviousGuests { get; set; }
        public string GuestsRate { get; set; }
        public string Icon { get; set; }
        public GuestsCardModel(string selectedDate, string selectedMode)
        {
            ReloadCard(selectedDate, selectedMode);
        }
        public void ReloadCard(string selectedDate, string selectedMode)
        {
            GuestsModel guestsModel = new GuestsModel();
            switch (selectedMode)
            {
                case "Daily":
                    this.SelectedGuests = guestsModel.SelectedDateGuests(selectedDate);
                    this.PreviousGuests = guestsModel.PreviousDateGuests(selectedDate);
                    CalcRate(this.SelectedGuests, this.PreviousGuests);
                    break;
                case "Monthly":
                    this.SelectedGuests = guestsModel.SelectedMonthGuests(selectedDate);
                    this.PreviousGuests = guestsModel.PreviousMonthGuests(selectedDate);
                    CalcRate(this.SelectedGuests, this.PreviousGuests);
                    break;
                case "Annual":
                    this.SelectedGuests = guestsModel.SelectedYearGuests(selectedDate);
                    this.PreviousGuests = guestsModel.PreiousYearGuests(selectedDate);
                    CalcRate(this.SelectedGuests, this.PreviousGuests);
                    break;
                default:
                    break;
            }
        }
        private void CalcRate(int sel, int pre)
        {
            if (sel == 0 || pre == 0) return;
            this.GuestsRate = Math.Round((((float)Math.Max(sel, pre) / (float)Math.Min(sel, pre) - 1) * 100), 2).ToString() + "%";
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

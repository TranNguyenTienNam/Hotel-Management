using HotelManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class AORCardModel : ObservableObject
    {
        public string SelectedAOR { get; set; }
        public string PreviousAOR{ get; set; }
        public string AORRate { get; set; }
        public string Icon { get; set; }

        private float SelAOR;
        private float PreAOR;
        public AORCardModel(string selectedDate, string selectedMode)
        {
            ReloadCard(selectedDate, selectedMode);
        }
        public void ReloadCard(string selectedDate, string selectedMode)
        {
            AORModel aorModel = new AORModel();
            switch (selectedMode)
            {
                case "Daily":
                    this.SelAOR = (float)aorModel.SelectedDateAOR(selectedDate) / (float)aorModel.NumRooms() * 100;
                    this.PreAOR = (float)aorModel.PreviousDateAOR(selectedDate) / (float)aorModel.NumRooms() * 100;
                    this.SelectedAOR = Math.Round(this.SelAOR, 2).ToString() + "%";
                    this.PreviousAOR = Math.Round(this.PreAOR, 2).ToString() + "%";
                    CalcRate(this.SelAOR, this.PreAOR);
                    break;
                case "Monthly":
                    this.SelAOR = (float)aorModel.SelectedMonthAOR(selectedDate) / (float)aorModel.NumRooms() * 100;
                    this.PreAOR = (float)aorModel.PreviousMonthAOR(selectedDate) / (float)aorModel.NumRooms() * 100;
                    this.SelectedAOR = Math.Round(this.SelAOR, 2).ToString() + "%";
                    this.PreviousAOR = Math.Round(this.PreAOR, 2).ToString() + "%";
                    CalcRate(this.SelAOR, this.PreAOR);
                    break;
                case "Annual":
                    this.SelAOR = (float)aorModel.SelectedYearAOR(selectedDate) / (float)aorModel.NumRooms() * 100;
                    this.PreAOR = (float)aorModel.PreiousYearAOR(selectedDate) / (float)aorModel.NumRooms() * 100;
                    this.SelectedAOR = Math.Round(this.SelAOR, 2).ToString() + "%";
                    this.PreviousAOR = Math.Round(this.PreAOR, 2).ToString() + "%";
                    CalcRate(this.SelAOR, this.PreAOR);
                    break;
                default:
                    break;
            }
        }
        private void CalcRate(float sel, float pre)
        {
            if (sel == 0 || pre == 0) return;
            this.AORRate = Math.Round(((Math.Max(sel, pre) / Math.Min(sel, pre) - 1) * 100), 2).ToString() + "%";
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

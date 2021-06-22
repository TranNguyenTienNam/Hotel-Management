using HotelManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class RevenueCardModel : ObservableObject
    {
        public string SelectedRevenue { get; set; }
        public string PreviousRevenue { get; set; }
        public string RevenueRate { get; set; }
        public string Icon { get; set; }

        private float SelRev;
        private float PreRev;
        public RevenueCardModel(string selectedDate, string selectedMode)
        {
            ReloadCard(selectedDate, selectedMode);
        }
        public void ReloadCard(string selectedDate, string selectedMode)
        {
            RevenueModel revenueModel = new RevenueModel();
            switch (selectedMode)
            {
                case "Daily":
                    this.SelRev = revenueModel.SelectedDateRevenue(selectedDate) / 1000000;
                    this.PreRev = revenueModel.PreviousDateRevenue(selectedDate) / 1000000;
                    this.SelectedRevenue = Math.Round(this.SelRev, 2).ToString() + "M";
                    this.PreviousRevenue = Math.Round(this.PreRev, 2).ToString() + "M";
                    CalcRate(this.SelRev, this.PreRev);
                    break;
                case "Monthly":
                    this.SelRev = revenueModel.SelectedMonthRevenue(selectedDate) / 1000000;
                    this.PreRev = revenueModel.PreviousMonthRevenue(selectedDate) / 1000000;
                    this.SelectedRevenue = Math.Round(this.SelRev, 2).ToString() + "M";
                    this.PreviousRevenue = Math.Round(this.PreRev, 2).ToString() + "M";
                    CalcRate(this.SelRev, this.PreRev);
                    break;
                case "Annual":
                    this.SelRev = revenueModel.SelectedYearRevenue(selectedDate) / 1000000;
                    this.PreRev = revenueModel.PreviousYearRevenue(selectedDate) / 1000000;
                    this.SelectedRevenue = Math.Round(this.SelRev, 2).ToString() + "M";
                    this.PreviousRevenue = Math.Round(this.PreRev, 2).ToString() + "M";
                    CalcRate(this.SelRev, this.PreRev);
                    break;
                default:
                    break;
            }
        }
        private void CalcRate(float sel, float pre)
        {
            if (sel == 0 || pre == 0) return;
            this.RevenueRate = Math.Round(((Math.Max(sel, pre) / Math.Min(sel, pre) - 1) * 100), 2).ToString() + "%";
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

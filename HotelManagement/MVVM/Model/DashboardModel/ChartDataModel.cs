using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class ChartDataModel
    {
        public ChartDataModel(double value, string label)
        {
            this.Value = value;
            this.Label = label;
        }

        public double Value { get; set; }
        public string Label { get; set; }
    }
}

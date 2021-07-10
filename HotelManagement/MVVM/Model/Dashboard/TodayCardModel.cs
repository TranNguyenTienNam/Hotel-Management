using HotelManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.MVVM.Model
{
    class TodayCardModel : ObservableObject
    {
        public int NumMaxCheckin { get; set; }
        public int NumMaxCheckOut { get; set; }
        public int NumCheckin { get; set; }
        public int NumCheckOut { get; set; }
        public TodayCardModel()
        {
            TodayModel todayModel = new TodayModel();
            this.NumMaxCheckin = todayModel.NumMaxCheckin();
            this.NumMaxCheckOut = todayModel.NumMaxCheckOut();
            this.NumCheckin = todayModel.NumCheckin();
            this.NumCheckOut = todayModel.NumCheckOut();
        }
    }
}

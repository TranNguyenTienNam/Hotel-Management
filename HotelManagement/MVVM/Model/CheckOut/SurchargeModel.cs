using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace HotelManagement.MVVM.Model.CheckOut
{
    class SurchargeModel
    {
        public static string con_string = ConfigurationManager.ConnectionStrings["con"].ToString();
        public DataTable Load_surcharge()
        {
            DataTable re;
            string query = "select * from PHUTHU";
            re = Process.createTable(query);
            return re;
        }

        public int Get_surcharge_more_client()
        {
            int re = 1;
            SqlConnection con = new SqlConnection(con_string);
            con.Open();
            String query = "select * from PHUTHU";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                re = (int)dr["KhachThu3"];
            }
            con.Close();
            return re;
        }

    }          
}

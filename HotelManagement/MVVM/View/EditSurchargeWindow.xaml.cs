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
using System.Windows.Shapes;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagement.MVVM.View
{
    /// <summary>
    /// Interaction logic for EditSurchargeWindow.xaml
    /// </summary>
    public partial class EditSurchargeWindow : Window
    {
        public EditSurchargeWindow()
        {
            InitializeComponent();
        }
        public void load()
        {
            try
            {
                String connect_string = ConfigurationManager.ConnectionStrings["con"].ToString();
                SqlConnection con = new SqlConnection(connect_string);
                con.Open();

                String query = "select * from PHUTHU";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.tb_thirdclient_surchangre.Text = (dr["KhachThu3"].ToString());
                    this.tb_foreigner_surchangre.Text = (dr["KhachNuocNgoai"].ToString());
                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            load();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            float a = float.Parse(this.tb_thirdclient_surchangre.Text);
            float b = float.Parse(this.tb_foreigner_surchangre.Text);
            if (a <= 0 || b <= 0) MessageBox.Show("Surcharge must be greater than 0 !");
            else
            {
                try
                {
                    String connect_string = ConfigurationManager.ConnectionStrings["con"].ToString();
                    SqlConnection con = new SqlConnection(connect_string);
                    String query = "update PHUTHU set KhachThu3= " + this.tb_thirdclient_surchangre.Text + ",KhachNuocNgoai=" + this.tb_foreigner_surchangre.Text + ";";

                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Updated!");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }
    }
}

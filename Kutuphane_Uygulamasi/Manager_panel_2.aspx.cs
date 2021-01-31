using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace Kutuphane_Uygulamasi
{
    public partial class Manager_panel_2 : System.Web.UI.Page
    {

        MySqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string conectionString = "Server=localhost;Database=library_app;Uid=root;Pwd=1234Bz.;";
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Selection_Change(object sender, EventArgs e)
        {
                                           
            Calendar1.TodaysDate = Calendar1.SelectedDate;
            Label1.Text = "Today's Date is now " + Calendar1.TodaysDate.ToShortDateString();
            
            MySqlConnection sqlcon = new MySqlConnection(conectionString);
            MySqlCommand cmd;
            
            String start = "SELECT COUNT(*)FROM user_book_time";
            sqlcon.Open();
            cmd = new MySqlCommand(start, sqlcon);
            cmd.ExecuteNonQuery();

            String row = cmd.ExecuteScalar().ToString();

            if (row.Equals("0") == false)
            {
                String change_date = "update user_book_time set today_date = '" + Calendar1.TodaysDate.ToString("yyyy-MM-dd hh:mm:ss") + "'";
                cmd = new MySqlCommand(change_date, sqlcon);
                cmd.ExecuteNonQuery();
                                
            }

            String change_date_2 = "update time_table set today = '" + Calendar1.TodaysDate.ToString("yyyy-MM-dd hh:mm:ss") + "'";
            cmd = new MySqlCommand(change_date_2, sqlcon);
            cmd.ExecuteNonQuery();

            sqlcon.Close();
        }

        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transfer_manager_panel.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_page.aspx");
        }
    }
}
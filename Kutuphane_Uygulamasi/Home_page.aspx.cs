using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Text;

namespace Kutuphane_Uygulamasi
{
    public partial class Home_page : System.Web.UI.Page
    {
        string conectionString = "Server=localhost;Database=library_app;Uid=root;Pwd=1234Bz.;";
       
        protected void Page_Load(object sender, EventArgs e)
        {
            MySqlConnection sqlcon = new MySqlConnection(conectionString);
            MySqlCommand cmd;
            String start = "SELECT COUNT(*)FROM time_table";
            sqlcon.Open();
            cmd = new MySqlCommand(start, sqlcon);
            cmd.ExecuteNonQuery();

            String row = cmd.ExecuteScalar().ToString();

            if (row.Equals("0"))
            {
                String change_date_3 = "insert time_table (today) values('" + DateTime.Today.ToString("yyyy-MM-dd hh:mm:ss") + "');";                
                cmd = new MySqlCommand(change_date_3, sqlcon);
                cmd.ExecuteNonQuery();
            }

            sqlcon.Close();
        }

        protected void maneger_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("manager_sign_in.aspx");
            
        }

        protected void user_login_Click(object sender, EventArgs e)
        {
            Response.Redirect("user_sign_in.aspx");
            
        }

    }
}
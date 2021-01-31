using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace Kutuphane_Uygulamasi
{
    public partial class manager_sign_in : System.Web.UI.Page
    {

        string conectionString = "Server=localhost;Database=library_app;Uid=root;Pwd=1234Bz.;";
        String quary_login;
        MySqlCommand com;
        object obj;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            //sign in kodu internetten alınmıştır
            MySqlConnection sqlcon = new MySqlConnection(conectionString);
            sqlcon.Open();
            quary_login = "select count(*) from manager_table where manager_name=@UserName and manager_password =@Password";
            com = new MySqlCommand(quary_login, sqlcon);
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("@UserName", TextBox_user_name.Text);
            com.Parameters.AddWithValue("@Password", TextBox_password.Text);
            obj = com.ExecuteScalar();

            if (Convert.ToInt32(obj) != 0)
            {
                Response.Redirect("Transfer_manager_panel.aspx");
            }
            else
            {
                lb1.Text = "invalid user name and password";
            }
            sqlcon.Close();
        }
    }
}
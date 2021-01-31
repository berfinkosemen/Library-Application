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
    public partial class user_sign_in : System.Web.UI.Page
    {

        string connectionString = "Server=localhost;Database=library_app;Uid=root;Pwd=1234Bz.;";
        String quary_login;
        object obj;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            //sign in kodu internetten alıntıdır 
            MySqlConnection sqlcon = new MySqlConnection(connectionString);
            //sqlcon.Open();
            quary_login = "select count(*) from user_table where user_name=@UserName and user_password =@Password";
            MySqlCommand com = new MySqlCommand(quary_login, sqlcon);
            com.Parameters.AddWithValue("@username", TextBox_user_name.Text);
            com.Parameters.AddWithValue("@password", TextBox_password.Text);
            MySqlDataAdapter sda = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            sqlcon.Open();
            int i = com.ExecuteNonQuery();
            sqlcon.Close();
            if (dt.Rows.Count > 0)
            {
                Session["id"] = TextBox_user_name.Text;
                Session["id2"] = TextBox_password.Text;
                Response.Redirect("Transfer_user_panel.aspx");
                Session.RemoveAll();

            }
            else
            {
                lb1.Text = "You're username and word is incorrect";
                lb1.ForeColor = System.Drawing.Color.Red;

            }
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}

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
    public partial class Register : System.Web.UI.Page
    {
        string conectionString = "Server=localhost;Database=library_app;Uid=root;Pwd=1234Bz.;";
        String quary_insert, quary_login;
        object obj;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_register_Click(object sender, EventArgs e)
        {          
            //register kodu internetten alıntıdır.
             MySqlConnection sqlcon = new MySqlConnection(conectionString);
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
                lb1.Text = "valid user name and password. Try new one";
                lb1.ForeColor = System.Drawing.Color.Red;

            }
            else
            {

                quary_insert = "insert into user_table(user_name,user_password) values ('" + TextBox_user_name.Text + "','" + TextBox_password.Text + "')";
                com = new MySqlCommand(quary_insert, sqlcon);
                obj = com.ExecuteScalar();

                Session["id"] = TextBox_user_name.Text;
                Session["id2"] = TextBox_password.Text;
                Response.Redirect("Transfer_user_panel.aspx");
                Session.RemoveAll();

            }           
        }
    }
}
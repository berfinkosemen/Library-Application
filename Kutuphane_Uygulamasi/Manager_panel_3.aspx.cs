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
    public partial class Manager_panel_3 : System.Web.UI.Page
    {
        MySqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string conectionString = "Server=localhost;Database=library_app;Uid=root;Pwd=1234Bz.;";
        String quary = "select u.user_name, b.book_name, b.receive_date, b.return_date, b.today_date, i.ısbn FROM user_table u, user_book_time b, book_table i where b.user_id = u.user_id and i.book_name = b.book_name";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void list_Click(object sender, EventArgs e)
        {

            //Tablo Görüntüleme kodu internetten alınmıştır
            MySqlConnection sqlcon = new MySqlConnection(conectionString);
            String start = "SELECT COUNT(*)FROM book_table";
            sqlcon.Open();
            MySqlCommand cmd = new MySqlCommand(start, sqlcon);
            cmd.ExecuteNonQuery();

            String row = cmd.ExecuteScalar().ToString();

            if (row.Equals("0") == false)
            {
                cmd = new MySqlCommand(quary, sqlcon);
                da = new MySqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.ExecuteNonQuery();

                htmlTable.Append("<table border='1'>");
                htmlTable.Append("<tr style='background-color:darkgray;'><th>Kullanıcı Adı</th><th>Kitap Adı</th><th>ISBN Numarası</th><th>Alınan Gün</th><th>Teslim Günü</th><th>Bugün</th>");

                if (!object.Equals(ds.Tables[0], null))
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            htmlTable.Append("<tr style='color: Black;'>");
                            htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["user_name"] + "</td>");
                            htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["book_name"] + "</td>");
                            htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["ısbn"] + "</td>");
                            htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["receive_date"] + "</td>");
                            htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["return_date"] + "</td>");
                            htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["today_date"] + "</td>");
                            htmlTable.Append("</tr>");
                        }
                        htmlTable.Append("</table>");
                        DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                    }
                    else
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td align='center' colspan='4'>There is no Record.</td>");
                        htmlTable.Append("</tr>");
                    }
                }
                
            }
            sqlcon.Close();
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_page.aspx");
        }

        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transfer_manager_panel.aspx");
        }
    }
}
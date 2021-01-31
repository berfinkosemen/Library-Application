using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using IronOcr;
using System.Text.RegularExpressions;

namespace Kutuphane_Uygulamasi
{
    public partial class User_panel : System.Web.UI.Page
    {
        MySqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string conectionString = "Server=localhost;Database=library_app;Uid=root;Pwd=1234Bz.;";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label1.Text = ListBox1.SelectedItem.Text.ToString();
        }

        protected void btn_list_Click(object sender, EventArgs e)
        {
            String quary = "SELECT * FROM book_table";

            if (Label1.Text.Equals("Kitap İsmi"))
            {
                quary = "select * from book_table where book_name = '" + TextBox1.Text + "';";
            }
            else if (Label1.Text.Equals("ISBN"))
            {
                quary = "select * from book_table where ısbn = '" + TextBox1.Text + "';";
            }
            MySqlConnection sqlcon = new MySqlConnection(conectionString);
            MySqlCommand cmd = new MySqlCommand(quary, sqlcon);
            da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();

            //tablo görüntüleme kodu internetten alınmıştır
            htmlTable.Append("<table border='1'>");
            htmlTable.Append("<tr style='background-color:darkgray;'><th>Kitap Adı</th><th>ISBN Numarası</th><th>Kitap Sayısı</th>");

            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        htmlTable.Append("<tr style='color: Black;'>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["book_name"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["ısbn"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["number"] + "</td>");
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

        protected void btn_rent_Click(object sender, EventArgs e)
        {

            /////id bul
            MySqlConnection sqlcon = new MySqlConnection(conectionString);
            String user_name = Session["id"].ToString();
            String user_password = Session["id2"].ToString();
            String quary2 = "select user_id from user_table where user_name = '" + user_name + "' and user_password = '" + user_password + "';";
            MySqlCommand cmd = new MySqlCommand(quary2, sqlcon);
            sqlcon.Open();
            cmd.ExecuteNonQuery(); 
            
            String str_id;
            str_id = cmd.ExecuteScalar().ToString();
            int id = int.Parse(str_id);
            //warn.Text = str_id;


            ////////kişinin üstündeki kitap sayisi
             String query3_1 = "select user_id from user_book_count";
             cmd = new MySqlCommand(query3_1, sqlcon);
             cmd.ExecuteNonQuery();
             MySqlDataReader result_1 = cmd.ExecuteReader();
             int counter_3 = 0;
             while (result_1.Read())
            {
                if (result_1.GetInt32(0) == id)
                {
                    counter_3++;
                }
            }

            result_1.Close();
            int int_books = 0;

            if (counter_3 == 0)
            {
                int_books = 0;
            }
            else if (counter_3 != 0)
            {
                String quary3 = "select number_of_book from user_book_count where user_id = '" + str_id + "';";
                cmd = new MySqlCommand(quary3, sqlcon);
                cmd.ExecuteNonQuery();

                String number_of_books;
                number_of_books = cmd.ExecuteScalar().ToString();
                int_books = int.Parse(number_of_books);
            }

            ///////zamanların Tanımlanması
            DateTime today = DateTime.Today;
            String str_today = today.ToString("yyyy-MM-dd hh:mm:ss");
            DateTime return_date = today.AddDays(7);
            String str_return_date = return_date.ToString("yyyy-MM-dd hh:mm:ss");

            if (Label1.Text.Equals("Kitap İsmi"))
            {
                ////kalan kitap sayisi
                String quary4 = "select number from book_table where book_name = '" + TextBox2.Text + "';";
                cmd = new MySqlCommand(quary4, sqlcon);
                cmd.ExecuteNonQuery();

                String number_of_left_books;
                number_of_left_books = cmd.ExecuteScalar().ToString();
                int int_number_of_left_books = int.Parse(number_of_left_books);


                /////time control

                String start = "SELECT COUNT(*)FROM user_book_time";
                cmd = new MySqlCommand(start, sqlcon);
                cmd.ExecuteNonQuery();

                String row = cmd.ExecuteScalar().ToString();
                int counter = 0;

                if (row.Equals("0"))
                {
                    counter = 0;
                    String quary_time_table = "select today from time_table";
                    cmd = new MySqlCommand(quary_time_table, sqlcon);
                    cmd.ExecuteNonQuery();

                    //String date_today = cmd.ExecuteScalar().ToString();

                    MySqlDataReader result___1 = cmd.ExecuteReader();

                    while (result___1.Read())
                    {
                        today = result___1.GetDateTime(0);
                    }

                    str_today = today.ToString("yyyy-MM-dd hh:mm:ss");

                    result___1.Close();

                }
                else
                {
                    String quary_control_2 = "select user_id from user_book_time";
                    cmd = new MySqlCommand(quary_control_2, sqlcon);
                    cmd.ExecuteNonQuery();

                    MySqlDataReader result_2 = cmd.ExecuteReader();
                    int counter_4 = 0;
                    while (result_2.Read())
                    {
                        if (result_2.GetInt32(0) == id)
                        {
                            counter_4++;
                        }
                    }

                    result_2.Close();

                    
                    if (counter_4 == 0)
                    {
                        counter = 0;

                        String quary7_2 = "select today_date from user_book_time ;";
                        cmd = new MySqlCommand(quary7_2, sqlcon);
                        cmd.ExecuteNonQuery();

                        MySqlDataReader result__1 = cmd.ExecuteReader();

                        while (result__1.Read())
                        {
                            today = result__1.GetDateTime(0);
                        }

                        str_today = today.ToString("yyyy-MM-dd hh:mm:ss");

                        result__1.Close();

                    }
                    else if (counter_4 != 0)
                    {
                        String quary7 = "select return_date, today_date from user_book_time where user_id = '" + str_id + "';";
                        cmd = new MySqlCommand(quary7, sqlcon);
                        cmd.ExecuteNonQuery();

                        
                        MySqlDataReader result = cmd.ExecuteReader();

                        while (result.Read())
                        {
                            DateTime return_date_2 = result.GetDateTime(0);
                            today = result.GetDateTime(1);

                            if (today > return_date_2)
                            {
                                counter++;
                            }

                        }

                        str_today = today.ToString("yyyy-MM-dd hh:mm:ss");

                        result.Close();
                    }
                }
                
                ///koşullar
                if (int_books >= 3)
                {
                    warn.Text = "Üzerinizi kayıtlı 3 kitap bulunmaktadır.";
                }
                else if (int_number_of_left_books == 0)
                {
                    warn.Text = "Kitap başka bir kullanıcının üstüne kayıtlıdır";
                }
                else if (counter != 0)
                {
                    warn.Text = "Üzerinize kayıtlı, teslim tarihi geçmiş kitap bulunmaktadır.";
                }
                else
                {
                                                           
                    return_date = today.AddDays(7);
                    str_return_date = return_date.ToString("yyyy-MM-dd hh:mm:ss");

                    String quary_insert = "insert into user_book_time(user_id,book_name,receive_date,return_date,today_date) values ('" + str_id + "','" + TextBox2.Text + "','" + str_today + "','" + str_return_date + "','" + str_today + "');";
                    cmd = new MySqlCommand(quary_insert, sqlcon);
                    cmd.ExecuteNonQuery();

                    String quary_control = "select user_id from user_book_count";
                    cmd = new MySqlCommand(quary_control, sqlcon);
                    cmd.ExecuteNonQuery();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    int counter_2 = 0;
                    while (reader.Read())
                    {
                        if (reader.GetInt32(0) == int.Parse(str_id))
                        {
                            counter_2++;
                        }
                        
                    }

                    reader.Close();

                    if (counter_2 == 0)
                    {
                        String bir = "1";
                        String quary_insert_2 = "insert into user_book_count(user_id, number_of_book) values('" + str_id + "', '" + bir + "');";
                        cmd = new MySqlCommand(quary_insert_2, sqlcon);
                        cmd.ExecuteNonQuery();
                    }
                    else if (counter_2 != 0)
                    {
                        String take_book_number = "select number_of_book from user_book_count where user_id = '" + str_id + "';";
                        cmd = new MySqlCommand(take_book_number, sqlcon);
                        cmd.ExecuteNonQuery();

                        String plus_one;
                        plus_one = cmd.ExecuteScalar().ToString();
                        int int_plus_one = int.Parse(plus_one);
                        int_plus_one = int_plus_one + 1;
                        plus_one = int_plus_one.ToString();
                        //warn.Text = number_of_left_books;
                        String quary_update = "update user_book_count set number_of_book = '" + plus_one + "' where user_id = '" + str_id + "';";
                        cmd = new MySqlCommand(quary_update, sqlcon);
                        cmd.ExecuteNonQuery();
                    }

                    String select_number = "select number from book_table where book_name = '" + TextBox2.Text + "';";
                    cmd = new MySqlCommand(select_number, sqlcon);
                    cmd.ExecuteNonQuery();
                    String number = cmd.ExecuteScalar().ToString();
                    int int_number = int.Parse(number);
                    int_number = int_number - 1;
                    number = int_number.ToString();

                    
                    String update_quary_2 = "update book_table set number = '" + number + "' where book_name = '" + TextBox2.Text + "';";
                    cmd = new MySqlCommand(update_quary_2, sqlcon);
                    cmd.ExecuteNonQuery();

                    warn.Text = " Kitap başarıyla alınmıştır.";
                }

            }
            else if (Label1.Text.Equals("ISBN"))
            {
                ////kalan kitap sayisi for ısbn
                String quary5 = "select number from book_table where ısbn = '" + TextBox2.Text + "';";
                cmd = new MySqlCommand(quary5, sqlcon);
                cmd.ExecuteNonQuery();

                String number_of_left_books_ısbn;
                number_of_left_books_ısbn = cmd.ExecuteScalar().ToString();
                int int_number_of_left_books_ısbn = int.Parse(number_of_left_books_ısbn);
                

                //////time_cpntrol_ısbn

                String start = "SELECT COUNT(*)FROM user_book_time";
                cmd = new MySqlCommand(start, sqlcon);
                cmd.ExecuteNonQuery();

                String row = cmd.ExecuteScalar().ToString();
                int counter = 0;

                if (row.Equals("0"))
                {
                    counter = 0;
                    String quary_time_table = "select today from time_table";
                    cmd = new MySqlCommand(quary_time_table, sqlcon);
                    cmd.ExecuteNonQuery();

                    
                    MySqlDataReader result___1 = cmd.ExecuteReader();

                    while (result___1.Read())
                    {
                        today = result___1.GetDateTime(0);
                    }

                    str_today = today.ToString("yyyy-MM-dd hh:mm:ss");

                    result___1.Close();

                }
                else
                {
                    String quary_control_3 = "select user_id from user_book_time";
                    cmd = new MySqlCommand(quary_control_3, sqlcon);
                    cmd.ExecuteNonQuery();

                    MySqlDataReader result_4 = cmd.ExecuteReader();
                    int counter_5 = 0;
                    while (result_4.Read())
                    {
                        if (result_4.GetInt32(0) == id)
                        {
                            counter_5++;
                        }
                        
                    }

                    result_4.Close();

                    
                    if (counter_5 == 0)
                    {
                        counter = 0;

                        String quary6_2 = "select today_date from user_book_time ;";
                        cmd = new MySqlCommand(quary6_2, sqlcon);
                        cmd.ExecuteNonQuery();

                        MySqlDataReader result__1 = cmd.ExecuteReader();

                        while (result__1.Read())
                        {
                            today = result__1.GetDateTime(0);
                        }

                        str_today = today.ToString("yyyy-MM-dd hh:mm:ss");

                        result__1.Close();
                    }
                    else if (counter_5 != 0)
                    {
                        String quary6 = "select return_date, today_date from user_book_time where user_id = '" + str_id + "';";
                        cmd = new MySqlCommand(quary6, sqlcon);
                        cmd.ExecuteNonQuery();

                        MySqlDataReader read = cmd.ExecuteReader();

                        while (read.Read())
                        {
                            DateTime return_date_2 = read.GetDateTime(0);
                            today = read.GetDateTime(1);

                            
                            if (today > return_date_2)
                            {
                                counter++;
                            }
                            
                        }

                        str_today = today.ToString("yyyy-MM-dd hh:mm:ss");

                        read.Close();

                    }
                }

                
                

                ///koşullar
                if (int_books >= 3)
                {
                    warn.Text = "Üzerinizi kayıtlı 3 kitap bulunmaktadır.";
                }
                else if (int_number_of_left_books_ısbn == 0)
                {
                    warn.Text = "Kitap başka bir kullanıcının üstüne kayıtlıdır";
                }
                else if (counter != 0)
                {
                    warn.Text = "Üzerinize kayıtlı, teslim tarihi geçmiş kitap bulunmaktadır.";
                }
                else
                {
                    warn.Text = " Kitap başarıyla alınmıştır.";
                    String sifir = "0";
                    String find_book_name = "select book_name from book_table where ısbn = '" + TextBox2.Text + "';";
                    cmd = new MySqlCommand(find_book_name, sqlcon);
                    cmd.ExecuteNonQuery();

                    String book_name_from_ısbn;
                    book_name_from_ısbn = cmd.ExecuteScalar().ToString();

                                       
                    
                    return_date = today.AddDays(7);
                    str_return_date = return_date.ToString("yyyy-MM-dd hh:mm:ss");

                    String quary_insert = "insert into user_book_time(user_id,book_name,receive_date,return_date,today_date) values ('" + str_id + "','" + book_name_from_ısbn + "','" + str_today + "','" + str_return_date + "','" + str_today + "');";
                    cmd = new MySqlCommand(quary_insert, sqlcon);
                    cmd.ExecuteNonQuery();

                   
                    String quary_control = "select user_id from user_book_count";
                    cmd = new MySqlCommand(quary_control, sqlcon);
                    cmd.ExecuteNonQuery();

                    MySqlDataReader reader = cmd.ExecuteReader();
                    int counter_2 = 0;
                    while (reader.Read())
                    {
                        if (reader.GetInt32(0) == int.Parse(str_id))
                        {
                            counter_2++;
                        }
                        
                    }

                    reader.Close();

                    if (counter_2 == 0)
                    {
                        String bir = "1";
                        String quary_insert_2 = "insert into user_book_count(user_id, number_of_book) values('" + str_id + "', '" + bir + "');";
                        cmd = new MySqlCommand(quary_insert_2, sqlcon);
                        cmd.ExecuteNonQuery();
                    }
                    else if (counter_2 != 0)
                    {
                        String take_book_number = "select number_of_book from user_book_count where user_id = '" + str_id + "';";
                        cmd = new MySqlCommand(take_book_number, sqlcon);
                        cmd.ExecuteNonQuery();

                        String plus_one;
                        plus_one = cmd.ExecuteScalar().ToString();
                        int int_plus_one = int.Parse(plus_one);
                        int_plus_one = int_plus_one + 1;
                        plus_one = int_plus_one.ToString();
                        
                        String quary_update = "update user_book_count set number_of_book = '" + plus_one + "' where user_id = '" + str_id + "';";
                        cmd = new MySqlCommand(quary_update, sqlcon);
                        cmd.ExecuteNonQuery();
                    }


                    String select_number = "select number from book_table where ısbn = '" + TextBox2.Text + "';";
                    cmd = new MySqlCommand(select_number, sqlcon);
                    cmd.ExecuteNonQuery();
                    String number = cmd.ExecuteScalar().ToString();
                    int int_number = int.Parse(number);
                    int_number = int_number - 1;
                    number = int_number.ToString();

                    String update_quary_2 = "update book_table set number = '" + number + "' where ısbn = '" + TextBox2.Text + "';";
                    cmd = new MySqlCommand(update_quary_2, sqlcon);
                    cmd.ExecuteNonQuery();

                }

                sqlcon.Close();
            }
        }

        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transfer_user_panel.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_page.aspx");
        }
    }
}











   
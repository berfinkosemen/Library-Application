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
    public partial class User_panel_2 : System.Web.UI.Page
    {

        string conectionString = "Server=localhost;Database=library_app;Uid=root;Pwd=1234Bz.;";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        String adress = " ";
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //Dosya yükleme kodu internetten alınmıştır.
            // If the user has selected a file
            if (FileUpload1.HasFile)
            {
                // Get the file extension
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                if (fileExtension.ToLower() != ".png" && fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".jpeg")
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Only files with .jpeg, .png and .jpg extension are allowed";
                }
                else
                {
                    // Get the file size
                    int fileSize = FileUpload1.PostedFile.ContentLength;
                    // If file size is greater than 2 MB
                    if (fileSize > 2097152)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "File size cannot be greater than 2 MB";
                    }
                    else
                    {
                        // Upload the file
                        FileUpload1.SaveAs(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "File uploaded successfully";
                        adress = Server.MapPath("~/Uploads/" + FileUpload1.FileName);

                        System.IO.Stream stream = FileUpload1.PostedFile.InputStream;
                        System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

                        int height = image.Height;
                        int width = image.Width;

                        var ocr = new IronOcr.AutoOcr() { ReadBarCodes = false };
                        var Area = new System.Drawing.Rectangle() { X = 0, Y = height * 3 / 4, Width = width, Height = height };

                        String words = ocr.Read(adress, Area).ToString();
                        
                        String[] words_isbn = words.Split(' ');
                        String isbn = "";
                        int i = 0, i_keep = 0;
                        for (i = 0; i < words_isbn.Length; i++)
                        {
                            if (words_isbn[i].Contains("SBN") || words_isbn[i].Equals("ISBN") || words_isbn[i].Equals("İSBN") || words_isbn[i].Equals("ısbn") || words_isbn[i].Equals("isbn") || words_isbn[i].Equals("|SBN") || words_isbn[i].Equals("lSBN") || words_isbn[i].Equals("LSBN"))
                            {

                                i_keep = i;
                            }
                        }

                        if (i_keep == 0 && (words_isbn[i_keep].Contains("ISBN") == false || words_isbn[i_keep].Contains("SBN") == false))
                        {
                            for (i = i_keep; i < words_isbn.Length; i++)
                            {
                                isbn += words_isbn[i];
                            }
                        }
                        else if (words_isbn[i_keep].Contains("ISBN") && words_isbn[i_keep].All(char.IsDigit))
                        {

                            int index = words_isbn[i_keep].IndexOf('I');
                            for (i = index; i < words_isbn[i_keep].Length; i++)
                            {
                                isbn += words_isbn[i_keep][i];
                            }

                            for (i = i_keep + 1; i < words_isbn.Length; i++)
                            {
                                isbn += words_isbn[i];
                            }
                        }
                        else if (words_isbn[i_keep].Contains("ISBN") && words_isbn[i_keep].All(char.IsDigit) == false)
                        {
                            if (words_isbn.Length < i_keep + 8)
                            {
                                for (i = i_keep + 1; i < words_isbn.Length; i++)
                                {
                                    isbn += words_isbn[i];
                                }
                            }
                            else
                            {
                                for (i = i_keep + 1; i < i_keep + 8; i++)
                                {
                                    isbn += words_isbn[i];
                                }
                            }
                        }



                        
                        Regex regex = new Regex("[^0-9]");
                        isbn = regex.Replace(isbn, string.Empty);

                        
                        if (isbn.Length >= 13)
                        {
                            isbn = isbn.Substring(0, 13);
                        }
                        else
                        {
                            isbn = isbn.Substring(0, 10);
                        }

                        ısbn_number.Text = isbn;

                    }
                }
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please select a file";
            }
        }

        protected void insert_Click(object sender, EventArgs e)
        {
            /////id bul
            MySqlConnection sqlcon = new MySqlConnection(conectionString);
            String user_name = Session["id"].ToString();
            String user_password = Session["id2"].ToString();
            String quary = "select user_id from user_table where user_name = '" + user_name + "' and user_password = '" + user_password + "';";
            MySqlCommand cmd = new MySqlCommand(quary, sqlcon);
            sqlcon.Open();
            cmd.ExecuteNonQuery();

            String str_id;
            str_id = cmd.ExecuteScalar().ToString();
            
                        
            ///listede var mı
            

            String start = "SELECT COUNT(*)FROM book_table  where ısbn = '" + ısbn_number.Text + "';";
            cmd = new MySqlCommand(start, sqlcon);
            cmd.ExecuteNonQuery();

            String row = cmd.ExecuteScalar().ToString();
            int counter_3 = 0;

            if (row.Equals("0"))
            {
                lblMessage.Text = "bu kittap sistemde kayıtlı değildir.";
            }
            else
            {            
            /////////// find book name
                String isbn = "select book_name from book_table where ısbn = '" + ısbn_number.Text + "';";
                cmd = new MySqlCommand(isbn, sqlcon);
                cmd.ExecuteNonQuery();

                String book_name;
                book_name = cmd.ExecuteScalar().ToString();

                ////////////////////
                String quary2 = "select user_id from user_book_time where book_name = '" + book_name + "';";
                cmd = new MySqlCommand(quary2, sqlcon);
                cmd.ExecuteNonQuery();

                MySqlDataReader reader_2 = cmd.ExecuteReader();
                
                while (reader_2.Read())
                {
                    if (reader_2.GetInt32(0) == int.Parse(str_id))
                    {
                        counter_3++;
                    }
                    
                }

                reader_2.Close();

                if (counter_3 == 0)
                {
                    lblMessage.Text = "bu kittap üstünüze kayıtlı değildir.";
                }
                else if (counter_3 != 0)
                {
                    

                    String select_number = "select number from book_table where ısbn = '" + ısbn_number.Text + "' and book_name = '" + book_name + "';";
                    cmd = new MySqlCommand(select_number, sqlcon);
                    cmd.ExecuteNonQuery();
                    String number = cmd.ExecuteScalar().ToString();
                    int int_number = int.Parse(number);
                    int_number = int_number + 1;
                    number = int_number.ToString();

                    String update = "update book_table set number = '" + number + "' where book_name = '" + book_name + "' and ısbn = '" + ısbn_number.Text + "';";
                    cmd = new MySqlCommand(update, sqlcon);
                    cmd.ExecuteNonQuery();



                    String take_book_number = "select number_of_book from user_book_count where user_id = '" + str_id + "';";
                    cmd = new MySqlCommand(take_book_number, sqlcon);
                    cmd.ExecuteNonQuery();

                    String plus_one;
                    plus_one = cmd.ExecuteScalar().ToString();
                    int int_plus_one = int.Parse(plus_one);
                    int_plus_one = int_plus_one - 1;
                    plus_one = int_plus_one.ToString();

                    if (int_plus_one == 0)
                    {
                        String delete_2 = "delete from user_book_count where user_id = '" + str_id + "';";
                        cmd = new MySqlCommand(delete_2, sqlcon);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        
                        String quary_update = "update user_book_count set number_of_book = '" + plus_one + "' where user_id = '" + str_id + "';";
                        cmd = new MySqlCommand(quary_update, sqlcon);
                        cmd.ExecuteNonQuery();
                    }

                    ////////user_book_time update
                    String select_num = "select num from user_book_time where user_id = '" + str_id + "' AND book_name = '" + book_name + "';";
                    cmd = new MySqlCommand(select_num, sqlcon);
                    cmd.ExecuteNonQuery();

                    String num;
                    num = cmd.ExecuteScalar().ToString();

                    String delete = "DELETE FROM user_book_time WHERE user_id = '" + str_id + "' AND book_name = '" + book_name + "' AND num = '" +num+ "';";
                    cmd = new MySqlCommand(delete, sqlcon);
                    cmd.ExecuteNonQuery();

                    lblMessage.Text = "Başarıyla iade edilmiştir.";
                }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IronOcr;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Text;
using System.Text.RegularExpressions;


namespace Kutuphane_Uygulamasi
{
    public partial class Manager_panel : System.Web.UI.Page
    {

        MySqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string conectionString = "Server=localhost;Database=library_app;Uid=root;Pwd=1234Bz.;";
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        String adress = " ";
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //resim yükleme kodu internetten alınmıştır.
            // If the user has selected a file
            if (FileUpload1.HasFile)
            {
                // Get the file extension
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                if (fileExtension.ToLower() != ".png" && fileExtension.ToLower() != ".jpg")
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Only files with .png and .jpg extension are allowed";
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
                        var Area = new System.Drawing.Rectangle() { X = 0, Y = height*3/4 , Width = width, Height = height};
                        

                        /*var ocr = new AdvancedOcr() {
                           CleanBackgroundNoise = true,
                           EnhanceContrast = true,
                           EnhanceResolution = true,
                           Language = IronOcr.Languages.English.OcrLanguagePack,
                           Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
                           ColorSpace = AdvancedOcr.OcrColorSpace.Color,
                           DetectWhiteTextOnDarkBackgrounds = false,
                           InputImageType = AdvancedOcr.InputTypes.Document,
                           RotateAndStraighten = true,
                           ReadBarCodes = false,
                           ColorDepth = 4
                       };*/

                        String words = ocr.Read(adress,Area).ToString();

                        String[] words_isbn = words.Split(' ');
                        String isbn = "";
                        int i = 0,i_keep = 0;
                        for (i = 0; i< words_isbn.Length; i++){
                            if (words_isbn[i].Contains("SBN") || words_isbn[i].Equals("ISBN") || words_isbn[i].Equals("İSBN") || words_isbn[i].Equals("ısbn") || words_isbn[i].Equals("isbn") || words_isbn[i].Equals("|SBN") || words_isbn[i].Equals("lSBN") || words_isbn[i].Equals("LSBN"))
                            {                                
                                i_keep = i;   
                            }
                        }

                        if(i_keep == 0 && (words_isbn[i_keep].Contains("ISBN")==false || words_isbn[i_keep].Contains("SBN") == false))
                        {
                            for (i = i_keep; i < words_isbn.Length; i++)
                            {
                                isbn += words_isbn[i];
                            }
                        }
                        else if (words_isbn[i_keep].Contains("ISBN") && words_isbn[i_keep].All(char.IsDigit))
                        {
                           
                            int index = words_isbn[i_keep].IndexOf('I');
                            for (i =index; i< words_isbn[i_keep].Length; i++)
                            {
                                isbn += words_isbn[i_keep][i];
                            }
                            
                            for (i = i_keep+1; i < words_isbn.Length; i++)
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
                            isbn = isbn.Substring(0,13);
                        }else
                        {
                            isbn = isbn.Substring(0,10);
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
            MySqlConnection sqlcon = new MySqlConnection(conectionString);

            String start = "SELECT COUNT(*)FROM book_table";
            sqlcon.Open();
            MySqlCommand cmd = new MySqlCommand(start, sqlcon);
            cmd.ExecuteNonQuery();
            
            String row = cmd.ExecuteScalar().ToString();           

            if (row.Equals("0")){
                String bir = "1";
                string insert_book = "insert into book_table(book_name,ısbn,number) values ('" + TextBox_book_name.Text + "','" + ısbn_number.Text + "','" + bir + "');";
                cmd = new MySqlCommand(insert_book, sqlcon);
                cmd.ExecuteNonQuery();
            }
            else
            {
                String find_book_name = "select book_name from book_table where ısbn = '" + ısbn_number.Text + "';";
                cmd = new MySqlCommand(find_book_name, sqlcon);
                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();
                int counter_2 = 0;
                while (reader.Read())
                {
                    if (reader.GetString(0).Equals(TextBox_book_name.Text))
                    {
                        counter_2++;
                    }
                }

                reader.Close();

                if (counter_2 == 0)
                {
                    String bir = "1";
                    string insert_book = "insert into book_table(book_name,ısbn,number) values ('" + TextBox_book_name.Text + "','" + ısbn_number.Text + "','" + bir + "');";                    
                    cmd = new MySqlCommand(insert_book, sqlcon);
                    cmd.ExecuteNonQuery();
                }
                else if (counter_2 != 0)
                {
                    String select_number = "select number from book_table where ısbn = '" + ısbn_number.Text + "' and book_name = '" + TextBox_book_name.Text + "';";
                    cmd = new MySqlCommand(select_number, sqlcon);
                    cmd.ExecuteNonQuery();
                    String number = cmd.ExecuteScalar().ToString();
                    int int_number = int.Parse(number);
                    int_number = int_number + 1;
                    number = int_number.ToString();

                    String update_quary_2 = "update book_table set number = '" + number + "' where book_name = '" + TextBox_book_name.Text + "';";
                    cmd = new MySqlCommand(update_quary_2, sqlcon);
                    cmd.ExecuteNonQuery();
                }
            }
            sqlcon.Close();

            Label1.Text = "Kitap veri tabanına eklendi.";
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


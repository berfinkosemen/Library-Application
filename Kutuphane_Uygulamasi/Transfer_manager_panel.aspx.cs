using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kutuphane_Uygulamasi
{
    public partial class Transfer_manager_panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void add_book_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager_panel.aspx");
        }

        protected void list_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager_panel_3.aspx");
        }

        protected void time_change_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager_panel_2.aspx");
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home_page.aspx");
        }
    }
}
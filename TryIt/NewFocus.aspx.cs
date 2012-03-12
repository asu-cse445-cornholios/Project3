using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TryIt.reqdServices;

namespace TryIt
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var client = new ReqdServicesClient();

            string [] urls = 
                client.newsFocus(new string[] {TextBox1.Text, TextBox2.Text, TextBox3.Text,TextBox4.Text, TextBox5.Text });

            foreach (string url in urls)
            {
                var hyperLink = new HyperLink();
                hyperLink.NavigateUrl = url;
                hyperLink.Text = url;

                var contentPlaceholder=
                    (ContentPlaceHolder)Master.FindControl("MainContent");
                contentPlaceholder.Controls.Add(hyperLink);
            }

        }
    }
}
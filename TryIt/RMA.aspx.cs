using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class RMA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var client = new reqdServices.ReqdServicesClient();
            reqdServices.RMAticket rma = client.submitRMA(TextBox1.Text, TextBox2.Text);
            TextBox3.Text =
                "RMA ticket number: " + rma.RMANumber +
                "\r\nExpiration Date: " + rma.ExpirationDate;
        }
    }
}
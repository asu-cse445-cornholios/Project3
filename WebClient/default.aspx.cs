using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceProxy.Service1Client client = new ServiceProxy.Service1Client();

            string response = client.GetData(int.Parse(TextBox1.Text));
            Label1.Text = response;
        }
    }
}
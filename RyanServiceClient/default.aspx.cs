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
            ServiceProxy.RyanServiceClient client = new ServiceProxy.RyanServiceClient();

            string[] response = client.getWsOperations(TextBox1.Text);

            TextBox2.Text = "";
            foreach (string s in response)
            {
                TextBox2.Text += s + "\n";
            }
        }
    }
}
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


        protected void btnInvoke_Click(object sender, EventArgs e)
        {
            ServiceProxy.RyanServiceClient client = new ServiceProxy.RyanServiceClient();
            txtResponse.Text = "";
            string url = txtUrl.Text;
            string[] response = client.getWsOperations(url);
            foreach (string line in response)
            {
                txtResponse.Text += line + "\n";
            }
        }
    }
}
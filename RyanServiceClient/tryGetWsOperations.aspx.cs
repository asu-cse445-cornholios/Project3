using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class TryGetWsOperations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInvoke_Click(object sender, EventArgs e)
        {
            ServiceProxy.RyanServiceClient client = new ServiceProxy.RyanServiceClient();
            txtResponse.Text = "";
            string[] result = client.getWsOperations(txtInput.Text);

            foreach (string s in result)
            {
                txtResponse.Text += s + "\n";
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebClient
{
    public partial class WsHashOperations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInvoke_Click(object sender, EventArgs e)
        {
            ServiceProxy.RyanServiceClient client = new ServiceProxy.RyanServiceClient();
            txtResponse.Text = "";
            Dictionary<object, object> result = client.WsHashOperations(txtInput.Text);

            foreach (string s in result.Keys)
            {
                txtResponse.Text += s + ": " + result[s] + "\n";
            }
        }
    }
}
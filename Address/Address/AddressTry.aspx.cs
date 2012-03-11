using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Address
{
    public partial class Address : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            WSDLAddress.ServiceClient proxy = new WSDLAddress.ServiceClient();
            string[] output = proxy.getWsdlAddress(TextBox.Text);

            foreach (string stringOut in output)
            {
                outputLabel.Text += stringOut + "<br/>\n";
            }
        }
    }
}
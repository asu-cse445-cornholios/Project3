using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSDLDiscovery
{
    public partial class Discovery : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            DiscoveryService.Service1Client proxy = new DiscoveryService.Service1Client();
            string[] output = proxy.WsdlDiscovery(TextBox.Text);

            foreach (string stringOut in output)
            {
                outputLabel.Text += stringOut + "<br/>\n";
            }
        }
    }
}
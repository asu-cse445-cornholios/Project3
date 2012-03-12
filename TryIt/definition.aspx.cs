using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class definition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var client = new reqdServices.ReqdServicesClient();
            string[] defs = client.getDefinition(txtWord.Text);
            foreach (string def in defs)
            {
                txtResult.Text += "----------------------\r\n" + def + "\r\n";
            }
        }
    }
}
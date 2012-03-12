using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StemmingServiceWebApplication.StemmingServiceProxy;

namespace StemmingServiceWebApplication
{
    public partial class StemmingServiceTryItPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var proxy = new StemmingServiceClient();
            try
            {
                if (!String.IsNullOrWhiteSpace(txtInput.Text))
                {
                    var result = proxy.Stemming(txtInput.Text);
                    lblResult.Text = result;
                }
                proxy.Close();
            }
            catch (TimeoutException timeout)
            {
                lblResult.Text = timeout.Message;
                proxy.Abort();
            }
            catch (CommunicationException commException)
            {
                lblResult.Text = commException.Message;
                proxy.Abort();
            }

        }
    }
}
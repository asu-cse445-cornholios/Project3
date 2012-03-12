using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Top10ContentWordsWebApplication
{
    public partial class Top10ContentWordsServiceTryItPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var proxy = new Top10ContentWordsServiceProxy.Top10ContentWordsServiceClient();
            try
            {
                if (!String.IsNullOrWhiteSpace(txtInput.Text))
                {
                    var result = proxy.Top10ContentWords(txtInput.Text);
                    lblResult.Text = String.Join("<br />\n", result);
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
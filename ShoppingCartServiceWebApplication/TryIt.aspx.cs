using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCartServiceWebApplication
{
    public partial class ShoppingCartServiceTryItPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var proxy = new ShoppingCartServiceProxy.ShoppingCartServiceClient();
            try
            {
                var newCart = proxy.CreateCart();
                txtCartId.Text = newCart.ToString(CultureInfo.InvariantCulture);
                lblResult.Text = String.Format("Cart created with ID:") + newCart;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            var proxy = new ShoppingCartServiceProxy.ShoppingCartServiceClient();
            try
            {
                var shoppingCartId = Int32.Parse(txtCartId.Text);
                var quantity = Int32.Parse(txtItemQuantity.Text);
                var success = proxy.AddItemToCart(shoppingCartId, txtInput.Text, quantity);
                lblResult.Text = String.Format("Operation was ") + (success ? "successful" : "unsuccessful");
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            var proxy = new ShoppingCartServiceProxy.ShoppingCartServiceClient();
            try
            {
                var shoppingCartId = Int32.Parse(txtCartId.Text);
                var cartItemId = Int32.Parse(txtItemNumber.Text);
                var success = proxy.DeleteItemFromCart(shoppingCartId, cartItemId);
                lblResult.Text = String.Format("Operation was ") + (success ? "successful" : "unsuccessful");
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            var proxy = new ShoppingCartServiceProxy.ShoppingCartServiceClient();
            try
            {
                var shoppingCartId = Int32.Parse(txtCartId.Text);
                var quantity = Int32.Parse(txtItemQuantity.Text);
                var cartItemId = Int32.Parse(txtItemNumber.Text);
                var success = proxy.ModifyItemInCart(shoppingCartId, cartItemId, quantity);
                lblResult.Text = String.Format("Operation was ") + (success ? "successful" : "unsuccessful");
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            var proxy = new ShoppingCartServiceProxy.ShoppingCartServiceClient();
            try
            {
                var shoppingCartId = Int32.Parse(txtCartId.Text);
                var success = proxy.ClearCart(shoppingCartId);
                lblResult.Text = String.Format("Operation was ") + (success ? "successful" : "unsuccessful");
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

        protected void Button6_Click(object sender, EventArgs e)
        {
            var proxy = new ShoppingCartServiceProxy.ShoppingCartServiceClient();
            try
            {
                var shoppingCartId = Int32.Parse(txtCartId.Text);
                var success = proxy.RemoveCart(shoppingCartId);
                lblResult.Text = String.Format("Operation was ") + (success ? "successful" : "unsuccessful");
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
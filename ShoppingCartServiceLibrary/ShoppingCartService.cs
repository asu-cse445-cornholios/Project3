using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShoppingCartServiceLibrary
{
    public class ShoppingCartService : IShoppingCartService
    {
        public void AddItemToCart(int cartId, string item, int quantity)
        {
            throw new NotImplementedException();
        }

        public void ClearCart(int cartId)
        {
            throw new NotImplementedException();
        }

        public int CreateCart()
        {
            throw new NotImplementedException();
        }

        public ShoppingCart GetCart(string cartId)
        {
            throw new NotImplementedException();
        }

        public void ModifyItemInCart(int cartId, int cartItemId, int quantity)
        {
            throw new NotImplementedException();
        }

        public void DeleteItemFromCart(int cartId, int cartItemId)
        {
            throw new NotImplementedException();
        }
    }
}

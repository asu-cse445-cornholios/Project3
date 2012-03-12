using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShoppingCartServiceLibrary
{
    [ServiceContract]
    public interface IShoppingCartService
    {
        [OperationContract]
        void AddItemToCart(int cartId, string item, int quantity);
        [OperationContract]
        void ClearCart(int cartId);
        [OperationContract]
        int CreateCart();
        [OperationContract]
        ShoppingCart GetCart(string cartId);
        [OperationContract]
        void ModifyItemInCart(int cartId, int cartItemId, int quantity);
        [OperationContract]
        void DeleteItemFromCart(int cartId, int cartItemId);
    }
}

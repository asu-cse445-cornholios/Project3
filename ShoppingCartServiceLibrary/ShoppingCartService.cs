using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShoppingCartServiceLibrary
{
    public class ShoppingCartService : IShoppingCartService
    {
        public bool AddItemToCart(int shoppingCartId, string item, int quantity)
        {
            using (var db = new ShoppingCartContext())
            {
                var shoppingCart = (from c in db.ShoppingCarts.Include("CartItems")
                                    where c.ShoppingCartId == shoppingCartId
                                    select c).FirstOrDefault();
                if (shoppingCart != null)
                {
                    var cartItem = new CartItem
                    {
                        ShoppingCartId = shoppingCartId,
                        Created = DateTime.Now,
                        Modified = DateTime.Now,
                        Item = item,
                        Quantity = quantity,
                        Price = 5.0
                    };
                    db.CartItems.Add(cartItem);
                    shoppingCart.Modified = DateTime.Now;
                }
                return db.SaveChanges() > 0;
            }
        }

        public bool ClearCart(int shoppingCartId)
        {
            using (var db = new ShoppingCartContext())
            {
                var shoppingCart = (from c in db.ShoppingCarts.Include("CartItems")
                                    where c.ShoppingCartId == shoppingCartId
                                    select c).FirstOrDefault();
                if (shoppingCart != null)
                {
                    if (shoppingCart.CartItems != null)
                    {
                        foreach (var cartItem in shoppingCart.CartItems.ToArray())
                        {
                            db.CartItems.Remove(cartItem);
                        }
                    }
                    shoppingCart.Modified = DateTime.Now;
                }
                return db.SaveChanges() > 0;
            }
        }

        public int CreateCart()
        {
            using (var db = new ShoppingCartContext())
            {
                // Create new shopping cart
                var shoppingCart = new ShoppingCart { Created = DateTime.Now, Modified = DateTime.Now };
                db.ShoppingCarts.Add(shoppingCart);
                db.SaveChanges();
                return shoppingCart.ShoppingCartId;
            }
        }

        public ShoppingCart GetCart(int shoppingCartId)
        {
            using (var db = new ShoppingCartContext())
            {
                var q = from c in db.ShoppingCarts.Include("CartItems")
                        where c.ShoppingCartId == shoppingCartId
                        select c;
                return q.FirstOrDefault();
            }
        }

        public bool ModifyItemInCart(int shoppingCartId, int cartItemId, int quantity)
        {
            using (var db = new ShoppingCartContext())
            {
                var q = from i in db.CartItems.Include("ShoppingCart")
                        where i.CartItemId == cartItemId && i.ShoppingCartId == shoppingCartId
                        select i;
                var cartItem = q.FirstOrDefault();
                if (cartItem == null)
                {
                    return false;
                }
                cartItem.Quantity = quantity;
                cartItem.Modified = DateTime.Now;
                cartItem.ShoppingCart.Modified = DateTime.Now;
                return db.SaveChanges() > 0;
            }
        }

        public bool DeleteItemFromCart(int shoppingCartId, int cartItemId)
        {
            using (var db = new ShoppingCartContext())
            {
                var q = from i in db.CartItems.Include("ShoppingCart")
                        where i.CartItemId == cartItemId && i.ShoppingCartId == shoppingCartId
                        select i;
                var cartItem = q.FirstOrDefault();
                if (cartItem == null)
                {
                    return false;
                }
                cartItem.ShoppingCart.Modified = DateTime.Now;
                db.CartItems.Remove(cartItem);
                return db.SaveChanges() > 0;
            }
        }

        public bool RemoveCart(int shoppingCartId)
        {
            using (var db = new ShoppingCartContext())
            {
                var shoppingCart = (from c in db.ShoppingCarts.Include("CartItems")
                                    where c.ShoppingCartId == shoppingCartId
                                    select c).FirstOrDefault();
                if (shoppingCart != null)
                {
                    db.ShoppingCarts.Remove(shoppingCart);
                }
                return db.SaveChanges() > 0;
            }
        }
    }
}

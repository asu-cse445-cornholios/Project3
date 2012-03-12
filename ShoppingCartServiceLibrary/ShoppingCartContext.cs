using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ShoppingCartServiceLibrary
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext()
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}

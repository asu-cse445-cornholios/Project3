using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ShoppingCartServiceLibrary
{
    [DataContract]
    public class CartItem
    {
        [DataMember]
        public int CartItemId { get; set; }

        [DataMember]
        public int ShoppingCartId { get; set; }

        [DataMember]
        public string Item { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public DateTime Modified { get; set; }

        [DataMember]
        public ShoppingCart ShoppingCart { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ShoppingCartServiceLibrary
{
    [DataContract]
    public class ShoppingCart
    {
        [DataMember]
        public int ShoppingCartId { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public DateTime Modified { get; set; }

        [DataMember]
        public ICollection<CartItem> CartItems { get; set; }
    }
}

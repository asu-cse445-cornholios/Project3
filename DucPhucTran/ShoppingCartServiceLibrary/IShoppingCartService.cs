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
        void CartAdd();
        [OperationContract]
        void CartClear();
        [OperationContract]
        void CartCreate();
        [OperationContract]
        void CartGet();
        [OperationContract]
        void CartModify();
    }
}

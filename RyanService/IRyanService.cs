using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RyanService
{
    [ServiceContract]
    public interface IRyanService
    {

        [OperationContract]
        string[] getWsOperations(string url);

        [OperationContract]
        Hashtable WsHashOperations(string wsdlUrl);
    }
   
}

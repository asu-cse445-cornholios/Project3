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
    public class RyanService : IRyanService
    {
        //Required Service 7
        public string[] getWsOperations(string url)
        {
            WsdlOperationInfo info = WsdlOperationInfo.fromURL(url);
            return info.getOperationsArray();
        }

        //Required Service 8
        public Hashtable WsHashOperations(string wsdlUrl)
        {
            WsdlOperationInfo info = WsdlOperationInfo.fromURL(wsdlUrl);
            return info.getOperationsHashtable();
        }

    }
}

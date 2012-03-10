using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Project3
{
    [ServiceContract]
    public interface IRyanService
    {

        [OperationContract]
        string GetData(string val);

    }

}

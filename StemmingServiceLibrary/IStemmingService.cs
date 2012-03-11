using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StemmingServiceLibrary
{
    [ServiceContract]
    public interface IStemmingService
    {
        [OperationContract]
        string Stemming(string str);
    }
}

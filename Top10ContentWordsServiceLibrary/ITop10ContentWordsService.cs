using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Top10ContentWordsServiceLibrary
{
    [ServiceContract]
    public interface ITop10ContentWordsService
    {
        [OperationContract]
        string[] Top10ContentWords(string url);
    }
}

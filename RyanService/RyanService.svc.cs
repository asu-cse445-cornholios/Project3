using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RyanService
{
    public class Service1 : IRyanService
    {
        public string[] getWsOperations(string url)
        {
            string[] data = new string[2];
            data[0] = url;
            data[1] = "eol";
            
            return data;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Project3
{
    public class RyanService : IRyanService
    {
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

    }
}

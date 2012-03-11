using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StemmingServiceLibrary
{
    public class StemmingService : IStemmingService
    {
        public string Stemming(string str)
        {
            return "I should have wrote a jive translator service";
        }
    }
}

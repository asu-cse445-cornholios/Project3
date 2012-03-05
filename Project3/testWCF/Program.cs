using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference.ServiceClient mywcf = new ServiceReference.ServiceClient();
            
            string[] webContent = mywcf.getWsdlAddress("http://data.serviceplatform.org/servicefinder/sf-wsdls.list.sorted");
            foreach (string web in webContent)
            {
                Console.WriteLine(web);
            }
 
            mywcf.Close();
            Console.WriteLine("Press <ENTER> to terminate the client.");
            Console.ReadLine();
        }
    }
}

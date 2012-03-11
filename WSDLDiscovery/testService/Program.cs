using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace testService
{
    class Program
    {
        static void Main(string[] args)
        {
            WSDLDiscovery.Service1Client proxy = new WSDLDiscovery.Service1Client();

            string[] outPut = proxy.WsdlDiscovery(".wsdl,.asmx?wsdl .svc?wsdl");
            
            foreach (string outString in outPut)
            {
                Console.WriteLine(outString);
            }

            Console.ReadLine();
        }
    }
}

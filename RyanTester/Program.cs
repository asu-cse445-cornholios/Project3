using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace RyanTester
{
    class Program
    {
        static void Main(string[] args)
        {

            WsdlOperationInfo info = WsdlOperationInfo.fromURL("http://localhost:1840/RyanService.svc?wsdl");
            foreach (string op in info.getOperationsArray())
            {
                System.Console.WriteLine(op);
            }

            Hashtable table = info.getOperationsHashtable();
            foreach (string key in table.Keys)
            {
                System.Console.WriteLine(key + ": " + table[key]);
            }
        }
    }
}

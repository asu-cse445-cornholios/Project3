using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RyanTester
{
    class Program
    {
        static void Main(string[] args)
        {
            //OperationInfo info = OperationInfo.fromURL("http://localhost:1840/RyanService.svc?wsdl");
            //string[] results = info.getOperations();

            //foreach (string s in results)
            //{
            //    System.Console.WriteLine(s);
            //}

            Class1.test("http://localhost:1840/RyanService.svc?wsdl");
        }
    }
}

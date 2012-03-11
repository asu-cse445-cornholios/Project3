using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace WSDLDiscovery
{
    public class Service1 : IService1
    {
        public string[] WsdlDiscovery(string keyWords)
        {
            Web2String.ServiceClient webProxy = new Web2String.ServiceClient();
            WSDLAddress.ServiceClient addProxy = new WSDLAddress.ServiceClient();
            List<string> wsdladdress = new List<string>();
            Dictionary<string, string> d = new Dictionary<string, string>();
            string[] wsdlList = null;
            string[] words = null;

            char[] c = new char[] {' ', ',' ,';'};
            foreach (char key in keyWords)
            {
                words = keyWords.Split(c);
            }

            try
            {
                bingSearch.SearchRequest searchRequest = new bingSearch.SearchRequest();
                bingSearch.SearchResponse searchResponse = new bingSearch.SearchResponse();
                bingSearch.BingPortTypeClient service = new bingSearch.BingPortTypeClient();

                foreach (string word in words)
                {
                    searchRequest.Query = word;
                    searchRequest.Sources = new bingSearch.SourceType[] { bingSearch.SourceType.Web };
                    searchRequest.AppId = "5DD4DB95BD9D2C28740F329CB5F0FD4F37253B7C";

                    searchRequest.Version = "2.0";
                    searchRequest.Market = "en-us";

                    //search request
                    searchResponse = service.Search(searchRequest);

                    // Display the Web results.
                    System.Text.StringBuilder builder = new System.Text.StringBuilder();
                    foreach (bingSearch.WebResult result in searchResponse.Web.Results)
                    {
                        builder.Length = 0;
                        builder.AppendLine(result.Url);

                        wsdlList = addProxy.getWsdlAddress(builder.ToString());

                        foreach (string wsdl in wsdlList)
                        {
                            //wsdladdress.Add(wsdl.ToString());

                            if (!d.ContainsKey(wsdl))
                            {
                                d.Add(wsdl, wsdl);
                            }
                        }
                    }
                }
            }
            catch (System.Net.WebException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return d.Keys.ToArray();
        }
    }
}

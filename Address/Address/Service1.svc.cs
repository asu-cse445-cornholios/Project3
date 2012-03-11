using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace Address
{
    public class Service1 : IService
    {
        public string[] getWsdlAddress(string url)
        {
            Web2String.ServiceClient webProxy = new Web2String.ServiceClient();
            string webContent = webProxy.GetWebContent(url);
            List<string> wsdladdress = new List<string>();
            Dictionary<string, string> d = new Dictionary<string, string>();

            string pattern = "(http://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?wsdl)";
            //(?<wsdl>....)
            var matches = System.Text.RegularExpressions.Regex.Matches(webContent, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            foreach (Match match in matches)
            {
                string wsdl = match.Value;
                if (!d.ContainsKey(wsdl))
                {
                    d.Add(wsdl, wsdl);
                }
                
                //wsdladdress.Add(wsdl);
            }

            return d.Keys.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

public class Service : IService
{
    public string[] getWsdlAddress(string url)
	{
        Web2String.ServiceClient webProxy = new Web2String.ServiceClient();
        string webContent = webProxy.GetWebContent(url);

        string[] sep = new string[2];
        sep[0] = ".wsdl";
        sep[1] = "?wsdl";
        string[] sites = webContent.Split(sep, System.StringSplitOptions.None);
        
        return sites;
	}
}

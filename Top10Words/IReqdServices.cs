using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace Top10Words
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IReqdServices
    {

        //Required Services
        [OperationContract]
        string[] top10Words(string url);

        [OperationContract]
        string wordFilter(string text);


        //Elective Services

        //NewFocus is from required services list and is not related to the application
        [OperationContract]
        string[] newsFocus(string[] topics);

        [OperationContract]
        string[] getDefinition(string word);

        [OperationContract]
        RMAticket submitRMA(string customerID, string orderID);
        

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class RMAticket
    {
        string rmaNumber = "";
        DateTime expirationDate = DateTime.Today;

        [DataMember]
        public string RMANumber
        {
            get { return rmaNumber; }
            set { rmaNumber = value; }
        }

        [DataMember]
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }
    }
}

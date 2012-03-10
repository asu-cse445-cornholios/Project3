using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Web.Services.Description;
using System.Xml;

namespace Project3
{
    class OperationInfo
    {
        /// <summary>
        /// Contains the operation details from WSDL file
        /// </summary>
        private class OperationDetail
        {
            public string OperationName
            {
                get;
                set;
            }
            public string InParameters
            {
                get;
                set;
            }
            public string OutParameters
            {
                get;
                set;
            }
        }

        List<OperationDetail> operations;

        /// <summary>
        /// Creates the operation info for a given url to wsdl file
        /// </summary>
        /// <param name="url">wsdl file to parse</param>
        /// <returns></returns>
        public static OperationInfo fromURL(string url)
        {
            OperationInfo retVal = new OperationInfo();

            retVal.operations = new List<OperationDetail>();

            //get wsdl service description from an xml reader
            XmlTextReader reader = new XmlTextReader(url);
            ServiceDescription wsdl = ServiceDescription.Read(reader);

            //Go through all of the portTypes
            foreach (PortType portType in wsdl.PortTypes)
            {
                //Go through all of the operations in that port type
                foreach (Operation operation in portType.Operations)
                {
                    //Create a new operation detail for each operation contained in the WSDL
                    OperationDetail operationDetail = new OperationDetail();
                    //Get operation name and save it
                    operationDetail.OperationName = operation.Name;

                    

                    //get the message names from the operation
                    foreach (var message in operation.Messages)
                    {
                        //find match in WSDL messages section
                        foreach (Message messagePart in wsdl.Messages)
                        {

                            if (messagePart.Name != ((OperationMessage)message).Message.Name) continue; //not a match

                            foreach (MessagePart part in messagePart.Parts)
                            {
                                string param;
                                // is it a simple type?
                                //yes
                                if (part.Type != XmlQualifiedName.Empty)
                                {
                                    param = part.Type.ToString();
                                }
                                //no
                                else
                                {
                                    XmlQualifiedName name = part.Element;
                                    param = part.Element.ToString();
                                }

                                if (message is OperationInput)
                                    if (operationDetail.InParameters == null)
                                        operationDetail.InParameters = param;
                                    else
                                        operationDetail.InParameters += "," + param;

                                if (message is OperationOutput)
                                    if (operationDetail.OutParameters == null)
                                        operationDetail.OutParameters = param;
                                    else
                                        operationDetail.OutParameters += "," + param;
                            }
                        }
                    }
                    retVal.operations.Add(operationDetail);
                }
                
            }
            return retVal;
        }

        /// <summary>
        /// Gets an array of strings for the operations available
        /// </summary>
        /// <returns></returns>
        public string[] getOperations()
        {
            List<string> ops = new List<string>();

            foreach (OperationDetail detail in operations)
            {
                ops.Add(detail.OutParameters + " " + detail.OperationName + "(" + detail.InParameters + ")");                
            }

            return ops.ToArray();
        }

        /// <summary>
        /// Gets a Hashtable  for the operations available. THe key is the operation name,
        /// the data is the input followed by output parameters.
        /// </summary>
        /// <returns></returns>
        public Hashtable getOperationsHashtable()
        {
            Hashtable table = new Hashtable();
            foreach (OperationDetail detail in operations)
            {
                try
                {
                    table.Add(detail.OperationName, detail.OutParameters + " | " + detail.InParameters);
                }
                catch
                {
                    //already exists
                }
            }


            return table;
        }
    }
}

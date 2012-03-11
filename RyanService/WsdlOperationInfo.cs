using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel.Description;
using System.Runtime.Serialization;
using System.CodeDom;
using System.Collections;

namespace RyanService
{
    public class WsdlOperationInfo
    {
        #region Private class
        /// <summary>
        /// Contains operation information
        /// </summary>
        private class Operation
        {
            public Operation()
            {
                inTypes = new List<string>();
                outTypes = new List<string>();
            }

            public string Name
            {
                get;
                set;
            }
            public List<string> inTypes
            {
                get;
                set;
            }
            public List<string> outTypes
            {
                get;
                set;
            }
        }
        #endregion

        private List<Operation> operations;

        // make private so user must make from URL
        private WsdlOperationInfo()
        {
            operations = new List<Operation>();
        }

        /// <summary>
        /// Gets an array of strings of all available operations with parameters
        /// </summary>
        /// <returns></returns>
        public string[] getOperationsArray()
        {
            List<string> output = new List<string>();
            foreach (Operation op in operations)
            {
                string name = "";
                string outs = "";
                string ins = "";

                name = op.Name;

                foreach (string par in op.inTypes)
                {
                    if (ins == "") ins = par;
                    else ins += ", " + par;
                }

                foreach (string par in op.outTypes)
                {
                    if (outs == "") outs = par;
                    else outs += ", " + par;
                }

                output.Add(outs + " " + name + "(" + ins + ")");
            }

            return output.ToArray();
        }

        /// <summary>
        /// Gets a Hashtable of strings of all available operations with parameters
        /// </summary>
        /// <returns></returns>
        public Hashtable getOperationsHashtable()
        {
            Hashtable retObj = new Hashtable();

            foreach (Operation op in operations)
            {
                string name = op.Name;
                string types = "";

                foreach (string outType in op.outTypes)
                {
                    if (types == "") types = outType;
                    else types += ", " + outType;
                }

                foreach (string inType in op.inTypes)
                {
                    if (types == "") types = inType;
                    else types += ", " + inType;
                }

                try
                {
                    retObj.Add(name, types);
                }
                catch
                {
                    //already exists
                }
                

            }

            return retObj;
        }

        /// <summary>
        /// Creates the operation info for a given url to wsdl file
        /// </summary>
        /// <param name="url">wsdl file to parse</param>
        /// <returns></returns>
        public static WsdlOperationInfo fromURL(string url)
        {
            // set to true to display debug messages
            bool debug = false;

            // create return object
            WsdlOperationInfo retInfo = new WsdlOperationInfo();

            // generate metadata from wsdl uri
            MetadataExchangeClient mexClient = new MetadataExchangeClient(new Uri(url), MetadataExchangeClientMode.HttpGet);
            mexClient.ResolveMetadataReferences = true;
            MetadataSet metaDocs = mexClient.GetMetadata();

            // give the metadata to WsdlImporter and generate code
            WsdlImporter importer = new WsdlImporter(metaDocs);
            ServiceContractGenerator generator = new ServiceContractGenerator();

            object dataContractImporter;
         
            XsdDataContractImporter xsdDCImporter;
            if (!importer.State.TryGetValue(typeof(XsdDataContractImporter), out dataContractImporter))
            {
                if (debug) Console.WriteLine("Couldn't find the XsdDataContractImporter! Adding custom importer.");
                xsdDCImporter = new XsdDataContractImporter();
                xsdDCImporter.Options = new ImportOptions();
                importer.State.Add(typeof(XsdDataContractImporter), xsdDCImporter);
            }
            else
            {
                xsdDCImporter = (XsdDataContractImporter)dataContractImporter;
                if (xsdDCImporter.Options == null)
                {
                    if (debug) Console.WriteLine("There were no ImportOptions on the importer.");
                    xsdDCImporter.Options = new ImportOptions();
                }
            }

            //give the type schemas to xsd importer
            xsdDCImporter.Import(importer.XmlSchemas);

            System.Collections.ObjectModel.Collection<ContractDescription> contracts = importer.ImportAllContracts();
            importer.ImportAllEndpoints();
            if (generator.Errors.Count != 0)
                throw new Exception("There were errors during code compilation.");


            // Go through each contract
            foreach (ContractDescription contract in contracts)
            {
                generator.GenerateServiceContractType(contract);
                if (debug) System.Console.WriteLine("Contract name: " + contract.Name);
                
                // Go through each operation in the contract
                foreach (var operation in contract.Operations)
                {
                    // Create the strings to contain the operation information
                    Operation operationToAdd = new Operation();
                    operationToAdd.Name = operation.Name;

                    if (debug) System.Console.WriteLine("Operation name: " + operation.Name);
                    
                    // Go through the messages in the operation
                    foreach (var message in operation.Messages)
                    {
                        if (debug) System.Console.WriteLine("Message type: " + message.MessageType);
                        if (debug) System.Console.WriteLine("Message Direction: " + message.Direction);
                        
                        // Handle the output messages
                        if (message.Direction == MessageDirection.Output)
                        {
                            if (message.Body.ReturnValue != null)
                            {
                                if (debug) System.Console.WriteLine("Messagepart Name " + message.Body.ReturnValue.Name);
                                var baseType = typeof(MessagePartDescription).GetField("baseType", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(message.Body.ReturnValue);
                                if (debug) System.Console.WriteLine("messagepart Type " + baseType as string);

                                operationToAdd.outTypes.Add(baseType as string);
                      
                            }
                        }
                        // Handle the input messages
                        else
                        {
                            foreach (var messagePart in message.Body.Parts)
                            {
                                if (debug) System.Console.WriteLine("Messagepart Name " + messagePart.Name);
                                var baseType = typeof(MessagePartDescription).GetField("baseType", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(messagePart);
                                if (debug) System.Console.WriteLine("messagepart Type " + baseType as string);
                                
                                operationToAdd.inTypes.Add(baseType as string);
                            }
                        }
                
                    }
                
                    // Deal with the completed operation
                    retInfo.operations.Add(operationToAdd);
                }
            }


          //  
          //used to write the code, not needed      
          //
            // Write the code dom
          //      System.CodeDom.Compiler.CodeGeneratorOptions options
          //        = new System.CodeDom.Compiler.CodeGeneratorOptions();
          //      options.BracingStyle = "C";
          //      System.CodeDom.Compiler.CodeDomProvider codeDomProvider
          //  = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("C#");
          //      System.CodeDom.Compiler.IndentedTextWriter textWriter
          //  = new System.CodeDom.Compiler.IndentedTextWriter(System.Console.Out);
          //      codeDomProvider.GenerateCodeFromCompileUnit(
          //  generator.TargetCompileUnit, textWriter, options
          //);
          //      textWriter.Close();

            return retInfo;
        }
    }
}

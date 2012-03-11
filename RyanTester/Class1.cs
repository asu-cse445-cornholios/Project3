using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel.Description;
using System.Runtime.Serialization;
using System.CodeDom;

namespace RyanTester
{
    public class Class1
    {

        public static void test(string metadataAddress)
        {
            bool debug = false;

            MetadataExchangeClient mexClient = new MetadataExchangeClient(new Uri(metadataAddress), MetadataExchangeClientMode.HttpGet);
            mexClient.ResolveMetadataReferences = true;
            MetadataSet metaDocs = mexClient.GetMetadata();

            WsdlImporter importer = new WsdlImporter(metaDocs);
            ServiceContractGenerator generator = new ServiceContractGenerator();


            // Add our custom DCAnnotationSurrogate 
            // to write XSD annotations into the comments.
            object dataContractImporter;
         
            XsdDataContractImporter xsdDCImporter;
            if (!importer.State.TryGetValue(typeof(XsdDataContractImporter), out dataContractImporter))
            {
                Console.WriteLine("Couldn't find the XsdDataContractImporter! Adding custom importer.");
                xsdDCImporter = new XsdDataContractImporter();
                xsdDCImporter.Options = new ImportOptions();
                importer.State.Add(typeof(XsdDataContractImporter), xsdDCImporter);
            }
            else
            {
                xsdDCImporter = (XsdDataContractImporter)dataContractImporter;
                if (xsdDCImporter.Options == null)
                {
                    Console.WriteLine("There were no ImportOptions on the importer.");
                    xsdDCImporter.Options = new ImportOptions();
                }
            }

            xsdDCImporter.Import(importer.XmlSchemas);

            System.Collections.ObjectModel.Collection<ContractDescription> contracts
               = importer.ImportAllContracts();
            importer.ImportAllEndpoints();
            if (generator.Errors.Count != 0)
        throw new Exception("There were errors during code compilation.");


		
            foreach (ContractDescription contract in contracts)
            {
                generator.GenerateServiceContractType(contract);
                if (debug) System.Console.WriteLine("Contract name: " + contract.Name);
                foreach (var operation in contract.Operations)
                {
                    string operationName = operation.Name;
                    string inType = "";
                    string outType = "";

                    if (debug) System.Console.WriteLine("Operation name: " + operation.Name);
                    foreach (var message in operation.Messages)
                    {
                        //System.Console.WriteLine("Message type: " + message.MessageType);
                        //System.Console.WriteLine("Message Direction: " + message.Direction);
                        if (message.Direction == MessageDirection.Output)
                        {
                            if (message.Body.ReturnValue != null)
                            {
                                if (debug) System.Console.WriteLine("Messagepart Name " + message.Body.ReturnValue.Name);
                                var baseType = typeof(MessagePartDescription).GetField("baseType", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(message.Body.ReturnValue);
                                if (debug) System.Console.WriteLine("messagepart Type " + baseType as string);
                                if (outType == "")
                                    outType = baseType as string;
                                else
                                    outType += ", " + baseType as string;
                      
                            }
                        }
                        else //input message
                        {
                            foreach (var messagePart in message.Body.Parts)
                            {
                                if (debug) System.Console.WriteLine("Messagepart Name " + messagePart.Name);
                                var baseType = typeof(MessagePartDescription).GetField("baseType", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(messagePart);
                                if (debug) System.Console.WriteLine("messagepart Type " + baseType as string);
                                if (inType == "")
                                    inType = baseType as string;
                                else
                                    inType += ", " + baseType as string;
                            }
                        }
                
                    }
                
                    System.Console.WriteLine(outType + " " + operationName + "(" + inType + ")");
                }
            }

            
      //used to write the code, not needed      
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
        }
    }
}

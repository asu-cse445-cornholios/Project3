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
                System.Console.WriteLine("Contract name: " + contract.Name);
                foreach (var operation in contract.Operations)
                {
                    System.Console.WriteLine("Operation name: " + operation.Name);
                    foreach (var message in operation.Messages)
                    {
                        System.Console.WriteLine("Message type: " + message.MessageType);
                        System.Console.WriteLine("Message Direction: " + message.Direction);
                        if (message.Direction == MessageDirection.Output)
                        {
                            if (message.Body.ReturnValue != null)
                            {
                                System.Console.WriteLine("Messagepart Name " + message.Body.ReturnValue.Name);
                                var crap = typeof(MessagePartDescription).GetField("baseType", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(message.Body.ReturnValue);
                                System.Console.WriteLine("messagepart Type " + crap as string);
                            }
                        }
                        foreach (var messagePart in message.Body.Parts)
                        {
                            System.Console.WriteLine("Messagepart Name " + messagePart.Name);
                            var crap = typeof(MessagePartDescription).GetField("baseType",System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Instance).GetValue(messagePart);
                            System.Console.WriteLine("messagepart Type " + crap as string);
                        }
                
                    }
                
                }
            }

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

using System;
using System.IO;
using System.Linq;

namespace InriverModelBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            
            if (args.Length <2)
            {
                Console.WriteLine("Usage: InriverModelBuilder.exe APISTRING FILENAME.cs");
                Console.ReadKey();
                return;
            }
            var apiKey = args[0];
            var fileName = args[1];
            if (!fileName.EndsWith(".cs"))
            {
                fileName = fileName + ".cs";
            }
            var iac = new InriverApiConnector(apiKey);
            var parser = new InriverParser();
            var cvlsJson = iac.GetCvls();
            var cvls = parser.ParseCvls(cvlsJson);

            var entities = iac.GetEntityTypesJson();
            var resultString = parser.Parse(entities,cvls);
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.Write(resultString);
            }
        }
    }
}

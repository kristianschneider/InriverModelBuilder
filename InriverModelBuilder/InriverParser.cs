using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace InriverModelBuilder
{
    internal class InriverParser
    {
        public string Parse(string json, Dictionary<string, string> cvls)
        {
            var sb = new StringBuilder();
            JArray models = JArray.Parse(json);
            foreach (var child in models.Children())
            {
                WriteClass(child, ref sb,cvls);
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private void WriteClass(JToken child, ref StringBuilder sb, Dictionary<string, string> cvls)
        {
            var id = (string) child["id"];
            sb.AppendLine($"public class {id.FirstCharToUpper()}{{");
            sb.AppendLine();
            WriteProperties((JArray)child["fieldTypes"], sb,cvls);
            sb.AppendLine("}");
        }

        private void WriteProperties(JArray jArray, StringBuilder sb,Dictionary<string,string> cvls)
        {
            foreach (var child in jArray)
            {
                var ft = (string)child["fieldDataType"];
                var ftId = (string)child["fieldTypeId"];
                if (ft == "CVL")
                {
                    var cvlId = (string)child["cvlId"];
                     ft = cvls[cvlId];
                     sb.AppendLine("  /*This is a CVL property*/");

                }
                sb.AppendLine($"  public {ft.FirstCharToUpper()} {ftId} {{get; set;}}");
                sb.AppendLine();

            }
        }

        public Dictionary<string,string> ParseCvls(string cvlsJson)
        {
            JArray cvlsArray = JArray.Parse(cvlsJson);
            var dic = new Dictionary<string,string>();
            foreach (var child in cvlsArray)
            {
                var dt = (string) child["dataType"];
                var id = (string) child["id"];
                dic.Add(id,dt );
            }

            return dic;
        }
    }
}
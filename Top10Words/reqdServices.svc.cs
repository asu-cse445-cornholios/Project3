using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;


namespace Top10Words
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Top10Words : ITop10Words
    {
        public string[] top10Words(string url)
        {
            var webClient = new Web2String.ServiceClient();
            string content = webClient.GetWebContent(url);

            content = stripTags(content);

            string[] words = content.Split(' ');
            var wordCount = new Dictionary<string, int>();
            foreach (string word in words) 
            {
                string w = word.Trim();
                if (wordCount.ContainsKey(w))
                {
                    wordCount[w]++;
                }
                else if (w != "" && Regex.IsMatch(word, @"^[a-zA-Z]*$"))
                {
                    wordCount.Add(w, 1);
                }
                
            }

            var top10 =
                from word in wordCount
                orderby word.Value descending
                select word;

            var a = top10.Take(10);
            
            
            return new string[] {"a","b"};
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        private static string stripTags(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }
    }
}

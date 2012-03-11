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
    public class ReqdServices : IReqdServices
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

            var sortedWords =
                from word in wordCount
                orderby word.Value descending
                select word.Key;

            return sortedWords.Take(10).ToArray<string>();
                       
        }

        public string wordFilter(string text)
        {
            string[] stopWords = { "a", "an", "in", "on", "the", "is", "are", "am" };
            text = stripTags(text);

            const string PatternTemplate = @"\b({0})(s?)\b";
            const RegexOptions Options = RegexOptions.IgnoreCase;

            IEnumerable<Regex> stopWordMatchers = stopWords.
                Select(x => new Regex(string.Format(PatternTemplate, x), Options));

            string output = stopWordMatchers.
               Aggregate(text, (current, matcher) => matcher.Replace(current, ""));

            return output;
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

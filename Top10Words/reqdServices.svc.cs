using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using Top10Words.BingSearch;
using Top10Words.DictionarySvc;
using System.Security.Cryptography;


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

        public string[] newsFocus(string[] topics)
        {
            var bingSvc = new BingPortTypeClient();
            var bingRequest = new SearchRequest();
            var bingResponse = new SearchResponse();

            bingRequest.Sources = new BingSearch.SourceType[] { BingSearch.SourceType.News };
            bingRequest.Version = "2.0";
            bingRequest.Market = "en-us";
            bingRequest.AppId = "FFF1CC94F417A5A29C8A08D6C0EF7CF07AACCB17";

            var URLs = new List<string>();

            foreach (string topic in topics)
            {
                if (topic.Length > 0)
                {

                    bingRequest.Query = topic;

                    bingResponse = bingSvc.Search(bingRequest);

                    foreach (NewsResult result in bingResponse.News.Results)
                    {
                        URLs.Add(result.Url);
                    }
                }
            }

            return URLs.ToArray();
        }

        public string[] getDefinition(string word)
        {
            var definitions = new List<string>();
            var svc = new DictService();
            WordDefinition response = svc.Define(word);

            foreach (Definition definition in response.Definitions)
            {
                definitions.Add(definition.WordDefinition);
            }

            return definitions.ToArray();
        }

        public RMAticket submitRMA(string customerID, string orderID)
        {
            var RMA = new RMAticket();

            /*
            byte[] hashInput = Encoding.UTF8.GetBytes(customerID + orderID);
                        
            RMA.RMANumber =  Encoding.UTF8.GetString(new MD5CryptoServiceProvider().ComputeHash(hashInput));
             * 
             */
            RMA.RMANumber = hash(customerID + orderID).ToString();
            RMA.ExpirationDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 3, DateTime.Today.Day);

            return RMA;
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

        private int hash(string s)
        {
            uint hash = 0;

            foreach (byte b in System.Text.Encoding.Unicode.GetBytes(s))
            {   
                hash += b;
                hash += (hash << 10);
                hash ^= (hash >> 6);    
            }

            hash += (hash << 3);
            hash ^= (hash >> 11);
            hash += (hash << 15);

            return (int)(hash % 999999999);
        }
    }
}

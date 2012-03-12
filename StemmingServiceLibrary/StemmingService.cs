using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace StemmingServiceLibrary
{
    public class StemmingService : IStemmingService
    {
       private readonly Regex _regExMatch = new Regex(@"\w+", RegexOptions.Compiled);

        public string Stemming(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                return String.Empty;
            }
            var result = _regExMatch.Replace(str, new MatchEvaluator(ReplaceWordWithStem));
            return result;
            
        }

        private string ReplaceWordWithStem(Match match)
        {
            if (String.IsNullOrWhiteSpace(match.Value))
            {
                return String.Empty;
            }
            else
            {
                return new EnglishStemmer.EnglishWord(match.Value).Stem;
            }
        }
    }
}

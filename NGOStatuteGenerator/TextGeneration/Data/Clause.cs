using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NGOStatuteGenerator.TextGeneration.Data
{
    public class Clause
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty("placeholders", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, Dictionary<string, string>> Placeholders { get; set; }

        public string BuildText(IPlaceholderSupplier dataSource)
        {
            return Document.PlaceholderRegex.Replace(Text, match => EvaluatePlaceholder(match.Value, dataSource.GetPlaceholderValue(match.Value)));
        }

        private string EvaluatePlaceholder(string placeholder, string value)
        {
            if (Placeholders == null || !Placeholders.ContainsKey(placeholder))
            {
                return value;
            }
            else
            {
                if (Placeholders[placeholder].TryGetValue(value, out string result))
                {
                    return result;
                }
            }

            return value;
        }
    }
}
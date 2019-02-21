using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOStatuteGenerator.Models
{
    public class PurposeItem
    {
        [JsonProperty("purpose")]
        public string LegalPurpose { get; set; }
        [JsonProperty("laymanTranslations")]
        public IEnumerable<string> LaymanTranslations { get; set; }
        [JsonProperty("keywords")]
        public IEnumerable<string> Keywords { get; set; }
    }
}

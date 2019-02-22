using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOStatuteGenerator.TextGeneration.Data
{
    public class Paragraph
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("clauses")]
        public IEnumerable<Clause> Clauses { get; set; }

        public DocumentParagraph BuildDocumentParagraph(IPlaceholderSupplier dataSource)
        {
            var result = new DocumentParagraph();
            result.Header = Title;
            foreach (var clause in Clauses)
            {
                result.Body.Add(clause.BuildText(dataSource));
            }
            return result;
        }
    }
}

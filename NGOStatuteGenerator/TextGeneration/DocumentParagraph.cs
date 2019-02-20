using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOStatuteGenerator.TextGeneration
{
    public class DocumentParagraph
    {
        public string Header { get; set; }
        public IList<string> Body { get; } = new List<string>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOStatuteGenerator.TextGeneration
{
    public class DocumentParagraph
    {
        /// <summary>
        /// Paragraph header
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Lines in the paragraph body
        /// </summary>
        public IList<string> Body { get; } = new List<string>();
    }
}

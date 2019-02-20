using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGOStatuteGenerator.TextGeneration
{
    public class Document
    {
        /// <summary>
        /// Document title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Font name
        /// </summary>
        public string FontName { get; set; }
        /// <summary>
        /// Font size in half points
        /// </summary>
        public int FontSize { get; set; }

        /// <summary>
        /// Paragraphs
        /// </summary>
        public IList<DocumentParagraph> Paragraphs { get; } = new List<DocumentParagraph>();

        public string Build()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(String.Format(RTF_HEADER, FontName, FontSize).Replace("[", "{").Replace("]", "}"));
            builder.AppendLine(String.Format(TITLE_FORMAT, RtfEscape(Title)));
            
            foreach (var para in Paragraphs)
            {
                builder.AppendLine(String.Format(HEADER_FORMAT, RtfEscape(para.Header)));
                
                foreach (var line in para.Body)
                {
                    builder.AppendLine(String.Format(CLAUSE_FORMAT, RtfEscape(line)));
                }
            }

            builder.AppendLine("}");

            return builder.ToString();
        }

        private string RtfEscape(string input)
        {
            string result = input;

            if (input == null)
            {
                return "";
            }

            var encoding = Encoding.GetEncoding(1252);
            for (int i = 0; i < 255; ++i)
            {
                if (i == 167)
                {

                }

                char c = '?';
                if (i > 127)
                {
                    c = encoding.GetChars(new byte[] { (byte)i }).FirstOrDefault();
                }
                else if (i <= 31 || i >= 127)
                {
                    c = (char)i;
                }
                result = result.Replace($"{c}", $"\\'{i.ToString("X2")}");
            }

            return result;
        }

        private const string RTF_HEADER = @"[\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1031[\fonttbl[\f0\fnil\fcharset0 {0};]]\viewkind4\uc1\pard\sa200\sl276\slmult1\qj\f0\fs{1}";
        private const string TITLE_FORMAT = @"\ul\b {0}\par\ulnone\b0";
        private const string HEADER_FORMAT = @"\b {0}\par\b0";
        private const string CLAUSE_FORMAT = @"{0}\par";
    }
}

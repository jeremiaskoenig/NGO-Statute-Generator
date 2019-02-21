using NGOStatuteGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public string Build(Statute model)
        {
            StringBuilder builder = new StringBuilder();
            int indent = 0;

            builder.AppendLine(String.Format(RTF_HEADER, FontName, FontSize).Replace("[", "{").Replace("]", "}"));
            builder.AppendLine(String.Format(TITLE_FORMAT, RtfEscape(BuildText(model, Title), out indent), indent));

            foreach (var para in Paragraphs)
            {
                builder.AppendLine(String.Format(HEADER_FORMAT, RtfEscape(BuildText(model, para.Header), out indent), indent));

                foreach (var line in para.Body)
                {
                    builder.AppendLine(String.Format(CLAUSE_FORMAT, RtfEscape(line, out indent), indent));
                }
            }

            for (int i = 0; i < model.GeneralInformation.FounderCount; i++)
            {
                string name = model.GeneralInformation.FounderNames[i];
                builder.AppendLine(String.Format(SIGNING_LINE, RtfEscape(name, out indent)));
            }

            builder.AppendLine("}");

            return builder.ToString();
        }

        public string BuildText(IPlaceholderSupplier dataSource, string text)
        {
            if (text == null)
            {
                return null;
            }
            return PlaceholderRegex.Replace(text, match => dataSource.GetPlaceholderValue(match.Value));
        }

        internal static readonly Regex PlaceholderRegex = new Regex(@"\$[^\$]+\$", RegexOptions.Compiled);

        private string RtfEscape(string input, out int indentLevel)
        {
            indentLevel = 0;
            string result = input;

            if (input == null)
            {
                return "";
            }

            if (result.Contains("<indent>"))
            {
                indentLevel = Regex.Matches(input, @"\<indent\>").Count * 720;
            }

            var encoding = Encoding.GetEncoding(1252);
            for (int i = 0; i < 255; ++i)
            {
                char c = '\0';
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

        private const string RTF_HEADER = @"[\rtf1\ansi\ansicpg1252\deff0\nouicompat\deflang1031[\fonttbl[\f0\fnil\fcharset0 {0};]]\viewkind4\uc1\fs{1}";
        private const string TITLE_FORMAT = @"\pard\li{1}\sa200\sl276\slmult1\f0\ul\b {0}\par\ulnone\b0";
        private const string HEADER_FORMAT = @"\pard\li{1}\sa200\sl276\slmult1\f0\b {0}\par\b0";
        private const string CLAUSE_FORMAT = @"\pard\li{1}\sa200\sl276\slmult1\qj\f0 {0}\par";
        private const string SIGNING_LINE = @"\pard\sa200\sl276\slmult1\qj\f0 ____________________________ ({0})   ________________ (Datum)\par";
    }
}

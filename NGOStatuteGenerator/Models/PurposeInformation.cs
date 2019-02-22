using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NGOStatuteGenerator.TextGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOStatuteGenerator.Models
{
    public class PurposeInformation : PageModel, IPlaceholderSupplier
    {
        public string PurposeFreeText { get; set; }
        public string PurposeType { get; set; }

        public static IEnumerable<PurposeItem> FindPurpose(string purposeType, string freeText)
        {
            var words = freeText?.Split(' ').Distinct().ToArray();
            return Program.AllPurposes.Where(x => x.PurposeType == purposeType).Where(x => x.Keywords.Intersect(words).Any());
        }

        public string GetPlaceholderValue(string placeholder)
        {
            switch (placeholder)
            {
                case "$PurposeType$":
                    return PurposeType;
                case "$PurposeFreeText$":
                    return PurposeFreeText;
                default:
                    return "";
            }
        }
    }
}

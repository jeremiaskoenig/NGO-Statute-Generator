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

            return  Program.AllPurposes
               .Where(purpose => purpose.PurposeType == purposeType)
               .Where(x =>
               {
                   return x.Keywords.Any(keyword => freeText.Contains(keyword, StringComparison.CurrentCultureIgnoreCase));
               });
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

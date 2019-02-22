using Microsoft.AspNetCore.Mvc.RazorPages;
using NGOStatuteGenerator.TextGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOStatuteGenerator.Models
{
    public class PurposeInformation : PageModel, IPlaceholderSupplier
    {
        public IEnumerable<PurposeItem> ApplicablePurposes { get; set; }
        public string PurposeFreeText { get; set; }
        public string PurposeType { get; set; }

        public PurposeInformation()
        {
            ApplicablePurposes = Program.AllPurposes;
        }

        public void FindPurpose()
        {
            ApplicablePurposes = Program.AllPurposes
                .Where(purpose => purpose.PurposeType == PurposeType)
                .Where(x => 
                {
                    return x.Keywords.Any(keyword => PurposeFreeText.Contains(keyword, StringComparison.CurrentCultureIgnoreCase));
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

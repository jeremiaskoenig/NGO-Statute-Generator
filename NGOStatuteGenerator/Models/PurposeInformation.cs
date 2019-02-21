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
            var words = PurposeFreeText?.Split(' ').Distinct().ToArray();
            ApplicablePurposes = Program.AllPurposes.Where(x => x.PurposeType == PurposeType).Where(x => x.Keywords.Intersect(words).Any());
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

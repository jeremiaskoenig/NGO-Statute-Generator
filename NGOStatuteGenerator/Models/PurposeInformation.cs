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
        public string PurposeFreeText { get; set; }
        public string PurposeType { get; set; }

        public string GetPlaceholderValue(string placeholder)
        {
            switch (placeholder)
            {
                case "$PurposeType$":
                    return PurposeType;
                default:
                    return "";
            }
        }
    } 
}

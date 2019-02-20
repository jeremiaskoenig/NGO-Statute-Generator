using Microsoft.AspNetCore.Mvc.RazorPages;
using NGOStatuteGenerator.TextGeneration;
using System.Collections.Generic;

namespace NGOStatuteGenerator.Models
{
    public class GeneralInformation : PageModel, IPlaceholderSupplier
    {
        public string ClubName { get; set; }
        public bool IsRegistered { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public int FounderCount { get; set; }
        public List<string> FounderNames { get; set; }
        public GeneralInformation()
        {
            FounderNames = new List<string>();
        }

        public string GetPlaceholderValue(string placeholder)
        {
            switch (placeholder)
            {
                case "$ClubName$": return ClubName;
                case "$IsRegistered$": return IsRegistered ? "true" : "false";
                case "$PostCode$": return PostCode.ToString();
                case "$City$": return City;

                default: return placeholder;
            }
        }
    }
}

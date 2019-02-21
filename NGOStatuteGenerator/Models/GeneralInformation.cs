using Microsoft.AspNetCore.Mvc.RazorPages;
using NGOStatuteGenerator.TextGeneration;
using System;
using System.Collections.Generic;

namespace NGOStatuteGenerator.Models
{
    public class GeneralInformation : PageModel, IPlaceholderSupplier
    {
        public string ClubName { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public int FounderCount { get; set; }
        public List<string> FounderNames { get; set; }
        public string ClubToTransmitIfTerminated { get; set; }
        public DateTime FoundingDate { get; set; }
        public GeneralInformation()
        {
            FounderNames = new List<string>(new string[10]);
            FoundingDate = DateTime.Now;
        }

        public string GetPlaceholderValue(string placeholder)
        {
            switch (placeholder)
            {
                case "$ClubName$":
                    return ClubName;
                case "$ClubLocation$":
                    return $"{City}, {PostCode.ToString()}";
                case "$FoundingDate$":
                    return FoundingDate.ToString("dd.MM.yyyy");
                default:
                    return "";
            }
        }
    }
}

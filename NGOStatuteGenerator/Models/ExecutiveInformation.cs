using Microsoft.AspNetCore.Mvc.RazorPages;
using NGOStatuteGenerator.TextGeneration;
using System.Collections.Generic;

namespace NGOStatuteGenerator.Models
{
    public class ExecutiveInformation : PageModel, IPlaceholderSupplier
    {
        public List<string> WholeBoard { get; set; }
        public List<string> BoardAsOfParagraph26 { get; set; }
        public int TermLengthInYears { get; set; }
        public int SummoningPeriodInWeeks { get; set; }
        public string CanDecideCondition { get; set; }
        public string PopularVote { get; set; }
        public string ExecutiveTieBreak { get; set; }
        public ExecutiveInformation()
        {
            WholeBoard = new List<string>();
            BoardAsOfParagraph26 = new List<string>();
        }
        public string GetPlaceholderValue(string placeholder)
        {
            switch (placeholder)
            {
                case "$Vorstandsfrist$":
                    return $"{SummoningPeriodInWeeks} Wochen";
                case "$Vorstandbeschlussfaehigkeit$":
                    return CanDecideCondition;
                case "$VorstandbesBeschlussMehrheit$ ":
                    return PopularVote;
                case "$VorstandsTieBreaker$":
                    return ExecutiveTieBreak;
                default: return "";
            }
        }
    }
}

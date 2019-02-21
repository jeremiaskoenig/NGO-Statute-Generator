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
        public int ExecutivesRequiredForQuorum { get; set; }
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
                case "$SummoningPeriodInWeeks$":
                    return $"{SummoningPeriodInWeeks} Wochen";
                case "$ExecutivesRequiredForQuorum$":
                    return ExecutivesRequiredForQuorum.ToString();
                case "$ExecutivePopularVoteOption$ ":
                    return PopularVote;
                case "$VorstandsTieBreaker$":
                    return ExecutiveTieBreak;
                case "$TermLengthInYears$":
                    return $"{(TermLengthInYears == 1 ? $"{TermLengthInYears} Jahr" : $"{TermLengthInYears} Jahren")}";
                default: return "";
            }
        }
    }
}

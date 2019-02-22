using Microsoft.AspNetCore.Mvc.RazorPages;
using NGOStatuteGenerator.TextGeneration;
using System.Collections.Generic;

namespace NGOStatuteGenerator.Models
{
    public class ExecutiveInformation : PageModel, IPlaceholderSupplier
    {
        public List<string> BoardMembers { get; set; }
        public int TermLengthInYears { get; set; }
        public MeetingOptions MeetingOptions { get; set; }
        public ExecutiveInformation()
        {
            MeetingOptions = new MeetingOptions(MeetingTypes.Executives);
            BoardMembers = new List<string>();
        }
        public string GetPlaceholderValue(string placeholder)
        {
            switch (placeholder)
            {
                case "$SummoningPeriodInWeeks$":
                    return $"{TermLengthInYears} Wochen";
                case "$ExecutivesRequiredForQuorum$":
                    return MeetingOptions.ParticipantsRequiredForQuorum.ToString();
                case "$ExecutivePopularVoteOption$ ":
                    return MeetingOptions.PopularVote;
                case "$TermLengthInYears$":
                    return $"{(TermLengthInYears == 1 ? $"{TermLengthInYears} Jahr" : $"{TermLengthInYears} Jahren")}";
                case "$ExecutiveAgendRequired$":
                    return MeetingOptions.AgendaRequired.ToString();
                default: return "";
            }
        }
    }
}

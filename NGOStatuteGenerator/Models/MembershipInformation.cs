using Microsoft.AspNetCore.Mvc.RazorPages;
using NGOStatuteGenerator.Models.Membership;
using NGOStatuteGenerator.TextGeneration;
using System;
using System.Collections.Generic;

namespace NGOStatuteGenerator.Models
{
    public class MembershipInformation : PageModel, IPlaceholderSupplier
    {
        [Obsolete]
        public int ResignationPeriodInMonths { get; set; }
        [Obsolete]
        public bool RequiresEntreeFee { get; set; }
        [Obsolete]
        public int EntreeFee { get; set; }


        public List<string> MembershipPersonTypes { get; set; }
        public bool RequiresMembershipFee { get; set; }
        public MembershipFee MembershipFee { get; set; }
        public int MinimalMemberRequired { get; set; }
        public string PopularVoteOption { get; set; }
        public MembershipInformation()
        {

            MembershipPersonTypes = new List<string>();
            MembershipFee = new MembershipFee();
        }

        public string GetPlaceholderValue(string placeholder)
        {
            switch (placeholder)
            {
                case "$MembershipFees$":
                    if (MembershipFee.Amount == 0)
                    {
                        return "keine Mitgliedbeiträge";
                    }
                    return $"";
                case "$MemberTypes$":
                    if (MembershipPersonTypes.Count > 0)
                    {
                        return $"{String.Join(", ", MembershipPersonTypes.GetRange(0, MembershipPersonTypes.Count - 2))} und {MembershipPersonTypes[MembershipPersonTypes.Count - 1]}";
                    }
                    return "";
                case "$PopularVoteOption$":
                    return PopularVoteOption;
                case "$CanDecide$":
                    return "";
                default:
                    return "";
            }
        }
    }

}

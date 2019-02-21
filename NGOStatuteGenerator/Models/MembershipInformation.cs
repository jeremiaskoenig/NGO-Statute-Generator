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
        public bool GeneralMeetingRequiresMinimumMembers { get; set; }
        public int MinimalMemberRequired { get; set; }
        public MembershipInformation()
        {
            MembershipFee = new MembershipFee();
        }

        public string GetPlaceholderValue(string placeholder)
        {
            switch (placeholder)
            {
                case "$MemberTypes$":
                    return $"{String.Join(", ", MembershipPersonTypes.GetRange(0, MembershipPersonTypes.Count - 2))} und {MembershipPersonTypes[MembershipPersonTypes.Count - 1]}";
                default:
                    return "";
            }
        }
    }

}

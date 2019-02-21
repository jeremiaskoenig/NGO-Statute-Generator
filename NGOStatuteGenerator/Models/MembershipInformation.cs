using Microsoft.AspNetCore.Mvc.RazorPages;
using NGOStatuteGenerator.Models.Membership;
using System;
using System.Collections.Generic;

namespace NGOStatuteGenerator.Models
{
    public class MembershipInformation : PageModel
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
        public MembershipInformation()
        {
            MembershipFee = new MembershipFee();
        }
    }

}

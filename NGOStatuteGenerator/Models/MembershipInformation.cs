using Microsoft.AspNetCore.Mvc.RazorPages;
using NGOStatuteGenerator.Models.Membership;
using System.Collections.Generic;

namespace NGOStatuteGenerator.Models
{
    public class MembershipInformation : PageModel
    {
        private List<string> MembershipPersonTypes { get; set; }
        public int ResignationPeriodInMonths { get; set; }
        public bool RequiresEntreeFee { get; set; }
        public int EntreeFee { get; set; }
        public bool RequiresMembershipFee { get; set; }
        public MembershipFee MembershipFee { get; set; }
    }

}

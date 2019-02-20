using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOStatuteGenerator.Models.Membership
{
    public class MembershipFee
    {
        public decimal Amount { get; set; }
        public MembershipPeriod MembershipPeriod {get; set;}
    }
}

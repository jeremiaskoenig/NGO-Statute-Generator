using NGOStatuteGenerator.Models.GeneralMeeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOStatuteGenerator.Models
{
    public class GeneralMeetingInformation
    {
        public ContactTypes ContactTypeToSummon { get; set; }
        public int SummoningPeriodIndays { get; set; }
        public bool SummoningRequiresAgenda { get; set; }
    }
}

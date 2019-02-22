using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOStatuteGenerator.Models
{
    public class MeetingOptions
    {
        public int SummoningPeriodInWeeks { get; set; }
        public int ParticipantsRequiredForQuorum { get; set; }
        public string PopularVote { get; set; }
        public List<string> SummoningContactTypes { get; set; }
        public bool AgendaRequired { get; set; }

        public MeetingOptions(MeetingTypes type)
        {
            SummoningPeriodInWeeks = 2;
            SummoningContactTypes = new List<string>(Program.ContactTypes);
            PopularVote = Program.PopularVoteOptions.FirstOrDefault();
            ParticipantsRequiredForQuorum = 2;
            if (type == MeetingTypes.Executives)
            {
                AgendaRequired = false;
            } else
            {
                AgendaRequired = true;
            }
        }
    }
}

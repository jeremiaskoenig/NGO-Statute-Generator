using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NGOStatuteGenerator.Models
{
    public class GeneralMeetingInformation : PageModel
    {
        public bool CaneBeRepresented { get; set; }
        public string ContactTypeToSummon { get; set; }
        public int SummoningPeriodIndays { get; set; }
        public bool SummoningRequiresAgenda { get; set; }
    }
}

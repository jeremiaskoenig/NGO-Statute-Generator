using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NGOStatuteGenerator.Models
{
    public class Statute : PageModel
    {
        public GeneralInformation GeneralInformation { get; set; }
        public PurposeInformation PurposeInformation { get; set; }
        public MembershipInformation MembershipInformation { get; set; }
        public ExecutiveInformation ExecutiveInformation { get; set; }
        public Statute()
        {
            GeneralInformation = new GeneralInformation();
            PurposeInformation = new PurposeInformation();
            MembershipInformation = new MembershipInformation();
            ExecutiveInformation = new ExecutiveInformation();
        }
    }
}

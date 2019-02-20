using System.Collections.Generic;

namespace NGOStatuteGenerator.Models
{
    public class GeneralInformation
    {
        public string ClubName { get; set; }
        public bool IsRegistered { get; set; }
        public int PostCode { get; set; }
        public string City { get; set; }
        public int FounderCount { get; set; }
        public List<string> FounderNames { get; set; }
        public GeneralInformation()
        {
            FounderNames = new List<string>();
        }
    }
}

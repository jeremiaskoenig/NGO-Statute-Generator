using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace NGOStatuteGenerator.Models
{
    public class ExecutiveInformation : PageModel
    {
        public List<string> WholeBoard { get; set; }
        public List<string> BoardAsOfParagraph26 { get; set; }
        public int TermLengthInYears { get; set; }
        public ExecutiveInformation()
        {
            WholeBoard = new List<string>();
            BoardAsOfParagraph26 = new List<string>();
        }      
    }
}

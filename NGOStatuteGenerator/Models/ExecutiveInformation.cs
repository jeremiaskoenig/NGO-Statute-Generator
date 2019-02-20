using NGOStatuteGenerator.Models.Executive;
using System.Collections.Generic;

namespace NGOStatuteGenerator.Models
{
    public class ExecutiveInformation
    {

        public List<Executives> WholeBoard { get; set; }
        public List<Executives> BoardAsOfParagraph26 { get; set; }
        public int TermLengthInYears { get; set; }
        public ExecutiveInformation()
        {
            WholeBoard = new List<Executives>();
            BoardAsOfParagraph26 = new List<Executives>();
        }
    }
}

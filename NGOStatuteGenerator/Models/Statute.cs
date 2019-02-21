using Microsoft.AspNetCore.Mvc.RazorPages;
using NGOStatuteGenerator.TextGeneration;
using System.Collections.Generic;

namespace NGOStatuteGenerator.Models
{
    public class Statute : PageModel, IPlaceholderSupplier
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

        public string GetPlaceholderValue(string placeholder)
        {
            List<IPlaceholderSupplier> suppliers = new List<IPlaceholderSupplier>()
            {
                GeneralInformation,
                PurposeInformation,
                MembershipInformation,
                ExecutiveInformation
            };

            var result = "";
            foreach (var supplier in suppliers)
            {
                result = supplier.GetPlaceholderValue(placeholder);
                if (result != "")
                {
                    return result;
                }
            }
            return "";
        }
    }
}

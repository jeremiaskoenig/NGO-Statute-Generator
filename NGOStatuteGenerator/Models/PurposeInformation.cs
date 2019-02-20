using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOStatuteGenerator.Models
{
    public class PurposeInformation : PageModel
    {
        public string PurposeFreeText { get; set; }
        public string PurposeType { get; set; }
    } 
}

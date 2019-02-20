using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOStatuteGenerator.Models
{
    public class PurposeInformation
    {
        public string PurposeFreeText { get; set; }
        public PurposeTypes PurposeType { get; set; }
        public string GetPurposeTypeString()
        {
            switch (PurposeType)
            {
                case PurposeTypes.Benevolent:
                    return "mildtätig";
                case PurposeTypes.Church:
                    return "kirchlich";
                case PurposeTypes.NonProfit:
                    return "gemeinnützig";
                default:
                    return "";
            }
        }
    } 
}

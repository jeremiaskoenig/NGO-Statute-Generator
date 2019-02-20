using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOStatuteGenerator.TextGeneration
{
    public interface IPlaceholderSupplier
    {
        string GetPlaceholderValue(string placeholder);
    }
}

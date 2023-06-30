using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBootstrapComponents.Extensions;

public static class StringExtensions
{
    public static string NonBreakingSpace(this string str)
    {
        return string.Concat(str, '\u00A0');
    }
}

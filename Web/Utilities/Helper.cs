using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Web.Utilities
{
    public class Helper
    {
        public static string ToSlug(string text)
        {
            var input = Regex.Replace(text, @"[^\w\@-]", "-").ToLower();

            var replacements = new Dictionary<string, string>
            {
                {"ğ", "g"},
                {"ü", "u"},
                {"ş", "s"},
                {"ı", "i"},
                {"ö", "o"},
                {"ç", "c"},
                {"--", "-"},
                {"---", "-"},
                {"----", "-"}
            };

            foreach (var key in replacements.Keys)
            {
                input = Regex.Replace(input, key, replacements[key]);
            }
            while (input.IndexOf("--", StringComparison.Ordinal) > -1)
                input = input.Replace("--", "-");

            return input;
        }
    }
}
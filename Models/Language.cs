using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace School_Project2021.Models
{
    public class Language
    {
        static string currentLanguage = "en-US";
        public Language(string language)
        {

        }
        public static void UpdateLanguage(string newLanguage)
        {
            if (!string.IsNullOrEmpty(newLanguage))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(newLanguage);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(newLanguage);
            }
        }
    }
}

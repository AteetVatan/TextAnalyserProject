using AnalyseText.Utilities;
using System.Text.RegularExpressions;

namespace AnalyseText.Services
{
    public static class ErrorServices
    {
        public static string InputValid(string text)
        {
            if (!StringUtilities.StringIsValid(text))
                return "Input string cannot be empty.";

            return string.Empty;            
        }

        public static string InputAndWordsValid(string text , string[] words)
        {
            if (!StringUtilities.StringIsValid(text) || !StringUtilities.WordsPresent(words) )
                return "Input string or words cannot be empty.";

            return string.Empty;
        }

        public static string InputAndLettersValid(string text , string[] letters)
        {
            if (!StringUtilities.StringIsValid(text) || !StringUtilities.lettersPresent(letters))
                return "Input string or letters cannot be empty.";

            return string.Empty;
        }
    }
}

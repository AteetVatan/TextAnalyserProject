
using AnalyseText.Utilities;
using System.Linq;
using System.Text.RegularExpressions;

namespace AnalyseText.Services
{
    public class TextAnalyseService
    {
        public int CountWords (string text)
        {
            string[] words = StringUtilities.StringToWords(text);    

            int count = words.Sum(word => Regex.Matches(text, @"\b" + Regex.Escape(word) + @"\b", RegexOptions.IgnoreCase).Count);
            return count;
        }

        public bool ContainWords(string text , string[] words)
        { 
            bool contains = words.All(word => Regex.IsMatch(text, @"\b" + Regex.Escape(word) + @"\b", RegexOptions.IgnoreCase));
            return contains;
        }

        public int CountLetters(string text)
        {
            char[] letters = StringUtilities.StringToCharacters(text);

            int count = letters.Length;
            return count;
        }

        public bool ContainLetters(string text , string[] letters)
        {
            letters = StringUtilities.correctStringArray(letters);
            bool contains = letters.All(letter => text.Contains(letter));
            return contains;
        }

        public bool textIsBase64(string text)
        {
            try
            {
                byte[] contains = Convert.FromBase64String(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool validEmail(string email)
        {
            bool isValid = Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
            return isValid;
        }
    }
}

using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace AnalyseText.Utilities
{
    public class StringUtilities
    {

        public static string[] StringToWords (string text)
        {
            MatchCollection matches = Regex.Matches(text, @"\b[\w']*\b");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value) && !Regex.IsMatch(m.Value, @"\d")
                        select TrimSuffix(m.Value);

            return words.ToArray();
        }

        public static char[] StringToCharacters(string text)
        {
            text = Regex.Replace(text, @"\s+", "");
            text = Regex.Replace(text, @"\d", "");
            char[] ch = new char[text.Length];
            string currentItem;
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                currentItem = text[i].ToString().Trim();
                if (currentItem == string.Empty)
                    continue;

                ch[count] = text[i];
                count++;
            }
            return ch;
        }

        public static string[] correctStringArray(string[] inputLetters)
        {
            List<string> stringList = new List<string>();
            for (int i = 0; i < inputLetters.Length; i++)
            {
                inputLetters[i] = Regex.Replace(inputLetters[i], @"\s+", "");
                inputLetters[i] = Regex.Replace(inputLetters[i], @"\d", "");
                inputLetters[i] = inputLetters[i].ToString().Trim();
                if (inputLetters[i] == string.Empty)
                    continue;

                stringList.Add(inputLetters[i]);
                
            }
            return stringList.ToArray(); ;
        }

        public static bool StringIsValid(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }
            return true;
        }

        public static bool WordsPresent(string[] words)
        {            
            words = words.Where(x => !Regex.IsMatch(x.Trim(), @"\d")).ToArray();
            if (words == null || words.Length == 0)
            {
                return false;
            }
            return true;
        }

        public static bool lettersPresent(string[] letters)
        {
            letters = letters.Where(x => !Regex.IsMatch(x.Trim(), @"\d")).ToArray();
            if (letters == null || letters.Length == 0)
            {
                return false;
            }
            return true;
        }

        public static string[] Correction(string[] words)
        {
            List<string> output = new List<string>();
            string currentItem;
            foreach (var item in words)
            {
                currentItem = item.Trim().ToLower();
                if (currentItem == string.Empty)
                    continue;

                output.AddRange(currentItem.Split(",").ToList());
            }
            words = output.Select(x => x.Trim()).ToArray();
            return words;
        }

        private static string TrimSuffix(string word)
        {
            int apostropheLocation = word.IndexOf('\'');
            if (apostropheLocation != -1)
            {
                word = word.Substring(0, apostropheLocation);
            }

            return word;
        }
    }
}

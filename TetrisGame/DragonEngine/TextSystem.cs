using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DragonEngine
{
    public class TextSystem
    {
        /// <summary>
        /// A text-size enum,  just  Medium size works for now.
        /// </summary>
        public enum TextSize
        {
            Small,
            Medium,
            Large,
        }
        public static Dictionary<char, string> LargeAlphabet = new Dictionary<char, string>
{

    {'A', "▄▀█\r\n█▀█\r\n   " },
    {'a', "▄▀█\r\n█▀█\r\n   " },

    {'B', "█▄▄\r\n█▄█\r\n   " },
    {'b', "█▄▄\r\n█▄█\r\n   " },

    {'C', "█▀▀\r\n█▄▄\r\n   " },
    {'c', "█▀▀\r\n█▄▄\r\n   " },

    {'D', "█▀▄\r\n█▄▀\r\n   " },
    {'d', "█▀▄\r\n█▄▀\r\n   " },

    {'E', "█▀▀\r\n██▄\r\n   " },
    {'e', "█▀▀\r\n██▄\r\n   " },

    {'F', "█▀▀\r\n█▀ \r\n   " },
    {'f', "█▀▀\r\n█▀ \r\n   " },

    {'G', "█▀▀\r\n█▄█\r\n   " },
    {'g', "█▀▀\r\n█▄█\r\n   " },

    {'H', "█ █\r\n█▀█\r\n   " },
    {'h', "█ █\r\n█▀█\r\n   " },

    {'I', " █ \r\n █ \r\n " },
    {'i', " █ \r\n █ \r\n " },

    {'J', "  █\r\n█▄█\r\n   " },
    {'j', "  █\r\n█▄█\r\n   " },

    {'K', "█▄▀\r\n█ █\r\n   " },
    {'k', "█▄▀\r\n█ █\r\n   " },

    {'L', "█  \r\n█▄▄\r\n   " },
    {'l', "█  \r\n█▄▄\r\n   " },

    {'M', "█▄▄█\r\n█ ▀█\r\n   " },
    {'m', "█▄▄█\r\n█ ▀█\r\n   " },

    {'N', "█▄ █\r\n█ ▀█\r\n   " },
    {'n', "█▄ █\r\n█ ▀█\r\n   " },

    {'O', "█▀█\r\n█▄█\r\n   " },
    {'o', "█▀█\r\n█▄█\r\n   " },

    {'P', "█▀█\r\n█▀▀\r\n   " },
    {'p', "█▀█\r\n█▀▀\r\n   " },

    {'Q', "█▀█\r\n▀▀█\r\n   " },
    {'q', "█▀█\r\n▀▀█\r\n   " },

    {'R', "█▀█\r\n█▀▄\r\n   " },
    {'r', "█▀█\r\n█▀▄\r\n   " },

    {'S', "█▀ \r\n▄█ \r\n  " },
    {'s', "█▀ \r\n▄█ \r\n  " },

    {'T', "▀█▀\r\n █ \r\n   " },
    {'t', "▀█▀\r\n █ \r\n   " },

    {'U', "█ █\r\n█▄█\r\n   " },
    {'u', "█ █\r\n█▄█\r\n   " },

    {'V', "█ █\r\n▀▄▀\r\n   " },
    {'v', "█ █\r\n▀▄▀\r\n   " },

    {'W', "█ █ █\r\n▀▄▀▄▀\r\n    " },
    {'w', "█ █ █\r\n▀▄▀▄▀\r\n    " },

    {'X', "▀▄▀\r\n█ █\r\n   " },
    {'x', "▀▄▀\r\n█ █\r\n   " },

    {'Y', "█▄█\r\n █ \r\n   " },
    {'y', "█▄█\r\n █ \r\n   " },

    {'Z', "▀█ \r\n█▄ \r\n   " },
    {'z', "▀█ \r\n█▄ \r\n   " },

    {'?', "▀█ \r\n ▄ \r\n   " },
    {'!', " █ \r\n ▄ \r\n   " },
    {'-', "▄▄▄\r\n   \r\n   " },
    {' ', " \r\n \r\n " },
    {'.', "   \r\n   \r\n ▄ " },
    {',', "   \r\n   \r\n █ " },
    
    {'(', "▄▀ \r\n▀▄ \r\n   " },
    {')', "▀▄ \r\n▄▀ \r\n   " },
   
    {'1', "\r\n   ▄█\r\n   █\r\n     " },
    {'2', "\r\n ▀█  \r\n █▄  \r\n     " },
    {'3', "\r\n█▀▀█ \r\n  ▀▄ \r\n█▄▄█ " },
    {'4', "\r\n █ █ \r\n ▀▀█ \r\n     " },
    {'5', "\r\n █▀  \r\n ▄█  \r\n     " },
    {'6', "\r\n █▄▄ \r\n █▄█ \r\n     " },
    {'7', "\r\n ▀▀█ \r\n   █ \r\n     " },
    {'8', "\r\n▄▀▀▄ \r\n▄▀▀▄ \r\n▀▄▄▀   " },
    {'9', "\r\n █▀█ \r\n ▀▀█ \r\n █   " },
    {'0', "\r\n █▀█ \r\n █▄█ \r\n     " },

        };


        /// <summary>
        /// Returns a multi-line string of "text" according to "size"
        /// </summary>
        /// <param name="text"></param>
        /// <param name="size"></param>
        /// <returns></returns>ת
        public static string ConvertTextSize(string text, TextSize size = TextSize.Medium)
        {
            return ReplaceUsingDictionary(text, LargeAlphabet, 1);
        }

        public static string ReplaceUsingDictionary(string input, Dictionary<char, string> charMapping, int spaceAmount = 0)
        {
            // Split each replacement into lines for easy stitching
            Dictionary<char, string[]> splitMapping = new Dictionary<char, string[]>();

            char lastChar = ' ';

            foreach (var entry in charMapping)
            {
                splitMapping[entry.Key] = entry.Value.Split(new[] { "\r\n" }, StringSplitOptions.None);
                lastChar = splitMapping[entry.Key].ToString().ToCharArray()[0];
            }

            // We'll create a list of lines that will form the final result
            List<string> lines = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                char ch = input[i];
                if (splitMapping.ContainsKey(ch))
                {
                    string[] splitChar = splitMapping[ch];
                    for (int lineIdx = 0; lineIdx < splitChar.Length; lineIdx++)
                    {
                        // Add a new line to the list if it doesn't exist
                        if (lines.Count <= lineIdx)
                        {
                            lines.Add(splitChar[lineIdx]);
                        }
                        else
                        {
                            if (lastChar != ' ') lines[lineIdx] += new string(' ', spaceAmount) + splitChar[lineIdx];
                        }
                    }
                }
                else
                {
                    // Handle characters not in the mapping by adding them directly
                    if (lines.Count == 0)
                    {
                        lines.Add(ch.ToString());
                    }
                    else
                    {
                        lines[0] += new string(' ', spaceAmount) + ch;
                    }
                }
            }

            return string.Join("\r\n", lines);
        }
    }
}
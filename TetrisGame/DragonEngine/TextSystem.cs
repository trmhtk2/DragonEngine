using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DragonEngine
{
    public class TextSystem
    {
        public enum TextSize
        {
            Small,
            Meduim,
            Large,
        }
        public static Dictionary<char, string> LargeAlphabait = new Dictionary<char, string>
        {
            {'A', "\r\n▄▀█\r\n█▀█ " },
            {'a', "\r\n▄▀█\r\n█▀█ " },

            {'b', "\r\n█▄▄\r\n█▄█" },
            {'B', "\r\n█▄▄\r\n█▄█" },

            {'c', "\r\n█▀▀\r\n█▄▄ " },
            {'C', "\r\n█▀▀\r\n█▄▄ " },

            {'d', "\r\n█▀▄\r\n█▄▀ " },
            {'D', "\r\n█▀▄\r\n█▄▀ " },

            {'e', "\r\n█▀▀\r\n██▄ " },
            {'E', "\r\n█▀▀\r\n██▄ " },

            {'f', "\r\n█▀▀\r\n█▀ " },
            {'F', "\r\n█▀▀\r\n█▀ " },

            {'g', "\r\n█▀▀\r\n█▄█ " },
            {'G', "\r\n█▀▀\r\n█▄█ " },
                                  
            {'h', "\r\n█ █\r\n█▀█ " },
            {'H', "\r\n█ █\r\n█▀█ " },

            {'i', "\r\n█\r\n█ " },
            {'I', "\r\n█\r\n█ " },

            {'j', "\r\n█\r\n█▄█ " },
            {'J', "\r\n█\r\n█▄█ " },

            {'k', "\r\n█▄▀\r\n█ █ " },
            {'K', "\r\n█▄▀\r\n█ █ " },

            {'l', "\r\n█  \r\n█▄▄ " },
            {'L', "\r\n█  \r\n█▄▄ " },

            {'m', "\r\n█▀▄▀█\r\n█ ▀ █ " },
            {'M', "\r\n█▀▄▀█\r\n█ ▀ █ " },

            {'n', "\r\n█▄ █\r\n█ ▀█ " },
            {'N', "\r\n█▄ █\r\n█ ▀█ " },

            {'o', "\r\n█▀█\r\n█▄█ " },
            {'O', "\r\n█▀█\r\n█▄█ " },
                                  
            {'p', "\r\n█▀█\r\n█▀▀ " },
            {'P', "\r\n█▀█\r\n█▀▀ " },
                                  
            {'q', "\r\n█▀█\r\n▀▀█ " },
            {'Q', "\r\n█▀█\r\n▀▀█ " },
                                  
            {'r', "\r\n█▀█\r\n█▀▄ " },
            {'R', "\r\n█▀█\r\n█▀▄ " },

            {'s', "\r\n█▀\r\n▄█ " },
            {'S', "\r\n█▀\r\n▄█ " },

            {'t', "\r\n▀█▀\r\n █ " },
            {'T', "\r\n▀█▀\r\n █ " },

            {'u', "\r\n█ █\r\n█▄█ " },
            {'U', "\r\n█ █\r\n█▄█ " },

            {'v', "\r\n█ █\r\n▀▄▀ " },
            {'V', "\r\n█ █\r\n▀▄▀ " },

            {'w', "\r\n█ █ █\r\n▀▄▀▄▀ " },
            {'W', "\r\n█ █ █\r\n▀▄▀▄▀ " },

            {'x', "\r\n▀▄▀\r\n█ █ " },
            {'X', "\r\n▀▄▀\r\n█ █ " },

            {'y', "\r\n█▄█\r\n █ " },
            {'Y', "\r\n█▄█\r\n █ " },
            
            {'z', "\r\n▀█\r\n█▄ " },
            {'Z', "\r\n▀█\r\n█▄ " },

            {'?', "\r\n▀█\r\n ▄ " },
            {'!', "\r\n█\r\n▄ " },

            {'(', "\r\n▄▀\r\n▀▄ " },
            {')', "\r\n▀▄\r\n▄▀ " },

            {'-', " \r\n▄▄\r\n " },
            {' ', " \r\n \r\n " },

        };

        public static string ConvertTextSize(string text, TextSize size = TextSize.Large)
        {
            return ReplaceUsingDictionary(text, LargeAlphabait, 1);
        }

        public static string ReplaceUsingDictionary(string input, Dictionary<char, string> charMapping, int spaceAmount = 0)
        {
            // Split each replacement into lines for easy stitching
            Dictionary<char, string[]> splitMapping = new Dictionary<char, string[]>();
            foreach (var entry in charMapping)
            {
                splitMapping[entry.Key] = entry.Value.Split(new[] { "\r\n" }, StringSplitOptions.None);
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
                            lines[lineIdx] += new string(' ', spaceAmount) + splitChar[lineIdx];
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

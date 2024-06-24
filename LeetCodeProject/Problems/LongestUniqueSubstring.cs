using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.Problems
{
    public static class LongestUniqueSubstring
    {
        public static void Run()
        {
            Console.WriteLine("Longest Substring Without Repeating Characters");

            var input1 = "abcabcbb";
            Console.WriteLine("Result for " + input1 + ": " + LengthOfLongestSubstring(input1));

            var input2 = "bbbbb";
            Console.WriteLine("Result for " + input2 + ": " + LengthOfLongestSubstring(input2));

            var input3 = "pwwkew";
            Console.WriteLine("Result for " + input3 + ": " + LengthOfLongestSubstring(input3));

            var input4 = "dvdf";
            Console.WriteLine("Result for " + input4 + ": " + OptLengthOfLongestSubstring(input4));

            var input5 = " ";
            Console.WriteLine("Result for " + input5 + ": " + OptLengthOfLongestSubstring(input5));
        }

        static int LengthOfLongestSubstring(string s)
        {
            int longestLength = 0;

            try
            {
                int length = 0;
                char[] characters = new char[s.Length];
                int characterLength = 0;
                for(int startPosition = 0; startPosition < s.Length; startPosition++)
                {
                    length = 1;
                    characterLength = 0;
                    characters = new char[s.Length];
                    characters[characterLength++] = s[startPosition];
                    if(startPosition ==  s.Length - 1)
                    {
                        if (longestLength < length)
                            longestLength = length;

                        break;
                    }

                    for (int nextPosition = startPosition + 1; nextPosition < s.Length;)
                    {
                        char character = s[nextPosition];

                        if (characters.Contains(character))
                        {
                            if (longestLength < length)
                                longestLength = length;

                            break;
                        }
                        else if (nextPosition == (s.Length - 1))
                        {
                            length++;
                            if (longestLength < length)
                                longestLength = length;

                            length = 0;
                            nextPosition++;
                        }
                        else
                        {
                            length++;
                            nextPosition++;
                            characters[characterLength++] = character;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return longestLength;
        }

        static int OptLengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            int ans = 0; // for storing the result

            // Dictionary to store the characters in current window
            Dictionary<char, int> map = new Dictionary<char, int>();

            // Try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++)
            {
                if (map.ContainsKey(s[j]))
                {
                    i = Math.Max(map[s[j]], i);
                }

                ans = Math.Max(ans, j - i + 1);
                map[s[j]] = j + 1;
            }

            return ans;
        }
    }
}

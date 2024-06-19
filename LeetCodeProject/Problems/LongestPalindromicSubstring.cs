using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.Problems
{
    public static class LongestPalindromicSubstring
    {
        public static void Run()
        {
            Console.WriteLine("Longest Palindromic Substring");

            Console.WriteLine("Result for babad: " + LongestPalindrome("babad"));
            Console.WriteLine("Result for cbbd: " + LongestPalindrome("cbbd"));
            Console.WriteLine("Result for aacabdkacaa: " + LongestPalindrome("aacabdkacaa"));
        }

        public static string LongestPalindrome(string s)
        {
            var ans = String.Empty;

            try
            {
                long longestLength = 0;
                var sArrays = s.ToCharArray();
                for(int i = 0; i < sArrays.Length; i++)
                {
                    int movingI = i;
                    int lastIndex = sArrays.Length - 1;
                    int movingLastIndex = lastIndex;

                    int count = 0;
                    while (movingI <= lastIndex && movingI <= movingLastIndex)
                    {
                        if (sArrays[movingI] == sArrays[movingLastIndex])
                        {
                            if (movingI != movingLastIndex) count += 2;
                            else count++;

                            movingI++;
                            movingLastIndex--;
                        }
                        else
                        {
                            count = 0;
                            movingI = i;
                            lastIndex--;
                            movingLastIndex = lastIndex;
                        }
                    }

                    if (count > longestLength)
                    {
                        longestLength = count;
                        ans = s[i..(lastIndex + 1)];
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ans;
        }
    }
}

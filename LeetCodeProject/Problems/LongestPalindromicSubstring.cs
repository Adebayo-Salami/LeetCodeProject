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

        static string LongestPalindrome(string s)
        {
            var ans = String.Empty;

            try
            {
                if (String.IsNullOrWhiteSpace(s))
                    return ans;

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

        static string OptLongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            int n = s.Length;
            bool[,] dp = new bool[n, n];
            int start = 0;
            int maxLen = 1;

            // All substrings of length 1 are palindromes
            for (int i = 0; i < n; i++)
            {
                dp[i, i] = true;
            }

            // Check for palindromes of length 2
            for (int i = 0; i < n - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    dp[i, i + 1] = true;
                    start = i;
                    maxLen = 2;
                }
            }

            // Check for palindromes of length >= 3
            for (int len = 3; len <= n; len++)
            {
                for (int i = 0; i < n - len + 1; i++)
                {
                    int j = i + len - 1;
                    if (s[i] == s[j] && dp[i + 1, j - 1])
                    {
                        dp[i, j] = true;
                        if (len > maxLen)
                        {
                            maxLen = len;
                            start = i;
                        }
                    }
                }
            }

            return s.Substring(start, maxLen);
        }
    }
}

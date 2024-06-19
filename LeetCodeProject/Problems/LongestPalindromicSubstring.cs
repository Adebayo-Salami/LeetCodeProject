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
        }

        public static string LongestPalindrome(string s)
        {
            var ans = String.Empty;

            try
            {
                StringBuilder stringBuilder = new();
                long longestLength = 0;
                var sArrays = s.ToCharArray();
                for(int i = 0; i < sArrays.Length; i++)
                {

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

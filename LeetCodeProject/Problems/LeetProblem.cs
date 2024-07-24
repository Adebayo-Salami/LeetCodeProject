using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.Problems
{
    public static class LeetProblem
    {
        public static void Run()
        {
            // s = 'aab' p = "c*a*b" - IsRegularExpressionMatch
            Console.WriteLine(" aab - c*a*b Matches: " + IsRegularExpressionMatch2("aab", "c*a*b"));
            Console.WriteLine(" mississippi - mis*is*p* Matches: " + IsRegularExpressionMatch2("mississippi", "mis*is*p*"));
            Console.WriteLine(" mississippi - mis*is*ip*. Matches: " + IsRegularExpressionMatch2("mississippi", "mis*is*ip*."));
            Console.WriteLine(" abcd - d* Matches: " + IsRegularExpressionMatch2("abcd", "d*"));
            Console.WriteLine(" aaa - aaaa Matches: " + IsRegularExpressionMatch2("aaa", "aaaa"));

            Console.WriteLine("Max Area: " + MaxArea_ContainerWithMostWater2([1, 1]));
            Console.WriteLine("Max Area: " + MaxArea_ContainerWithMostWater2([1, 8, 6, 2, 5, 4, 8, 3, 7]));
        }

        public static bool IsPalindrome(int x)
        {
            var xStr = x.ToString();
            for (int i = 0, j = xStr.Length - 1; i < j; i++, j--)
                if (xStr[i] != xStr[j])
                    return false;
            return true;
        }

        public static bool IsRegularExpressionMatch(string s, string pattern)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                if (!String.IsNullOrWhiteSpace(pattern))
                    return (pattern.Length == 1 && pattern[0] == '*');
                else
                    return true;
            }

            var sChar = s.Trim().ToCharArray();
            var patternChar = pattern.Trim().ToCharArray();

            for (int i = 0, k = 0; i < sChar.Length; i++, k++)
            {
                if (k == patternChar.Length)
                    return false;
                if (sChar[i] == patternChar[k])
                    continue;
                if (patternChar[k] == '.')
                    continue;
                if (patternChar[k] == '*' && i == (patternChar.Length - 1))
                    return true;
                else if (patternChar[k] == '*')
                    k--;

                return false;
            }

            return true;
        }

        static bool IsRegularExpressionMatch2(string s, string pattern)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                if (String.IsNullOrWhiteSpace(pattern))
                    return true;

                var unqiuePattern = pattern.ToHashSet();
                foreach (var pat in unqiuePattern)
                    if (pat != '*')
                        return false;
                return true;
            }

            if(pattern == ".*")
                return true;

            return IsRegularExpressionMatch2(s, pattern, 0, 0);
        }

        static bool IsRegularExpressionMatch2(string s, string pattern, int sIndex, int pIndex)
        {
            if (sIndex == s.Length && pIndex == pattern.Length)
                return true;

            if (sIndex >= s.Length)
            {
                if (pIndex < pattern.Length)
                    for (int i = sIndex; i < pattern.Length; i++)
                        if (pattern[i] != '*')
                            return false;

                return true;
            }

            if (sIndex == s.Length || pIndex == pattern.Length)
                return false;

            char? prevPattern = null;
            if (pattern[pIndex] == '*')
            {
                if (prevPattern == null)
                    prevPattern = pattern[pIndex - 1];
            }
            else
                prevPattern = null;

            if (s[sIndex] == pattern[pIndex] || pattern[pIndex] == '.')
                return IsRegularExpressionMatch2(s, pattern, ++sIndex, ++pIndex);

            if (pattern[pIndex] == '*' && prevPattern.HasValue && prevPattern != s[sIndex])
            {
                if(pIndex < (pattern.Length - 1) && pattern[pIndex + 1] == '.')
                    return IsRegularExpressionMatch2(s, pattern, sIndex + 2, ++pIndex);

                for (int i = pIndex; i < pattern.Length; i++)
                    if (pattern[i] == s[sIndex])
                        return IsRegularExpressionMatch2(s, pattern, ++sIndex, ++i);
                return false;
            }

            if (pattern[pIndex] == '*')
                return IsRegularExpressionMatch2(s, pattern, ++sIndex, pIndex);

            // Do another check for a wildcard *
            for (int i = pIndex; i < pattern.Length; i++)
                if (pattern[i] == '*')
                    return IsRegularExpressionMatch2(s, pattern, ++sIndex, i);

            return false;
        }

        public static bool IsRegularExpressionMatchEd(string s, string p)
        {
            if (p.Length == 0) return s.Length == 0;

            bool firstMatch = (s.Length > 0 && (p[0] == s[0] || p[0] == '.'));

            if (p.Length >= 2 && p[1] == '*')
            {
                return (IsRegularExpressionMatchEd(s, p.Substring(2)) ||
                        (firstMatch && IsRegularExpressionMatchEd(s.Substring(1), p)));
            }
            else
            {
                return firstMatch && IsRegularExpressionMatchEd(s.Substring(1), p.Substring(1));
            }
        }

        static int MaxArea_ContainerWithMostWater(int[] height)
        {
            int maxArea = 0;
            for(int i = 0; i < (height.Length - 1); i++)
            {
                for(int j = i + 1; j < height.Length; j++)
                {
                    int lowestHeight = height[i] < height[j] ? height[i] : height[j];
                    int possibleArea = (j - i) * lowestHeight;
                    if (possibleArea > maxArea)
                        maxArea = possibleArea;
                }
            }

            return maxArea;
        }

        static int MaxArea_ContainerWithMostWater2(int[] height)
        {
            int maxArea = 0;
            int left = 0;
            int right = height.Length - 1;

            while (left < right)
            {
                int width = right - left;
                int currentHeight = Math.Min(height[left], height[right]);
                int currentArea = width * currentHeight;
                maxArea = Math.Max(maxArea, currentArea);

                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxArea;
        }

        static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue; // Skip duplicate elements

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });

                        while (left < right && nums[left] == nums[left + 1]) left++; // Skip duplicates
                        while (left < right && nums[right] == nums[right - 1]) right--; // Skip duplicates

                        left++;
                        right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;
        }

        static int ThreeSumClosest(int[] nums, int target)
        {


            return -1;
        }
    }
}

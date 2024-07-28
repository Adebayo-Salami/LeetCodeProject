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
            //Console.WriteLine(" aab - c*a*b Matches: " + IsRegularExpressionMatch2("aab", "c*a*b"));
            //Console.WriteLine(" mississippi - mis*is*p* Matches: " + IsRegularExpressionMatch2("mississippi", "mis*is*p*"));
            //Console.WriteLine(" mississippi - mis*is*ip*. Matches: " + IsRegularExpressionMatch2("mississippi", "mis*is*ip*."));
            //Console.WriteLine(" abcd - d* Matches: " + IsRegularExpressionMatch2("abcd", "d*"));
            //Console.WriteLine(" aaa - aaaa Matches: " + IsRegularExpressionMatch2("aaa", "aaaa"));

            //Console.WriteLine("Max Area: " + MaxArea_ContainerWithMostWater2([1, 1]));
            //Console.WriteLine("Max Area: " + MaxArea_ContainerWithMostWater2([1, 8, 6, 2, 5, 4, 8, 3, 7]));

            //var testReverseKGroup1 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            //ReverseKGroup(testReverseKGroup1, 2);

            //ListNode[] testMergeKLists = { new ListNode(1, new ListNode(4, new ListNode(5))), new ListNode(1, new ListNode(3, new ListNode(4))), new ListNode(2, new ListNode(6)) };
            //MergeKLists(testMergeKLists);

            //ListNode[] testMergeKLists2 = { new ListNode(1, new ListNode(2, new ListNode(2))), new ListNode(1, new ListNode(1, new ListNode(2))) };
            //MergeKLists(testMergeKLists2);
            //Console.WriteLine("Indexes Found in barfoothefoobarman, [foo, bar] " + String.Join(',', FindSubstring("barfoothefoobarman", ["foo", "bar"])));
            //Console.WriteLine("Indexes Found in barfoofoobarthefoobarman, [foo, bar, the] " + String.Join(',', FindSubstring("barfoofoobarthefoobarman", ["bar", "foo", "the"])));
            Console.WriteLine("Indexes Found in wordgoodgoodgoodbestword, [word, good, best, good] | Expected [8] : Output: " + String.Join(',', FindSubstring("barfoofoobarthefoobarman", ["word", "good", "best", "good"])));
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

        static ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode x = head, y = null, result = null;
            Stack<ListNode> stack = new();
            while(x != null)
            {
                stack.Push(x);
                x = x.next;
                if (stack.Count == k)
                {
                    if (y == null)
                    {
                        y = stack.Pop();
                        result = y;
                    }

                    while (stack.Count > 0)
                    {
                        y.next = stack.Pop();
                        y = y.next;
                    }
                    y.next = x;
                }
            }

            return result ?? head;
        }

        static ListNode MergeKLists(ListNode[] lists)
        {
            PriorityQueue<ListNode, int> queue = new();
            foreach(var list in lists)
            {
                var current = list;
                while (current != null)
                {
                    queue.Enqueue(current, current.val);
                    current = current.next;
                }
            }

            if (queue.Count == 0)
                return null;

            ListNode result = new ListNode(queue.Dequeue().val);
            var current2 = result;
            while (queue.Count > 0)
            {
                current2.next = queue.Dequeue();
                current2 = current2.next;
            }
            current2.next = null;

            return result;
        }

        // https://leetcode.com/problems/substring-with-concatenation-of-all-words/
        static IList<int> FindSubstring(string s, string[] words)
        {
            Dictionary<char, List<int>> sDict = new();
            for(int i = 0; i < s.Length; i++)
            {
                if (sDict.ContainsKey(s[i]))
                    sDict[s[i]].Add(i);
                else
                    sDict.Add(s[i], [i]);
            }

            PriorityQueue<string, int> queue = new ();
            List<int> queueIndexs = new List<int>();
            Dictionary<int, string> wordHDict = new();
            foreach(var word in words)
            {
                if (sDict.ContainsKey(word[0]))
                {
                    foreach (var index in sDict[word[0]])
                    {
                        wordHDict.TryAdd(index, word);
                        queue.Enqueue(word, index);
                        queueIndexs.Add(index);
                    }
                }
            }
            queueIndexs.Sort();

            // Comparison
            int comparator = 0;
            List<int> result = new ();
            while(queue.Count > 0)
            {
                var word = queue.Dequeue();
                int wordIndex = queueIndexs[comparator];
                int wordsFound = 0;

                int currentWordIndex = wordIndex + 1;
                bool isGoodToGo = true;
                List<string> wordsChecked = [word];
                for(int i = 1; i < word.Length; i++)
                {
                    if (sDict.ContainsKey(word[i]))
                    {
                        if (sDict[word[i]].Contains(currentWordIndex))
                            currentWordIndex++;
                        else
                        {
                            isGoodToGo = false;
                            break;
                        }
                    }
                    else
                    {
                        isGoodToGo = false;
                        break;
                    }
                }
                if (isGoodToGo)
                    wordsFound++;

                while(wordsFound != words.Length && isGoodToGo)
                {
                    var nextWordAvailable = wordHDict.Any(x => x.Key == currentWordIndex && !wordsChecked.Contains(x.Value));
                    if (!nextWordAvailable)
                        break;

                    var nextWord = wordHDict.First(x => x.Key == currentWordIndex && !wordsChecked.Contains(x.Value));
                    word = nextWord.Value;
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (sDict.ContainsKey(word[i]))
                        {
                            if (sDict[word[i]].Contains(currentWordIndex))
                                currentWordIndex++;
                            else
                            {
                                isGoodToGo = false;
                                break;
                            }
                        }
                        else
                        {
                            isGoodToGo = false;
                            break;
                        }
                    }
                    if (isGoodToGo)
                        wordsFound++;
                    else
                        break;
                    wordsChecked.Add(word);
                }


                if (wordsFound == words.Length)
                    result.Add(wordIndex);
                comparator++;
            }


            return result;
        }
    }
}

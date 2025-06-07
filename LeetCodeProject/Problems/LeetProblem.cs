using System.Text;

namespace LeetCodeProject.Problems
{
    public static class LeetProblem
    {
        public static void Run()
        {
            FindSubstring4("lingmindraboofooowingdingbarrwingmonkeypoundcake", ["fooo", "barr", "wing", "ding", "wing"]); // Expected [13]
        }

        static IList<int> FindSubstring4(string s, string[] words)
        {
            int wordLength = words[0].Length;
            int stringLength = wordLength * words.Length;
            if (s.Length < stringLength)
                return [];

            Dictionary<string, List<int>> availableChecks = new();
            for (int i = 0; i < words.Length; i++)
            {
                if (!availableChecks.TryAdd(words[i], [i]))
                    availableChecks[words[i]].Add(i);
            }

            List<int> resultIndexes = new();
            for (int i = 0; i <= s.Length - stringLength; i += wordLength)
            {
                Dictionary<string, List<int>> checks = new();
                foreach (var availabeCheck in availableChecks)
                    checks.Add(availabeCheck.Key, [..availabeCheck.Value]);

                int stringFormedLength = 0, j = i, tries = wordLength;
                while(tries > 0)
                {
                    string word = s.Substring(j, wordLength);
                    if (checks.ContainsKey(word))
                    {
                        var popped = checks[word].First();
                        checks[word].Remove(popped);
                        if (checks[word].Count == 0)
                            checks.Remove(word);
                    }
                    else
                        break;

                    stringFormedLength += wordLength;
                    j += wordLength;
                    tries--;
                }

                if (stringFormedLength == stringLength)
                    resultIndexes.Add(i);
            }

            return resultIndexes;
        }

        static IList<int> FindSubstring3(string s, string[] words)
        {
            int wordLength = words[0].Length;
            if (s.Length < wordLength)
                return [];

            HashSet<string> possibleCobinations = new();
            for(int i = 0; i < words.Length; i++)   // Capture Forward Sequences
            {
                StringBuilder stringBuilder = new();
                stringBuilder.Append(words[i]);
                int j = i + 1;
                if (j == words.Length) j = 0;
                while (j != i)
                {
                    stringBuilder.Append(words[j++]);

                    if (j == words.Length) j = 0;
                }
                possibleCobinations.Add(stringBuilder.ToString());
            }

            for (int i = words.Length - 1; i >= 0; i--)   // Capture Backward Sequences
            {
                StringBuilder stringBuilder = new();
                stringBuilder.Append(words[i]);
                int j = i - 1;
                if (j < 0) j = words.Length - 1;
                while (j != i)
                {
                    stringBuilder.Append(words[j--]);

                    if (j < 0) j = words.Length - 1;
                }
                possibleCobinations.Add(stringBuilder.ToString());
            }

            List<int> resultIndexes = new();
            int stringLength = wordLength * words.Length;
            for(int i = 0; i <= s.Length - stringLength; i += wordLength)
            {
                if (possibleCobinations.Contains(s.Substring(i, stringLength)))
                    resultIndexes.Add(i);
            }

            return resultIndexes;
        }

        static int Divide(int dividend, int divisor)
        {
            // Special overflow case
            if (dividend == int.MinValue && divisor == -1)
                return int.MaxValue;

            int divideCount = 0;
            bool isNegativeDivisor = divisor < 0;
            bool isNegativeDivident = dividend < 0;

            dividend = Math.Abs(dividend);
            divisor = Math.Abs(divisor);
            for (int i = divisor; i <= dividend; i += divisor)
                divideCount++;

            if (isNegativeDivident || isNegativeDivisor)
                divideCount = -divideCount;
            if (isNegativeDivisor && isNegativeDivident)
                divideCount = Math.Abs(divideCount);

            return divideCount;
        }

        static int Divide_Checker(int dividend, int divisor)
        {
            // Special overflow case
            if (dividend == int.MinValue && divisor == -1)
                return int.MaxValue;

            int divideCount = 0;
            bool isNegative = (dividend < 0) ^ (divisor < 0); // XOR: true if signs differ

            long ldividend = Math.Abs((long)dividend);
            long ldivisor = Math.Abs((long)divisor);

            while (ldividend >= ldivisor)
            {
                long temp = ldivisor, multiple = 1;

                while (ldividend >= (temp << 1))
                {
                    temp <<= 1;
                    multiple <<= 1;
                }

                ldividend -= temp;
                divideCount += (int)multiple;
            }

            return isNegative ? -divideCount : divideCount;
        }

        static ListNode SwapPairs(ListNode head)
        {
            ListNode result = null;
            if (head == null) return result;

            ListNode c = head, n = head.next, cs = head.next?.next;
            if (n == null) return head;
            var temp = c;
            c = n;
            c.next = temp;
            result = c;
           
            var p = result.next;
            p.next = null;
            c = cs;
            n = c?.next;
            cs = n?.next;
            while (n != null)
            {
                cs = n?.next;
                var temp2 = c;
                c = n;
                c.next = temp2;
                p.next = c;
                p = p.next.next;
                p.next = null;

                c = cs;
                n = c?.next;
            }

            if (c != null)
                p.next = c;

            return result;
        }

        static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int size = 1;
            if (head.next == null && n == 1)
                return null;

            ListNode? current = head, previous = null, difference = null;
            if (size == n) difference = head;

            while (current.next != null)
            {
                size++;
                if (size == n)
                {
                    difference = head;
                }
                else if(difference != null)
                {
                    previous = difference;
                    difference = difference.next;
                }

                current = current.next;
            }

            if(difference != null)
            {
                if (previous == null)
                    return difference.next;
                else
                    previous.next = difference.next;
            }

            return head;
        }

        static void PreviousTestParameters()
        {
            Console.WriteLine("Letter Combination of 23 is " + String.Join(',', LetterCombinations2("23")));
            Console.WriteLine("Letter Combination of 23 is " + String.Join(',', LetterCombinations2("")));
            Console.WriteLine("Letter Combination of 23 is " + String.Join(',', LetterCombinations2("2")));
            Console.WriteLine("Letter Combination of 23 is " + String.Join(',', LetterCombinations2("234")));
            Console.WriteLine(String.Join(',', ["adg", "adh", "adi", "aeg", "aeh", "aei", "afg", "afh", "afi", "bdg", "bdh", "bdi", "beg", "beh", "bei", "bfg", "bfh", "bfi", "cdg", "cdh", "cdi", "ceg", "ceh", "cei", "cfg", "cfh", "cfi"]));
            Console.WriteLine("Value of III is " + RomanToInt("III"));
            Console.WriteLine("Value of LVIII is " + RomanToInt("LVIII"));
            Console.WriteLine("Value of MCMXCIV is " + RomanToInt("MCMXCIV"));
            Console.WriteLine("Value of LLL is " + RomanToInt("LLL"));
            LengthOfLongestSubstring("dvdf");
            SetZeroes([[1, 1, 1], [1, 0, 1], [1, 1, 1]]);
            ReverseList2(new ListNode() { val = 1, next = new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))) });
            Insert([[1, 5]], [0, 3]);
            CanFinish(2, [[0, 10], [3, 18], [5, 5], [6, 11], [11, 14], [13, 1], [15, 1], [17, 4]]);
            Console.WriteLine("Ways of Climbing Stairs: 44 - " + ClimbStairs3(4));
            Console.WriteLine("Max Capacity Value of [1,8,6,2,5,4,8,3,7]: " + MaxArea([1, 8, 6, 2, 5, 4, 8, 3, 7]));
            Console.WriteLine(" aab - c*a*b Matches: " + IsRegularExpressionMatch2("aab", "c*a*b"));
            Console.WriteLine(" mississippi - mis*is*p* Matches: " + IsRegularExpressionMatch2("mississippi", "mis*is*p*"));
            Console.WriteLine(" mississippi - mis*is*ip*. Matches: " + IsRegularExpressionMatch2("mississippi", "mis*is*ip*."));
            Console.WriteLine(" abcd - d* Matches: " + IsRegularExpressionMatch2("abcd", "d*"));
            Console.WriteLine(" aaa - aaaa Matches: " + IsRegularExpressionMatch2("aaa", "aaaa"));
            Console.WriteLine("Max Area: " + MaxArea_ContainerWithMostWater2([1, 1]));
            Console.WriteLine("Max Area: " + MaxArea_ContainerWithMostWater2([1, 8, 6, 2, 5, 4, 8, 3, 7]));
            var testReverseKGroup1 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
            ReverseKGroup(testReverseKGroup1, 2);
            ListNode[] testMergeKLists = { new ListNode(1, new ListNode(4, new ListNode(5))), new ListNode(1, new ListNode(3, new ListNode(4))), new ListNode(2, new ListNode(6)) };
            MergeKLists(testMergeKLists);
            ListNode[] testMergeKLists2 = { new ListNode(1, new ListNode(2, new ListNode(2))), new ListNode(1, new ListNode(1, new ListNode(2))) };
            MergeKLists(testMergeKLists2);
            Console.WriteLine("Indexes Found in barfoothefoobarman, [foo, bar] " + String.Join(',', FindSubstring("barfoothefoobarman", ["foo", "bar"])));
            Console.WriteLine("Indexes Found in barfoofoobarthefoobarman, [foo, bar, the] " + String.Join(',', FindSubstring("barfoofoobarthefoobarman", ["bar", "foo", "the"])));
            Console.WriteLine("Indexes Found in wordgoodgoodgoodbestword, [word, good, best, good] | Expected [8] : Output: " + String.Join(',', FindSubstring("wordgoodgoodgoodbestword", ["word", "good", "best", "good"])));
            Console.WriteLine("Indexes Found in bccbcc, [bc, cc, cb] | Expected [8] : Output: " + String.Join(',', FindSubstring("bccbcc", ["bc", "cc", "cb"])));
            Console.WriteLine("Longest Valid Parentheses in ()(() is " + LongestValidParentheses("()(()"));
            Console.WriteLine("Trapped Water [0,1,0,2,1,0,1,3,2,1,2,1] is " + Trap([0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]));
            GenerateParenthesis(3);
            Console.WriteLine("Is Wildcard Match s =  | p = ****** : " + IsWildcardMatch("", "******"));
            Console.Write("ThreeSumClosest: [-1,2,1,-4], target = 1" + ThreeSumClosest([-1, 2, 1, -4], 1));
            Console.Write("ContainsNearbyAlmostDuplicate: [1, 2, 3, 1], 3, 0" + ContainsNearbyAlmostDuplicate([1, 2, 3, 1], 3, 0));
            Console.WriteLine(MaxEnvelopes([[1, 2], [2, 3], [3, 4], [4, 5], [5, 6], [5, 5], [6, 7], [7, 8]]));
            Console.WriteLine("Two Sum {2,7,11,15} 9 " + TwoSum([2, 7, 11, 15], 9));
            Console.WriteLine("Product of [1,2,3,4]: " + String.Join(',', ProductExceptSelf([1, 2, 3, 4])));
            Console.WriteLine("Max Value of [-2,1,-3,4,-1,2,1,-5,4]: " + MaxSubArray([-2, 1, -3, 4, -1, 2, 1, -5, 4]));
            Console.WriteLine("Max Product Value of [2,-5,-2,-4,3]: " + MaxProduct([2, -5, -2, -4, 3]));
            Console.WriteLine("Max FindMin Value of [3,1,2]: " + FindMin([3, 1, 2]));
            Console.WriteLine("Max Search Value of 1 in [8,1,2,3,4,5,6,7]: " + Search([8, 1, 2, 3, 4, 5, 6, 7], 6));
            var nodeA = new Node(1);
            var nodeB = new Node(2);
            var nodeC = new Node(3);
            var nodeD = new Node(4);
            nodeA.neighbors.Add(nodeB);
            nodeA.neighbors.Add(nodeC);
            nodeA.neighbors.Add(nodeD);
            nodeB.neighbors.Add(nodeA);
            nodeB.neighbors.Add(nodeC);
            nodeB.neighbors.Add(nodeD);
            nodeC.neighbors.Add(nodeA);
            nodeC.neighbors.Add(nodeB);
            nodeC.neighbors.Add(nodeD);
            nodeD.neighbors.Add(nodeA);
            nodeD.neighbors.Add(nodeB);
            nodeD.neighbors.Add(nodeC);
            var cloning = CloneGraph(nodeA);
            {
                var treeNode = new TreeNode(3);
                treeNode.left = new TreeNode(9);
                treeNode.right = new TreeNode(20);
                treeNode.right.left = new TreeNode(15);
                treeNode.right.right = new TreeNode(7);
                MaxDepth(treeNode);
            }
        }

        static IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            var result = new List<IList<int>>();

            for(int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && (nums[i] == nums[i - 1])) continue;

                for(int j = i + 1; j < nums.Length - 2; j++)
                {
                    if (j > (i + 1) && (nums[j] == nums[j - 1])) continue;

                    int left = j + 1;
                    int right = nums.Length - 1;

                    while(left < right)
                    {
                        //var sum = nums[i] + nums[j] + nums[left] + nums[right];
                        long sum = (long)nums[i] + nums[j] + nums[left] + nums[right]; // use long to prevent overflow

                        if (sum < target)
                        {
                            left++;
                        }
                        else if(sum > target)
                        {
                            right--;
                        }
                        else
                        {
                            result.Add([nums[i], nums[j], nums[left], nums[right]]);

                            while (left < right && (nums[left] == nums[left + 1])) left++;
                            while (left < right && (nums[right] == nums[right - 1])) right--;

                            left++;
                            right--;
                        }
                    }
                }
            }

            return result;
        }

        static IList<string> LetterCombinations2(string digits)
        {
            List<string> result = [];

            if (!String.IsNullOrWhiteSpace(digits))
            {
                Queue<int> priorityQueue = new();
                for (int i = 0; i < digits.Length; i++)
                {
                    int val = Convert.ToInt32(digits[i]) - 48;
                    priorityQueue.Enqueue(val);
                }

                var arrayStore = new int[digits.Length];
                int location = 0;
                while (priorityQueue.Count > 0)
                    arrayStore[location++] = priorityQueue.Dequeue();
                priorityQueue = null;

                if (arrayStore.Length == 1)
                    result = GetNumberCombinations(arrayStore[0]).Select(x => x.ToString()).ToList();
                else
                {
                    var startingChars = GetNumberCombinations(arrayStore[0]);
                    foreach (char ch in startingChars)
                        FindCombinationsRecursively2(ch.ToString(), arrayStore, 1, result);
                }
            }

            return result;
        }

        static char[] GetNumberCombinations(int digit)
        {
            if (digit == 2) return ['a', 'b', 'c'];
            if (digit == 3) return ['d', 'e', 'f'];
            if (digit == 4) return ['g', 'h', 'i'];
            if (digit == 5) return ['j', 'k', 'l'];
            if (digit == 6) return ['m', 'n', 'o'];
            if (digit == 7) return ['p', 'q', 'r', 's'];
            if (digit == 8) return ['t', 'u', 'v'];
            if (digit == 9) return ['w', 'x', 'y', 'z'];
            else return [];
        }

        static List<string> FindCombinationsRecursively2(string currentCombo, int[] store, int location, List<string> endResults)
        {
            if (location == store.Length)
                return [];

            var results = new List<string>();
            var startingChars = GetNumberCombinations(store[location]);
            foreach (var ch in startingChars)
            {
                results.Add(currentCombo + ch);
                if (FindCombinationsRecursively2(currentCombo + ch, store, location + 1, endResults).Count == 0)
                    endResults.Add(currentCombo + ch);
            }

            return results;
        }

        static List<string> FindCombinationsRecursively(string currentCombo, int[] store, int location)
        {
            if (location == store.Length)
                return [];

            var results = new List<string>();
            var startingChars = GetNumberCombinations(store[location]);
            foreach(var ch in startingChars)
            {
                results.Add(currentCombo + ch);
                results.AddRange(FindCombinationsRecursively(currentCombo + ch, store, location + 1));
            }

            return results;
        }

        static IList<string> LetterCombinations(string digits)
        {
            List<string> result = [];

            if (!String.IsNullOrWhiteSpace(digits))
            {
                PriorityQueue<int, int> priorityQueue = new();
                for (int i = 0; i < digits.Length; i++)
                    priorityQueue.Enqueue(digits[i], digits[i]);

                var arrayStore = new int[digits.Length];
                int location = 0;
                while (priorityQueue.Count > 0)
                    arrayStore[location++] = priorityQueue.Dequeue();
                priorityQueue = null;

                for(int i = 0; i < arrayStore.Length; i++)
                {
                    char[] iValues = [];
                    if (arrayStore[i] == 2) iValues = ['a', 'b', 'c'];
                    if (arrayStore[i] == 3) iValues = ['d', 'e', 'f'];
                    if (arrayStore[i] == 4) iValues = ['g', 'h', 'i'];
                    if (arrayStore[i] == 5) iValues = ['j', 'k', 'l'];
                    if (arrayStore[i] == 6) iValues = ['m', 'n', 'o'];
                    if (arrayStore[i] == 7) iValues = ['p', 'q', 'r', 's'];
                    if (arrayStore[i] == 8) iValues = ['t', 'u', 'v'];
                    if (arrayStore[i] == 9) iValues = ['w', 'x', 'y', 'z'];

                    int j = i + 1;
                    if (arrayStore.Length == 1)
                        result = iValues.Select(x => x.ToString()).ToList();
                    else 
                    {
                        while (j < arrayStore.Length)
                        {
                            char[] jValues = [];
                        }
                    }
                }
            }

            return result;
        }

        static int RomanToInt(string s)
        {
            int result = 0;
            int? previousWordValue = null;
            for(int i = 0; i < s.Length; i++)
            {
                int wordValue = 0;
                switch (s[i])
                {
                    case 'I':
                        wordValue = 1;
                        break;
                    case 'V':
                        wordValue = 5;
                        break;
                    case 'X':
                        wordValue = 10;
                        break;
                    case 'L':
                        wordValue = 50;
                        break;
                    case 'C':
                        wordValue = 100;
                        break;
                    case 'D':
                        wordValue = 500;
                        break;
                    case 'M':
                        wordValue = 1000;
                        break;
                    default:
                        break;
                }

                if (previousWordValue != null)
                {
                    if (previousWordValue.Value < wordValue)
                        result += ((wordValue - previousWordValue.Value) - previousWordValue.Value);
                    else
                        result += wordValue;
                }
                else
                    result += wordValue;

                previousWordValue = wordValue;
            }
            return result;
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

            if (pattern == ".*")
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
                if (pIndex < (pattern.Length - 1) && pattern[pIndex + 1] == '.')
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
            for (int i = 0; i < (height.Length - 1); i++)
            {
                for (int j = i + 1; j < height.Length; j++)
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

        static ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode x = head, y = null, result = null;
            Stack<ListNode> stack = new();
            while (x != null)
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
            foreach (var list in lists)
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
            for (int i = 0; i < s.Length; i++)
            {
                if (sDict.ContainsKey(s[i]))
                    sDict[s[i]].Add(i);
                else
                    sDict.Add(s[i], [i]);
            }

            PriorityQueue<string, int> queue = new();
            List<int> queueIndexs = new List<int>();
            Dictionary<int, string> wordHDict = new();
            Dictionary<string, int> wordDuplicatesCount = new();
            foreach (var word in words)
            {
                if (wordDuplicatesCount.ContainsKey(word))
                    wordDuplicatesCount[word]++;
                else
                    wordDuplicatesCount.Add(word, 0);

                if (sDict.ContainsKey(word[0]))
                {
                    foreach (var index in sDict[word[0]])
                    {
                        if (!wordHDict.TryAdd(index, word))
                        {
                            // Resolve Conflict
                            //if (s.Length > (index + 1))
                            //    if (s[index + 1] == word[1])
                            //        wordHDict[index] = word;
                        }
                        queue.Enqueue(word, index);
                        queueIndexs.Add(index);
                    }
                }
            }
            queueIndexs.Sort();

            // Comparison
            int comparator = 0;
            HashSet<int> result = new();
            while (queue.Count > 0)
            {
                var word = queue.Dequeue();
                int wordIndex = queueIndexs[comparator];
                int wordsFound = 0;
                Dictionary<string, int> wordDuplicatesCountCopy = new();
                foreach (var item in wordDuplicatesCount)
                    wordDuplicatesCountCopy.Add(item.Key, item.Value);

                int currentWordIndex = wordIndex + 1;
                bool isGoodToGo = true;
                List<string> wordsChecked = [word];
                for (int i = 1; i < word.Length; i++)
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

                while (wordsFound != words.Length && isGoodToGo)
                {
                    var nextWordAvailable = wordHDict.Any(x => x.Key == currentWordIndex);
                    if (!nextWordAvailable)
                        break;

                    var nextWord = wordHDict.First(x => x.Key == currentWordIndex);
                    if (wordsChecked.Contains(nextWord.Value))
                    {
                        if (wordDuplicatesCountCopy[nextWord.Value] == 0)
                            break;
                        else
                            wordDuplicatesCountCopy[nextWord.Value]--;
                    }

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


            return result.ToList();
        }

        static IList<int> FindSubstring2(string s, string[] words)
        {
            var result = new List<int>();
            if (s == null || words == null || words.Length == 0) return result;

            int wordLength = words[0].Length;
            int totalWordsLength = wordLength * words.Length;
            var wordCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            for (int i = 0; i <= s.Length - totalWordsLength; i++)
            {
                var seenWords = new Dictionary<string, int>();
                int j = 0;
                while (j < words.Length)
                {
                    string word = s.Substring(i + j * wordLength, wordLength);
                    if (wordCount.ContainsKey(word))
                    {
                        if (seenWords.ContainsKey(word))
                        {
                            seenWords[word]++;
                        }
                        else
                        {
                            seenWords[word] = 1;
                        }
                        if (seenWords[word] > wordCount[word]) break;
                    }
                    else
                    {
                        break;
                    }
                    j++;
                }
                if (j == words.Length) result.Add(i);
            }

            return result;
        }

        static int LongestValidParentheses(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
                return 0;
            if (s.Length == 1)
                return 0;

            int validityCount = 0;
            int middleIndex = s.Length / 2;
            Stack<char> leftStack = new();
            Stack<char> rightStack = new();
            for (int i = middleIndex, ii = middleIndex - 1, j = middleIndex + 1, jj = middleIndex + 2; ;)
            {
                if ((i >= 0 && j < s.Length) && s[i] == '(' && s[j] == ')')
                {
                    i--;
                    j++;
                    ii--;
                    jj++;
                    validityCount++;
                }
                else
                {
                    if (ii >= 0)
                    {
                        if (s[ii] == '(' && s[i] == ')')
                        {
                            i = --ii;
                            ii--;
                            validityCount++;
                        }
                        else
                        {
                            if (leftStack.Count > 0)
                            {
                                char lastItem = leftStack.Pop();
                                if (s[i] == '(' && lastItem == ')')
                                {
                                    validityCount++;
                                    continue;
                                }
                                leftStack.Push(lastItem);
                            }

                            if (rightStack.Count > 0)
                            {
                                char lastItem = rightStack.Pop();
                                if (s[i] == '(' && lastItem == ')')
                                {
                                    validityCount++;
                                    continue;
                                }
                                rightStack.Push(lastItem);
                            }

                            leftStack.Push(s[i]);
                            i--;
                            ii--;
                        }
                    }

                    if (jj < s.Length)
                    {
                        if (s[j] == '(' && s[jj] == ')')
                        {
                            j = ++jj;
                            jj++;
                            validityCount++;
                        }
                        else
                        {
                            if (rightStack.Count > 0)
                            {
                                char lastItem = rightStack.Pop();
                                if (lastItem == '(' && s[j] == ')')
                                {
                                    validityCount++;
                                    continue;
                                }
                                rightStack.Push(lastItem);
                            }

                            if (leftStack.Count > 0)
                            {
                                char lastItem = leftStack.Pop();
                                if (lastItem == '(' && s[j] == ')')
                                {
                                    validityCount++;
                                    continue;
                                }
                                leftStack.Push(lastItem);
                            }

                            rightStack.Push(s[j]);
                            j++;
                            jj++;
                        }
                    }

                    if (i >= 0 && ii < 0)
                        leftStack.Push(s[i]);
                    if (j < s.Length && jj >= s.Length)
                        rightStack.Push(s[j]);

                    if (ii < 0)
                        i--;

                    if (jj >= s.Length)
                        j++;
                }

                if (i < 0 && j >= s.Length)
                    break;
            }

            return validityCount * 2;
        }

        static int LongestValidParentheses2(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            int maxLength = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        maxLength = Math.Max(maxLength, i - stack.Peek());
                    }
                }
            }

            return maxLength;
        }

        static int Trap(int[] height)
        {
            if (height.Length <= 1)
                return 0;

            int left = 0, leftMax = 0, right = height.Length - 1, rightMax = 0;
            int trappedWater = 0;
            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] > leftMax)
                        leftMax = height[left];
                    else
                        trappedWater += (leftMax - height[left]);

                    left++;
                }
                else
                {
                    if (height[right] > rightMax)
                        rightMax = height[right];
                    else
                        trappedWater += (rightMax - height[right]);

                    right--;
                }
            }

            return trappedWater;
        }

        static IList<string> GenerateParenthesis(int n)
        {
            if (n <= 0)
                return [];

            var list = new List<string>();
            GenerateParenthesisList(list, "", 0, 0, n);
            return list;
        }

        static void GenerateParenthesisList(List<string> list, string word, int open, int close, int max)
        {
            if (word.Length == max * 2)
            {
                list.Add(word);
                return;
            }

            if (open < max)
            {
                GenerateParenthesisList(list, word + "(", open + 1, close, max);
            }
            else if (close < open)
            {
                GenerateParenthesisList(list, word + ")", open, close + 1, max);
            }
        }

        static bool IsWildcardMatch(string s, string p)
        {
            if (p.Length == 0 && s.Length == 0)
                return true;
            if (s.Length == 0 && p == "*")
                return true;
            if (p.Length == 0)
                return false;
            if (s.Length == 0)
            {
                for (int i = 0; i < p.Length; i++)
                    if (p[i] != '*')
                        return false;

                return true;
            }
            if (p.Length == 1 && p == "*")
                return true;
            return IsWildCardMatching(s, p, 0, 0);
        }

        static bool IsWildCardMatching(string s, string p, int sIndex, int pIndex, bool isWild = false)
        {
            if (sIndex == s.Length && !isWild && pIndex != p.Length)
                return false;
            if (sIndex == s.Length)
                return true;
            if (sIndex + 1 == s.Length && isWild && pIndex == p.Length)
                return true;
            if (pIndex == p.Length && isWild)
            {
                if (sIndex + 1 == s.Length)
                    return true;
                else
                    pIndex--;
            }
            if (pIndex == p.Length)
                return false;

            if (p[pIndex] == '?')
                return IsWildCardMatching(s, p, ++sIndex, ++pIndex);
            if (p[pIndex] == '*')
                return IsWildCardMatching(s, p, sIndex, ++pIndex, true);

            if (s[sIndex] == p[pIndex])
                return IsWildCardMatching(s, p, ++sIndex, ++pIndex);

            if (isWild)
                return IsWildCardMatching(s, p, ++sIndex, pIndex, true);

            return false;
        }

        static bool IsWildCardMatched(string s, string p)
        {
            int sLen = s.Length, pLen = p.Length;
            bool[,] dp = new bool[sLen + 1, pLen + 1];
            dp[0, 0] = true;

            for (int j = 1; j <= pLen; j++)
            {
                if (p[j - 1] == '*')
                {
                    dp[0, j] = dp[0, j - 1];
                }
            }

            for (int i = 1; i <= sLen; i++)
            {
                for (int j = 1; j <= pLen; j++)
                {
                    if (p[j - 1] == '*')
                    {
                        dp[i, j] = dp[i - 1, j] || dp[i, j - 1];
                    }
                    else if (p[j - 1] == '?' || s[i - 1] == p[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                }
            }

            return dp[sLen, pLen];
        }

        static int ThreeSumClosest(int[] nums, int target)
        {
            Array.Sort(nums);
            int left = 0, middle = nums.Length / 2, right = nums.Length - 1;
            int closestSum = 0;
            while (left < right && middle > left && middle < right)
            {
                closestSum = nums[left] + nums[middle] + nums[right];
                if (closestSum < target)
                    left++;
                else if (closestSum == target)
                    return target;
                else if (closestSum > target)
                    right--;

                middle = ((right - left) / 2) + left;
            }

            return closestSum;
        }

        static int ThreeSumClosest2(int[] nums, int target)
        {
            Array.Sort(nums);
            int closestSum = nums[0] + nums[1] + nums[2];

            for (int i = 0; i < nums.Length - 2; i++)
            {
                int left = i + 1, right = nums.Length - 1;

                while (left < right)
                {
                    int currentSum = nums[i] + nums[left] + nums[right];

                    if (Math.Abs(currentSum - target) < Math.Abs(closestSum - target))
                    {
                        closestSum = currentSum;
                    }

                    if (currentSum < target)
                    {
                        left++;
                    }
                    else if (currentSum > target)
                    {
                        right--;
                    }
                    else
                    {
                        return currentSum; // Exact match
                    }
                }
            }

            return closestSum;
        }

        static bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
        {
            if (nums == null || nums.Length < 2) return false;

            SortedSet<long> set = new SortedSet<long>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > indexDiff)
                {
                    set.Remove(nums[i - indexDiff - 1]);
                }

                long num = (long)nums[i];

                if (set.GetViewBetween(num - valueDiff, num + valueDiff).Count > 0)
                {
                    return true;
                }

                set.Add(num);
            }

            return false;
        }

        static int MaxEnvelopes(int[][] envelopes)
        {
            if (envelopes == null || envelopes.Length == 0) return 0;

            // Sort envelopes: first by width in ascending order, then by height in descending order
            Array.Sort(envelopes, (a, b) =>
            {
                if (a[0] == b[0]) return b[1] - a[1];
                return a[0] - b[0];
            });

            // Extract the heights and find the longest increasing subsequence
            int[] heights = new int[envelopes.Length];
            for (int i = 0; i < envelopes.Length; i++)
            {
                heights[i] = envelopes[i][1];
            }

            return LengthOfLIS(heights);
        }

        static int LengthOfLIS(int[] nums)
        {
            List<int> lis = new List<int>();
            foreach (int num in nums)
            {
                int pos = lis.BinarySearch(num);
                if (pos < 0) pos = ~pos;
                if (pos < lis.Count)
                {
                    lis[pos] = num;
                }
                else
                {
                    lis.Add(num);
                }
            }
            return lis.Count;
        }

        static int[] TwoSum(int[] numbers, int k)
        {
            if (numbers.Length == 0)
                return [];

            Dictionary<int, int> numbersIndexing = new();
            for (int i = 0; i < numbers.Length; i++)
            {
                var pairNo = k - numbers[i];
                if (numbersIndexing.ContainsValue(pairNo))
                {
                    var pairIndex = numbersIndexing.First(x => x.Value == pairNo);
                    return [pairIndex.Key, i];
                }
                numbersIndexing.Add(i, numbers[i]);
            }

            return [];
        }

        static int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;

            int minPrice = int.MaxValue;
            int maxProfit = 0;

            foreach (int price in prices)
            {
                if (price < minPrice)
                {
                    minPrice = price;
                }
                else if (price - minPrice > maxProfit)
                {
                    maxProfit = price - minPrice;
                }
            }

            return maxProfit;
        }

        static bool ContainsDuplicate(int[] nums)
        {
            if (nums.Length == 0) return false;

            Dictionary<int, int> distinct = new();
            for (int i = 0; i < nums.Length; i++)
                if (!distinct.TryAdd(nums[i], i))
                    return true;

            return false;
        }

        static int[] ProductExceptSelf(int[] nums)
        {
            if (nums.Length == 0)
                return [];

            int[] ascendingMultiplication = new int[nums.Length];
            int[] descendingMultiplication = new int[nums.Length];
            int ascVal = 0, descVal = 0;
            for(int i = 0, j = nums.Length -1; i < nums.Length; i++, j--)
            {
                if(i == 0)
                {
                    ascVal = nums[i];
                    ascendingMultiplication[i] = ascVal;
                }
                else
                {
                    ascVal *= nums[i];
                    ascendingMultiplication[i] = ascVal;
                }

                if(j == nums.Length - 1)
                {
                    descVal = nums[j];
                    descendingMultiplication[j] = descVal;
                }
                else
                {
                    descVal *= nums[j];
                    descendingMultiplication[j] = descVal;
                }
            }

            int[] resultingArray = new int[nums.Length];
            resultingArray[0] = descendingMultiplication[1];
            resultingArray[resultingArray.Length - 1] = ascendingMultiplication[ascendingMultiplication.Length - 2];
            for(int i = 1; i <= (nums.Length - 2); i++)
            {
                resultingArray[i] = ascendingMultiplication[i - 1] * descendingMultiplication[i + 1];
            }

            return resultingArray;
        }

        static int MaxSubArray(int[] nums)
        {
            int maxSoFar = nums[0];
            int maxEndingHere = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                maxEndingHere = Math.Max(nums[i], maxEndingHere + nums[i]);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;
        }

        static int MaxProduct(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int maxProduct = nums[0];
            int minProduct = nums[0];
            int result = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    // Swap maxProduct and minProduct when encountering a negative number
                    int temp = maxProduct;
                    maxProduct = minProduct;
                    minProduct = temp;
                }

                maxProduct = Math.Max(nums[i], maxProduct * nums[i]);
                minProduct = Math.Min(nums[i], minProduct * nums[i]);

                result = Math.Max(result, maxProduct);
            }

            return result;
        }

        static int FindMin(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            if (nums.Length == 2)
                return nums[0] < nums[1] ? nums[0] : nums[1];

            int left = 0, right = nums.Length - 1;
            int middle = nums.Length / 2;
            while (left < right)
            {
                if (nums[middle] > nums[right])
                {
                    left = middle;
                    middle = ((right - left) / 2) + left;
                }
                else
                {
                    right = middle;
                    middle = ((right + left) / 2);
                }

                if ((left + 1) == right || left == right)
                    return nums[left] < nums[right] ? nums[left] : nums[right];
            }

            return -1;
        }

        static int Search(int[] nums, int target)
        {
            int left = 0, right = nums.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (nums[mid] == target)
                {
                    return mid;
                }

                // Check if the left half is sorted
                if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }

            return -1;
        }

        static IList<IList<int>> ThreeSumTT(int[] nums)
        {
            if (nums.Length < 3)
                return [];

            Array.Sort(nums);
            
            List<IList<int>> result = new();
            for(int i = 0; i < nums.Length; i++)
            {
                int left = i + 1, right = nums.Length - 1;
                while (left < right)
                {
                    int lumSum = nums[left] + nums[i] + nums[right];
                    if (lumSum == 0)
                    {
                        result.Add(new List<int>() { nums[left], nums[i], nums[right] });
                        while (left < right && nums[left + 1] == nums[left]) left++;
                        while (left < right && nums[right - 1] == nums[right]) right--;
                        left++;
                        right--;
                    }
                    else if (lumSum < 0)
                        left++;
                    else
                        right--;
                }
                while (i < nums.Length && nums[i] == nums[i + 1]) i++;
                if (i + 1 == (nums.Length - 1) && nums[i] == nums[i + 1]) break;
            }

            return result;
        }

        static int MaxArea(int[] height)
        {
            int left = 0, maxCapacity = 0, right = height.Length - 1;
            while(left < right)
            {
                int capacity = (Math.Min(height[left], height[right])) * (right - left);
                if (capacity > maxCapacity)
                    maxCapacity = capacity;

                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }

            return maxCapacity;
        }

        static int GetSum(int a, int b)
        {
            while (b != 0)
            {
                int carry = a & b; // Calculate carry
                a = a ^ b; // Sum without carry
                b = carry << 1; // Shift carry to the left
            }
            return a;
        }

        static int ClimbStairs(int n)
        {
            return ClimbStairsRecursively(n, 0);
        }

        static int ClimbStairsRecursively(int n, int ways)
        {
            if (n == 0)
                return ++ways;
            if (n < 0)
                return ways;

            ways = ClimbStairsRecursively(n - 1, ways);
            ways = ClimbStairsRecursively(n - 2, ways);

            return ways;
        }

        static int ClimbStairs2(int n)
        {

            int prev = 1;
            int curr = 1;
            for (int i = 1; i < n; i++)
            {
                int temp = curr;
                curr += prev;
                prev = temp;
            }
            return curr;
        }

        static int ClimbStairs3(int n)
        {
            if (n <= 1) return 1;

            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }

        static Node CloneGraph(Node node)
        {
            if (node == null) return null;

            Dictionary<Node, Node> map = new Dictionary<Node, Node>();
            return CloneNode(node, map);
        }

        static Node CloneNode(Node node, Dictionary<Node, Node> map)
        {
            if (map.ContainsKey(node))
            {
                return map[node];
            }

            Node clone = new Node(node.val);
            map[node] = clone;

            foreach (Node neighbor in node.neighbors)
            {
                clone.neighbors.Add(CloneNode(neighbor, map));
            }

            return clone;
        }

        static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // Create an adjacency list to represent the graph
            List<int>[] graph = new List<int>[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                graph[i] = new List<int>();
            }

            // Fill the adjacency list with the prerequisites
            foreach (var prerequisite in prerequisites)
            {
                graph[prerequisite[1]].Add(prerequisite[0]);
            }

            // Array to track the visit status of each course
            int[] visitStatus = new int[numCourses];

            // Perform DFS for each course
            for (int i = 0; i < numCourses; i++)
            {
                if (HasCycle(graph, visitStatus, i))
                {
                    return false;
                }
            }

            return true;
        }

        static bool HasCycle(List<int>[] graph, int[] visitStatus, int course)
        {
            if (visitStatus[course] == 1)
            {
                // Cycle detected
                return true;
            }
            if (visitStatus[course] == 2)
            {
                // Already visited and no cycle detected
                return false;
            }

            // Mark the course as being visited
            visitStatus[course] = 1;

            // Perform DFS on the neighbors
            foreach (var neighbor in graph[course])
            {
                if (HasCycle(graph, visitStatus, neighbor))
                {
                    return true;
                }
            }

            // Mark the course as fully visited
            visitStatus[course] = 2;

            return false;
        }

        static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> result = new List<int[]>();
            int i = 0;
            int n = intervals.Length;

            // Add all intervals before the new interval
            while (i < n && intervals[i][1] < newInterval[0])
            {
                result.Add(intervals[i]);
                i++;
            }

            // Merge overlapping intervals
            while (i < n && intervals[i][0] <= newInterval[1])
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                i++;
            }
            result.Add(newInterval);

            // Add all intervals after the new interval
            while (i < n)
            {
                result.Add(intervals[i]);
                i++;
            }

            return result.ToArray();
        }

        static ListNode ReverseList(ListNode head)
        {
            Stack<ListNode> stack = new();
            var current = head;
            while (current != null)
            {
                stack.Push(current);
                current = current.next;
            }

            var newHead = stack.Pop();
            current = newHead;
            while(stack.Count > 0)
            {
                current.next = stack.Pop();
                current = current.next;
            }

            return current;
        }

        static ListNode ReverseList2(ListNode head)
        {
            if (head == null)
                return head;

            var prev = head;
            var current = head.next;
            prev.next = null;
            while (current != null)
            {
                var currentNext = current.next;
                current.next = prev;
                prev = current;
                current = currentNext;
            }

            return prev;
        }

        static void SetZeroes(int[][] matrix)
        {
            HashSet<int> registerColumn = new();
            HashSet<int> registerRow = new();
            for(int row = 0; row < matrix.Length; row++)
            {
                for(int col = 0; col < matrix[row].Length; col++)
                {
                    if(matrix[row][col] == 0)
                    {
                        registerColumn.Add(col);
                        registerRow.Add(row);
                    }
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (registerRow.Contains(row))
                        matrix[row][col] = 0;

                    if (registerColumn.Contains(col))
                        matrix[row][col] = 0;
                }
            }
        }

        static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0)
                return 0;

            Dictionary<char, int> holdCharacters = new();
            int longestUniqueSubstring = 0;
            int currentLongesUniqueSubstring = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (holdCharacters.ContainsKey(s[i]))
                {
                    if (currentLongesUniqueSubstring > longestUniqueSubstring)
                        longestUniqueSubstring = currentLongesUniqueSubstring;
                    currentLongesUniqueSubstring = 0;
                    i = holdCharacters[s[i]];
                    holdCharacters = new();
                }
                else
                {
                    currentLongesUniqueSubstring++;
                    holdCharacters.Add(s[i], i);
                }
            }
            if (currentLongesUniqueSubstring > longestUniqueSubstring)
                longestUniqueSubstring = currentLongesUniqueSubstring;

            return longestUniqueSubstring;
        }

        private class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        static int MaxDepth(TreeNode root)
        {
            return MaxDepthRecursivelly(root) + 1;
        }

        static int MaxDepthRecursivelly(TreeNode root)
        {
            if (root == null)
                return -1;

            int leftDepth = MaxDepthRecursivelly(root.left) + 1;
            int rightDepth = MaxDepthRecursivelly(root.right) + 1;

            return Math.Max(leftDepth, rightDepth);
        }

        #region Test Classes
        private class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        #endregion
    }
}
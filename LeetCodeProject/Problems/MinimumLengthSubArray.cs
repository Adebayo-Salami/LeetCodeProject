using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.Problems
{
    public static class MinimumLengthSubArray
    {
        public static void Run()
        {
            Console.WriteLine("Result for [2, 2, 1, 1, 3] & 3: " + findMinimumLengthSubarray_Try3([2, 2, 1, 1, 3], 3));
            Console.WriteLine("Result for [1,2,2,1,2] & 4: " + findMinimumLengthSubarray_Try3([1, 2, 2, 1, 2], 4));
        }

        public static int findMaximumDistance(List<string> grid)
        {
            var ans = -1;

            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return ans;
        }

        public static int findMinimumLengthSubarray_Try2(List<int> arr, int k)
        {
            int ans = -1;

            try
            {
                int n = arr.Count;
                int res = 0;
                int diffNo = 0;
                var counter = new Dictionary<int, int>();
                int j = 0;

                for(int i = 0; i < n; i++)
                {
                    while(j < n && diffNo < k)
                    {
                        int numOfTN = counter.GetValueOrDefault(arr[j], 0);
                        counter.TryAdd(arr[j], numOfTN + 1);
                        if (counter[arr[j]] == 1)
                            diffNo++;

                        j++;
                    }

                    if (diffNo == k)
                        res += n - j + 1;

                    counter.TryAdd(arr[i], counter[arr[i]] - 1);
                    if (counter[arr[i]] == 0)
                        diffNo--;
                }
                if (res > 0)
                    ans = res;
                

                //Dictionary<int, int> countM = new();
                //int left = 0;
                //int distinctCount = 0;
                //int minLength = int.MaxValue;

                //for(int right = 0; right < n; right++)
                //{
                //    if (countM.ContainsKey(arr[right]))
                //    {
                //        distinctCount++;
                //    }

                //    countM[arr[right]] = countM.GetValueOrDefault(arr[right], 0) + 1;

                //    while (distinctCount >= k)
                //    {
                //        minLength = Math.Min(minLength, right - left + 1);

                //        countM[arr[left]]--;
                //        if (countM[arr[left]] == 0)
                //        {
                //            distinctCount--;
                //            countM.Remove(arr[left]);
                //        }
                //        left++;
                //    }
                //}

                //ans = minLength == int.MaxValue ? -1 : minLength;

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ans;
        }

        public static int findMinimumLengthSubarray(List<int> arr, int k)
        {
            int ans = -1;

            try
            {
                if (arr.Count <= 1)
                    return 1;
                if (k <= 1)
                    return 1;
                if (k > arr.Count)
                    return ans;

                int tempAns = arr.Count;
                for(int i = 0;  i < arr.Count; i++)
                {
                    int charsAdded = 1;
                    Dictionary<int, int> chars = new();
                    chars.Add(arr[i], arr[i]);

                    for (int j = i + 1; j < arr.Count; j++)
                    {
                        chars.TryAdd(arr[j], arr[j]);

                        charsAdded++;
                        if (chars.Count == k)
                            break;
                    }

                    if(charsAdded < tempAns && chars.Count == k)
                    {
                        tempAns = charsAdded;
                        ans = tempAns;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ans;
        }

        public static int findMinimumLengthSubarray_Try3(List<int> arr, int k)
        {
            int ans = -1;

            try
            {
                if (arr.Count <= 1)
                    return 1;
                if (k <= 1)
                    return 1;
                if (k > arr.Count)
                    return ans;


                int tempAns = arr.Count;
                for (int i = 0; i < arr.Count; i++)
                {
                    int charsAdded = 1;
                    Dictionary<int, int> chars = new();
                    chars.Add(arr[i], arr[i]);

                    for (int j = i + 1; j < arr.Count; j++)
                    {
                        chars.TryAdd(arr[j], arr[j]);

                        charsAdded++;
                        if (chars.Count == k)
                            break;
                    }

                    if (charsAdded < tempAns && chars.Count == k)
                    {
                        tempAns = charsAdded;
                        ans = tempAns;
                    }

                    if (ans < 5 && i >= (arr.Count / 2) && ans != -1)
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ans;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.Problems
{
    public static class DailyChallenge
    {
        public static void Run()
        {
            Console.WriteLine("Daily Challenge");

            Console.WriteLine("Result for [1, 10, 3, 10, 2], 3, 1: " + MinDays([1, 10, 3, 10, 2], 3, 1));
            Console.WriteLine("Result for [1,10,3,10,2], 3, 2: " + MinDays([1, 10, 3, 10, 2], 3, 2));
            Console.WriteLine("Result for [7,7,7,7,12,7,7], 2, 3: " + MinDays([7, 7, 7, 7, 12, 7, 7], 2, 3));
            Console.WriteLine("Result for [18,45,42,50,86,40,73,47,69,83,42,61,59,42,97,61,25,89,89,97,22,13,65], 5, 4: " + MinDays([18, 45, 42, 50, 86, 40, 73, 47, 69, 83, 42, 61, 59, 42, 97, 61, 25, 89, 89, 97, 22, 13, 65], 5, 4));
            Console.WriteLine("Result for [51,67,18,83,25,26,40,45,100,15,3,27,96,88,79,66,46,52,67,13,28,38,93,69,89,23,72,100,42,34,16], 2, 3: " + MinDays([51, 67, 18, 83, 25, 26, 40, 45, 100, 15, 3, 27, 96, 88, 79, 66, 46, 52, 67, 13, 28, 38, 93, 69, 89, 23, 72, 100, 42, 34, 16], 2, 11));
        }

        #region Challenge 19-06-2024
        /* Minimum Number of Days to Make m Bouquets 
         You are given an integer array bloomDay, an integer m and an integer k.
         You want to make m bouquets. To make a bouquet, you need to use k adjacent flowers from the garden.
         The garden consists of n flowers, the ith flower will bloom in the bloomDay[i] and then can be used in exactly one bouquet.
         Return the minimum number of days you need to wait to be able to make m bouquets from the garden. If it is impossible to make m bouquets return -1.
        */
        public static int MinDays(int[] bloomDay, int m, int k)
        {
            int minimumDays = -1;
         
            try
            {
                int flowersNeeded = m * k;
                if (flowersNeeded > bloomDay.Length)
                    return minimumDays;

                int daysPassed = 0;
                var sortedBloomDate = bloomDay.OrderBy(x => x).ToArray();
                daysPassed = sortedBloomDate[flowersNeeded - 1];
                var distinctBloomDates = sortedBloomDate.Skip(flowersNeeded - 1).Distinct().ToArray();
                int distinctIndex = 0;

                var daysLog = new Dictionary<int, int>();
                while(distinctIndex < distinctBloomDates.Length)
                {
                    if (daysLog.Count == m)
                        break;

                    for (int i = 0; i < (bloomDay.Length - k + 1); i++)
                    {
                        if (daysLog.Count == m)
                            break;

                        if (daysLog.ContainsKey(i))
                        {
                            i = (i + k) - 1;
                            continue;
                        }

                        int flowersPluckable = 0;
                        if ((bloomDay[i] - daysPassed) <= 0)
                            flowersPluckable++;

                        int tempK = k;
                        while (tempK > 1)
                        {
                            if (daysLog.ContainsKey((i + tempK) - 1))
                                daysLog.Remove((i + tempK) - 1);

                            if ((bloomDay[(i + tempK) - 1] - daysPassed) <= 0)
                                flowersPluckable++;

                            tempK--;
                        }

                        if (flowersPluckable == k)
                        {
                            foreach (var dayLogged in daysLog)
                                if (i >= dayLogged.Key && i <= ((dayLogged.Key + k) - 1))
                                    daysLog = new();

                            daysLog.Add(i, daysPassed);
                            i = (i + k) - 1;
                        }
                    }
                    if ((distinctIndex + 1) == distinctBloomDates.Length) break;
                    daysPassed = distinctBloomDates[++distinctIndex];
                }

                if (daysLog.Count == m)
                    foreach (var dayLogged in daysLog)
                        if (dayLogged.Value > minimumDays)
                            minimumDays = dayLogged.Value;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return minimumDays;
        }

        public static int OptMinDays(int[] bloomDay, int m, int k)
        {
            int n = bloomDay.Length;
            if (m * k > n) return -1; // Impossible to create m bouquets

            int left = 1; // Minimum possible day
            int right = bloomDay.Max(); // Maximum possible day

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (CanCreateBouquets(bloomDay, m, k, mid))
                    right = mid; // Search in the left half
                else
                    left = mid + 1; // Search in the right half
            }

            return left;
        }

        private static bool CanCreateBouquets(int[] bloomDay, int m, int k, int day)
        {
            int bouquets = 0;
            int adjacentFlowers = 0;

            foreach (int bloom in bloomDay)
            {
                if (bloom <= day)
                {
                    adjacentFlowers++;
                    if (adjacentFlowers == k)
                    {
                        bouquets++;
                        adjacentFlowers = 0;
                    }
                }
                else
                {
                    adjacentFlowers = 0;
                }
            }

            return bouquets >= m;
        }

        #endregion
    }
}

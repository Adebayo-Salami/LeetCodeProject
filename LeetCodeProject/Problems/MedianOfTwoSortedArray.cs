using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.Problems
{
    public static class MedianOfTwoSortedArray
    {
        public static void Run()
        {
            Console.WriteLine("Median of Two Sorted Arrays");

            Console.WriteLine("Result for [1,3] & [2]: " + FindMedianSortedArrays([1,3], [2]));
            Console.WriteLine("Result for [1,2] & [3,4]: " + FindMedianSortedArrays([1,2], [3,4]));
            Console.WriteLine("Result for [] & [1]: " + FindMedianSortedArrays([], [1]));
            Console.WriteLine("Result for [] & [2, 3]: " + FindMedianSortedArrays([], [2,3]));
            Console.WriteLine("Result for [3] & [-2, -1]: " + FindMedianSortedArrays([3], [-2,-1]));
            Console.WriteLine("Result for [] & [1,2,3,4,5]: " + FindMedianSortedArrays([], [1,2,3,4,5]));
            Console.WriteLine("Result for [4] & [1,2,3]: " + FindMedianSortedArrays([4], [1,2,3]));
            Console.WriteLine("Result for [4,5] & [1,2,3]: " + OptFindMedianSortedArrays([4,5], [1,2,3]));
            Console.WriteLine("Result for [1,2,3] & [4,5,6,7]: " + FindMedianSortedArrays([1,2,3], [4,5,6,7]));
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            double ans = 0;

            try
            {
                int[] sum = new int[nums1.Length + nums2.Length];
                bool isDivisibleBy2 = sum.Length % 2 == 0;
                int num1Pointer = 0;
                int num2Pointer = 0;
                int sumPointer = 0;

                int lengthToUse = nums1.Length > nums2.Length ? nums2.Length : nums1.Length;
                while(lengthToUse > 0)
                {
                    if (nums1[num1Pointer] < nums2[num2Pointer])
                    {
                        if (sumPointer > 0 && sum[sumPointer - 1] > nums1[num1Pointer])
                        {
                            int tempSumPointer = sumPointer - 1;
                            int value = nums1[num1Pointer];
                            while (tempSumPointer > 0 && sum[tempSumPointer] > value)
                            {
                                int temp = sum[tempSumPointer];
                                sum[tempSumPointer] = value;
                                sum[tempSumPointer + 1] = temp;
                                tempSumPointer--;
                            }

                            sumPointer++;
                        }
                        else
                            sum[sumPointer++] = nums1[num1Pointer];

                        sum[sumPointer++] = nums2[num2Pointer];
                    }
                    else
                    {
                        if (sumPointer > 0 &&  sum[sumPointer - 1] > nums2[num2Pointer])
                        {
                            int tempSumPointer = sumPointer - 1;
                            int value = nums2[num2Pointer];
                            while (tempSumPointer > 0 && sum[tempSumPointer] > value)
                            {
                                int temp = sum[tempSumPointer];
                                sum[tempSumPointer] = value;
                                sum[tempSumPointer + 1] = temp;
                                tempSumPointer--;
                            }

                            sumPointer++;
                        }
                        else
                            sum[sumPointer++] = nums2[num2Pointer];

                        sum[sumPointer++] = nums1[num1Pointer];
                    }

                    num1Pointer++;
                    num2Pointer++;
                    lengthToUse--;
                }

                for (int i = num1Pointer; i < nums1.Length; i++)
                {
                    if (sumPointer > 0 && sum[sumPointer - 1] > nums1[i])
                    {
                        int tempSumPointer = sumPointer - 1;
                        int value = nums1[i];
                        while(tempSumPointer > 0 && sum[tempSumPointer] > value)
                        {
                            int temp = sum[tempSumPointer];
                            sum[tempSumPointer] = value;
                            sum[tempSumPointer + 1] = temp;
                            tempSumPointer--;
                        }

                        sumPointer++;
                    }
                    else
                        sum[sumPointer++] = nums1[i];
                }  
                for (int i = num2Pointer; i < nums2.Length; i++)
                {
                    if (sumPointer > 0 && sum[sumPointer - 1] > nums2[i])
                    {
                        int tempSumPointer = sumPointer - 1;
                        int value = nums2[i];
                        while (tempSumPointer > 0 && sum[tempSumPointer] > value)
                        {
                            int temp = sum[tempSumPointer];
                            sum[tempSumPointer] = value;
                            sum[tempSumPointer + 1] = temp;
                            tempSumPointer--;
                        }

                        sumPointer++;
                    }
                    else
                        sum[sumPointer++] = nums2[i];
                } 

                if (isDivisibleBy2)
                {
                    ans = Convert.ToDouble((sum[sum.Length / 2] + sum[(sum.Length / 2) - 1]) / 2m);
                }
                else
                {
                    if (sum.Length < 2)
                        ans = sum[0];
                    else
                        ans = sum[sum.Length / 2];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ans;
        }

        public static double OptFindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] merged = new int[nums1.Length + nums2.Length];
            int i = 0, j = 0, k = 0;

            // Merge two arrays
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] < nums2[j])
                {
                    merged[k++] = nums1[i++];
                }
                else
                {
                    merged[k++] = nums2[j++];
                }
            }

            // If there are remaining elements in nums1
            while (i < nums1.Length)
            {
                merged[k++] = nums1[i++];
            }

            // If there are remaining elements in nums2
            while (j < nums2.Length)
            {
                merged[k++] = nums2[j++];
            }

            // Find the median
            int mid = merged.Length / 2;
            if (merged.Length % 2 == 0)
            {
                return (merged[mid - 1] + merged[mid]) / 2.0;
            }
            else
            {
                return merged[mid];
            }
        }
    }
}

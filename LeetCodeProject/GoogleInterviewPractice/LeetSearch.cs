using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public static class LeetSearch
    {
        public static void RunTest()
        {
            int[] test1 = { 3, 5, 6, 9, 11, 18, 20, 21, 24, 30 };
            Console.WriteLine("Index of 6 is " + ExponentialSearch(test1, 182));
        }

        private static int BinarySearch_Iteration(int[] numbers, int k)
        {
            if (numbers.Length == 0)
                return -1;

            Array.Sort(numbers);
            int leftWall = 0, rightWall = numbers.Length - 1;
            while (leftWall < rightWall)
            {
                var middleIndex = (leftWall + rightWall) / 2;
                if (numbers[middleIndex] == k)
                    return middleIndex;
                else if (numbers[middleIndex] > k)
                    rightWall = middleIndex - 1;
                else
                    leftWall = middleIndex + 1;
            }

            return -1;
        }

        private static int BinarySearch_Recursive(int[] numbers, int k)
        {
            if (numbers.Length == 0)
                return -1;

            return BinarySearch_Recursive(numbers, k, 0, numbers.Length - 1);
        }

        private static int BinarySearch_Recursive(int[] numbers, int k, int leftWall, int rightWall)
        {
            if (leftWall > rightWall)
                return -1;

            var middleIndex = (leftWall + rightWall) / 2;
            if (numbers[middleIndex] == k)
                return middleIndex;
            else if (numbers[middleIndex] > k)
                rightWall = middleIndex - 1; 
            else
                leftWall = middleIndex + 1;
            return BinarySearch_Recursive(numbers, k, leftWall, rightWall);
        }

        private static int TernarySearch_Recursive(int[] numbers, int k)
        {
            if (numbers.Length == 0)
                return -1;

            var midPoints = GetMidPoints(numbers, 0, numbers.Length - 1);
            return TernarySearch_Recursive(numbers, k, midPoints.Item1, midPoints.Item2);
        }

        private static int TernarySearch_Recursive(int[] numbers, int k, int mid1, int mid2)
        {
            if (mid1 > mid2)
                return -1;

            if (numbers[mid1] == k)
                return mid1;
            else if (numbers[mid2] == k)
                return mid2;
            else if (k > numbers[mid1] && k < numbers[mid2])
                (mid1, mid2) = GetMidPoints(numbers, mid1 + 1, mid2 - 1);
            else if (k < numbers[mid1])
                (mid1, mid2) = GetMidPoints(numbers, 0, mid1 - 1);
            else
                (mid1, mid2) = GetMidPoints(numbers, 0, mid1 - 1);

            return TernarySearch_Recursive(numbers, k, mid2 + 1, numbers.Length - 1);
        }

        private static (int, int) GetMidPoints(int[] numbers, int left, int right)
        {
            var partition = (right - left) / 2;
            return (left + partition, right - partition);
        }

        private static int ExponentialSearch(int[] numbers, int target)
        {
            if (numbers.Length == 0)
                return -1;


            for(int previousBound = 0, bound = (numbers.Length > 2 ? 2 : numbers.Length -1); bound < numbers.Length;)
            {
                if(numbers[bound] >= target)
                {
                    for (int i = previousBound; i <= bound; i++)
                        if (numbers[i] == target)
                            return i;
                    return -1;
                }

                previousBound = bound;
                bound = bound + bound;
                if (previousBound == numbers.Length - 1)
                    break;
                if (bound >= numbers.Length)
                    bound = numbers.Length - 1;
            }

            return -1;
        }
    }
}

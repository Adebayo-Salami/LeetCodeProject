using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public static class LeetSortClass
    {
        public static void RunTest()
        {
            int[] test1 = { 8, 2, 4, 1, 3 };
            Console.WriteLine(String.Join(',', CountingSort(test1)));

            int[] test2 = { 7, 3, 1, 4, 6, 2, 3 };
            Console.WriteLine(String.Join(',', CountingSort(test2)));

            int[] test3 = { 7, 3, 5, 2, 3, 1, 5, 8 };
            BucketSort(test3, 3);
            Console.WriteLine(String.Join(',', test3));

            int[] test4 = { 15, 6, 3, 1, 22, 10, 13 };
            BucketSort(test4, 3);
            Console.WriteLine(String.Join(',', test4));
        }

        private static int[] BubbleSort(int[] numbers)
        {
            bool isSwapped = true;
            for(int i = 0; i < (numbers.Length - 1); i++)
            {
                isSwapped = false;
                for(int j = 1, k = 0; j < (numbers.Length - i); j++, k++)
                {
                    if (numbers[k] > numbers[j])
                    {
                        Swap(numbers, k, j);
                        isSwapped = true;
                    }
                }
                if (!isSwapped)
                    break;
            }

            return numbers;
        }

        private static void Swap(int[] numbers, int index, int newIndex)
        {
            var temp = numbers[index];
            numbers[index] = numbers[newIndex];
            numbers[newIndex] = temp;
        }

        private static int[] SelectionSort(int[] numbers)
        {
            for(int i = 0;i < (numbers.Length - 1);i++)
            {
                var lowestIndex = i;
                for (int j = i + 1; j < numbers.Length; j++)
                    if (numbers[j] < numbers[lowestIndex])
                        lowestIndex = j;

                if (lowestIndex != i)
                    Swap(numbers, lowestIndex, i);
            }
            return numbers;
        }

        private static int[] InsertionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var currentValue = numbers[i];
                int insertIndex = i;
                while(insertIndex > 0 && numbers[insertIndex - 1] > currentValue)
                {
                    numbers[insertIndex] = numbers[insertIndex - 1];
                    insertIndex--;
                }
                numbers[insertIndex] = currentValue;
            }

            return numbers;
        }

        private static void MergeSort(int[] numbers)
        {
            if (numbers.Length < 2)
                return;

            var middle = numbers.Length / 2;

            int[] left = new int[middle];
            for (int i = 0; i < middle; i++)
                left[i] = numbers[i];

            int[] right = new int[numbers.Length - middle];
            for (int i = middle; i < numbers.Length; i++)
                right[i - middle] = numbers[i];

            MergeSort(left);
            MergeSort(right);

            MergeSort(left, right, numbers);
        }

        private static void MergeSort(int[] left, int[] right, int[] result)
        {
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    result[k++] = left[i++];
                else
                    result[k++] = right[j++];
            }

            while (i < left.Length)
                result[k++] = left[i++];

            while (j < right.Length)
                result[k++] = right[j++];
        }

        private static void QuickSort(int[] numbers)
        {
            QuickSort(numbers, 0, numbers.Length - 1);
        }

        private static void QuickSort(int[] numbers, int start, int end)
        {
            if (start >= end)
                return;

            var boundary = Partition(numbers, start, end);

            QuickSort(numbers, start, boundary - 1);
            QuickSort(numbers, boundary + 1, end);
        }

        private static int Partition(int[] numbers, int start, int end)
        {
            var pivot = numbers[end];
            int boundary = start - 1;
            for (int i = start; i <= end; i++)
                if (numbers[i] <= pivot)
                    Swap(numbers, i, ++boundary);
            return boundary;
        }

        private static int[] CountingSort(int[] numbers)
        {
            int[] sortedNumbers = new int[GetLargestValue(numbers) + 1];
            for (int i = 0; i < numbers.Length; i++)
                sortedNumbers[numbers[i]]++;

            for (int i = 0, j = 0; i < sortedNumbers.Length; i++)
                while (sortedNumbers[i] > 0)
                {
                    numbers[j++] = i;
                    sortedNumbers[i]--;
                }

            return numbers;
        }

        private static int GetLargestValue(int[] numbers)
        {
            int largestNo = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
                if (numbers[i] > largestNo)
                    return numbers[i];
            return largestNo;
        }

        private static void BucketSort(int[] numbers, int bucketCount)
        {
            var buckets = new LinkedList<int>[bucketCount];
            for ( int i = 0; i < numbers.Length; i++)
            {
                var index = numbers[i] / bucketCount;
                if (index >= buckets.Length)
                    index = buckets.Length - 1;
                if (buckets[index] == null)
                    buckets[index] = new LinkedList<int>();
                buckets[index].AddLast(numbers[i]);
            }

            int insertingI = 0;
            foreach (var bucket in buckets)
            {
                var bucketArray = bucket.ToArray();
                QuickSort(bucketArray);
                for (int z = 0; z < bucketArray.Length; z++)
                    numbers[insertingI++] = bucketArray[z];
            }
        }
    }
}

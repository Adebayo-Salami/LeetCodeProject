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
            Console.WriteLine(String.Join(',', InsertionSort(test1)));

            int[] test2 = { 7, 3, 1, 4, 6, 2, 3 };
            Console.WriteLine(String.Join(',', InsertionSort(test2)));
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
    }
}

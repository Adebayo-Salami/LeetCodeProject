using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public static class LeetBubbleSort
    {
        public static void RunTest()
        {
            int[] test1 = { 8, 2, 4, 1, 3 };
            Console.WriteLine(String.Join(',', Sort(test1)));

            int[] test2 = { 7, 3, 1, 4, 6, 2, 3 };
            Console.WriteLine(String.Join(',', Sort(test2)));
        }

        public static int[] Sort(int[] numbers)
        {
            bool isSwapped = true;
            for(int i = 0; i < (numbers.Length - 1); i++)
            {
                isSwapped = false;
                for(int j = 1, k = 0; j < numbers.Length; j++, k++)
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
    }
}

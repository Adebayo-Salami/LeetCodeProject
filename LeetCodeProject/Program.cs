using LeetCodeProject.GoogleInterviewPractice;
using LeetCodeProject.Problems;

namespace LeetCodeProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Project Leet Code!");

            //TwoSum.Run();
            //AddTwoNumbers.Run();
            //LongestUniqueSubstring.Run();
            //MedianOfTwoSortedArray.Run();
            //DailyChallenge.Run();
            //LongestPalindromicSubstring.Run();
            //ZigzagConversion.Run();
            //MinimumLengthSubArray.Run();
            //ReverseInteger.Run();
            //StringToInteger.Run();
            RunGoogleInterviewPrepCode();

            Console.ReadKey();
        }

        static void RunGoogleInterviewPrepCode()
        {
            RunArrayClass();
        }

        static void RunArrayClass()
        {
            LeetArray numbers = new LeetArray(10);
            numbers.Insert(10);
            numbers.Insert(20);
            numbers.Insert(30);
            numbers.Insert(40);
            numbers.Insert(50);
            numbers.Insert(60);
            numbers.Insert(70);
            numbers.Insert(80);
            numbers.Insert(90);
            numbers.Insert(100);
            numbers.RemoveAt(3);
            Console.WriteLine(numbers.IndexOf(100));

            LeetArray numbers2 = new LeetArray(10);
            numbers2.Insert(50);
            numbers2.Insert(60);
            numbers2.Insert(70);
            numbers2.Insert(80);
            numbers2.Insert(90);
            numbers2.Insert(100);
            numbers2.Insert(110);
            numbers2.Insert(120);
            numbers2.Insert(130);
            numbers2.Insert(140);

            var intersectedNumbers = numbers.Intersect(numbers2);
            intersectedNumbers.Print();

            LeetArray numbers3 = new LeetArray(4);
            numbers3.Insert(1);
            numbers3.Insert(2);
            numbers3.Insert(3);
            numbers3.Insert(4);
            numbers3.Reverse();
            numbers3.Print();

            Console.WriteLine("Testing Insert At");
            LeetArray numbers4 = new LeetArray(5);
            numbers4.Insert(1);
            numbers4.Insert(2);
            numbers4.Insert(3);
            numbers4.Print();
            Console.WriteLine("----Inserting 8 at index 1 now----");
            numbers4.InsertAt(8, 1);
            numbers4.Print();
        }
    }
}
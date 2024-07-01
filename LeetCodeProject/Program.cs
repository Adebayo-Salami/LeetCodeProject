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
            //RunArrayClass();
            //RunLinkedListClass();
            //RunStackClass();
            //RunQueueClass();
            //RunHashClass();
            RunBinaryTreeClass();
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

        static void RunLinkedListClass()
        {
            var list = new LeetLinkedList();
            list.AddLast(10);
            list.AddLast(20);
            list.AddLast(30);
            list.AddLast(40);
            list.AddLast(50);
            list.AddLoopToNthPosition(3);
            Console.WriteLine("Is there loop in list: " + list.HasLoop());
            Console.WriteLine("Printing List Middle Value(s)");
            //list.PrintMiddle();
            Console.WriteLine("");
            Console.WriteLine("Done Printing List Middle Value(s)");
            //list.Print();
            Console.WriteLine("Kth Node From the end. K = 3 : value: " + list.FindKthNodeFromTheEnd(1));
        }

        static void RunStackClass()
        {
            string word1 = "(([1] + <2>))[a]";
            Console.WriteLine($"Is {word1} balanced: {LeetStack.IsBalancedEpression(word1)}");

            string word2 = "(([1] + <2>))[a]<";
            Console.WriteLine($"Is {word2} balanced: {LeetStack.IsBalancedEpression(word2)}");

            string word3 = "((1 + 2)";
            Console.WriteLine($"Is {word3} balanced: {LeetStack.IsBalancedEpression(word3)}");
        }

        static void RunQueueClass()
        {
            var queue = new LeetQueue();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
            queue.Print();
            queue.Reverse(3);
            queue.Print();

            var queue2 = new LeetQueue2();
            queue2.Enqueue(10);
            queue2.Enqueue(20);
            queue2.Enqueue(30);
            queue2.Enqueue(40);
            queue2.Enqueue(50);
            queue2.Print();
            queue2.Dequeue();
            queue2.Print();
            Console.WriteLine("Peeking: " + queue2.Peek);
            Console.WriteLine("Size: " + queue2.Size);
            Console.WriteLine("IsEmpty: " + queue2.IsEmpty);
            queue2.Dequeue();
            queue2.Dequeue();
            queue2.Dequeue();
            queue2.Dequeue();
            Console.WriteLine("IsEmpty: " + queue2.IsEmpty);
        }

        static void RunHashClass()
        {
            LeetDictionary.FirstNonRepeatingChar("a green apple");
            LeetDictionary.FirstRepeatedChar("a green apple");

            var hashTable = new LeetHashTable();
            hashTable.Put(3782, "tester");
            hashTable.Put(31282, "tester2");

            var hashTable2 = new LeetHashTable();
            hashTable2.Put(6, "A");
            hashTable2.Put(8, "B");
            hashTable2.Put(11, "C");
            hashTable2.Put(6, "A+");
            //hashTable2.Remove(60);
            Console.WriteLine("Get from Index 6 : " + hashTable2.Get(60));
            Console.WriteLine("Done");

            Console.WriteLine($"Most frequent value in [1, 2, 2, 3, 3, 3, 4] is {LeetDictionary.FindMostFrequentValue([1, 2, 2, 3, 3, 3, 4])}");
            Console.WriteLine($"Most frequent value in [1, 2, 2, 3, 3, 3, 4, 2, 2] is {LeetDictionary.FindMostFrequentValue([1, 2, 2, 3, 3, 3, 4, 2, 2])}");

            Console.WriteLine($"Number of 2 Pairs in [1, 7, 5, 9, 2, 12, 3] is {LeetDictionary.FindNumberOfPairsWithKthDiff([1, 7, 5, 9, 2, 12, 3], 2)}");
            
            Console.WriteLine($"Two sum of -8 in [-1,-2,-3,-4,-5] is {String.Join(',', LeetDictionary.FindTwoSum([-1, -2, -3, -4, -5], -8))}"); // Expected: [2,4]
            Console.WriteLine($"Two sum of 9 in [2, 7, 11, 15] is {String.Join(',', LeetDictionary.FindTwoSum([2, 7, 11, 15], 9))}");
            Console.WriteLine($"Two sum of 6 in [3,2,4] is {String.Join(',', LeetDictionary.FindTwoSum([3, 2, 4], 6))}");
            Console.WriteLine($"Two sum of 6 in [3,3] is {String.Join(',', LeetDictionary.FindTwoSum([3, 3], 6))}");
        }

        static void RunBinaryTreeClass()
        {
            int[] test1 = { 10, 5, 15, 6, 1, 8, 12, 18, 17 };
            Console.WriteLine("Inserting [10, 5, 15, 6, 1, 8, 12, 18, 17]");
            var tree = new LeetBinaryTree(test1[0]);
            for (int i = 1; i < test1.Length; i++)
                tree.Insert(test1[i]);

            Console.WriteLine("10 exists: " + tree.Find(10));
            Console.WriteLine("6 exists: " + tree.Find(6));
            Console.WriteLine("62 exists: " + tree.Find(62));
            Console.WriteLine("18 exists: " + tree.Find(18));
            Console.WriteLine("17 exists: " + tree.Find(17));
            Console.WriteLine("22 exists: " + tree.Find(22));
            Console.WriteLine("Done");

            int[] test2 = { 20, 10, 30, 6, 14, 24, 3, 8, 26 };
            Console.WriteLine("Inserting [20, 10, 30, 6, 14, 24, 3, 8, 26]");
            var tree2 = new LeetBinaryTree(test2[0]);
            for (int i = 1; i < test2.Length; i++)
                tree2.Insert(test2[i]);

            Console.WriteLine("Printing the Value In Depth First - Pre-order");
            tree2.PrintDepthFirstPreOrder();
            Console.WriteLine("Done");

            Console.WriteLine("Printing the Value In Depth First - In-order");
            tree2.PrintDepthFirstInOrder();
            Console.WriteLine("Done");

            Console.WriteLine("Printing the Value In Depth First - Post-order");
            tree2.PrintDepthFirstPostOrder();
            Console.WriteLine("Done");
        }
    }
}
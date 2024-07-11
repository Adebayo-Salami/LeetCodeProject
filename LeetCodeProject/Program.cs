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
            //RunBinaryTreeClass();
            //RunAVLBinaryTreeClass();
            //RunHeapClass();
            //RunTriesClass();
            RunGraphClass();
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
            Console.WriteLine("Size of Tree: " + tree.Size);
            Console.WriteLine("Max Value of Tree: " + tree.Max());
            Console.WriteLine("Tree contains 1: " + tree.Contains(1));
            Console.WriteLine("Tree contains 17: " + tree.Contains(17));
            Console.WriteLine("Tree contains 173: " + tree.Contains(173));
            tree.GetTreeMinimumValue();
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

            int[] test3 = { 7, 4, 9, 1, 6, 8, 10 };
            Console.WriteLine("Inserting [7, 4, 9, 1, 6, 8, 10]");
            var tree3 = new LeetBinaryTree(test3[0]);
            for (int i = 1; i < test3.Length; i++)
                tree3.Insert(test3[i]);
            Console.WriteLine("Heigth of Tree: " + tree3.GetTreeHeight());
            Console.WriteLine("Minimum Value of Tree: " + tree3.GetTreeMinimumValue());
            tree3.PrintBreadthFirst();
            Console.WriteLine("Done -breath first");

            int[] test4 = { 7, 4, 9, 1, 6, 8, 10 };
            Console.WriteLine("Inserting Tree 1: [7, 4, 9, 1, 6, 8, 10]");
            var tree4 = new LeetBinaryTree(test3[0]);
            for (int i = 1; i < test4.Length; i++)
                tree4.Insert(test4[i]);
            int[] test5 = { 7, 4, 9, 1, 6, 8, 10, 0 };
            Console.WriteLine("Inserting Tree 2: [7, 4, 9, 1, 6, 8, 10, 0]");
            var tree5 = new LeetBinaryTree(test5[0]);
            for (int i = 1; i < test5.Length; i++)
                tree5.Insert(test5[i]);

            Console.WriteLine("Is Tree 1 same with previous last upper input: " + tree4.IsEqual(tree3));
            Console.WriteLine("Is Tree 1 same with Tree 2: " + tree4.IsEqual(tree5));

            Console.WriteLine("Testing Validating Binary Search Tree - Attach debugger");
            Console.WriteLine("Is Binary Search Tree Valid: " + tree5.IsBinarySearchTree());
            tree5.TestIsBinarySearchTree();
            Console.WriteLine("Is Non-Binary Search Tree Valid: " + tree5.IsBinarySearchTree());

            Console.WriteLine("Printing out values at distance 3 from root");
            tree5.PrintValuesAtDeptK(1);
            Console.WriteLine("Count Leaves: " + tree5.CountLeaves());
            Console.WriteLine("Maximum Value is " + tree5.Max());
            Console.WriteLine("Contains 21 " + tree5.Contains(21));
            Console.WriteLine("Contains 8 " + tree5.Contains(8));
            Console.WriteLine("Contains 180 " + tree5.Contains(180));
            Console.WriteLine("Are 6 and 21 siblings: " + tree5.AreSiblings(6, 21));
            Console.WriteLine("Are 3 and 8 siblings: " + tree5.AreSiblings(3, 8));
            Console.WriteLine("Are 10 and 30 siblings: " + tree5.AreSiblings(10, 30));
            Console.WriteLine("Are 21 and 4 siblings: " + tree5.AreSiblings(21, 4));
            Console.WriteLine("Ancestors of 3: " + String.Join(',', tree5.GetAncestors(3)));
            Console.WriteLine("Ancestors of 21: " + String.Join(',', tree5.GetAncestors(21)));
            Console.WriteLine("Ancestors of 4: " + String.Join(',', tree5.GetAncestors(4)));
        }

        static void RunAVLBinaryTreeClass()
        {
            var tree = new LeetAVLBinaryTree();
            int[] value = { 1, 2, 3, 4, 5 };
            for (int i = 0; i < value.Length; i++)
                tree.Insert(value[i]);

            var tree2 = new LeetAVLBinaryTree();
            int[] value2 = { 5, 10, 3, 12, 15, 14 };
            for (int i = 0; i < value2.Length; i++)
                tree2.Insert(value2[i]);

            var tree3 = new LeetAVLBinaryTree();
            int[] value3 = { 12, 3, 9, 4, 6, 2 };
            for (int i = 0; i < value3.Length; i++)
                tree3.Insert(value3[i]);

            var perfectTree = new LeetAVLBinaryTree();
            int[] perfectValues = { 6, 4, 8, 1, 5, 7, 9 };
            for (int i = 0; i < perfectValues.Length; i++)
                perfectTree.Insert(perfectValues[i]);

            Console.WriteLine("Is Tree 2 a perfect node: " + tree2.IsPerfect());
            Console.WriteLine("Is Tree 3 a perfect node: " + tree3.IsPerfect());
            Console.WriteLine("Is Perfect Tree a perfect node: " + perfectTree.IsPerfect());
        }

        static void RunHeapClass()
        {
            var tree = new LeetHeap();
            int[] value = { 15, 10, 3, 8, 12, 9, 4, 1, 24 };
            for (int i = 0; i < value.Length; i++)
                tree.Insert(value[i]);
            tree.Remove();

            var tree2 = new LeetHeap();
            int[] value2 = { 10, 5, 17, 4, 22 };
            for (int i = 0; i < value2.Length; i++)
                tree2.Insert(value2[i]);
            tree2.Remove();

            var heap = new LeetHeap();
            int[] numbers = { 5, 3, 10, 1, 4, 2 };
            for (int i = 0; i < numbers.Length; i++)
                heap.Insert(numbers[i]);

            while (!heap.IsEmpty)
                Console.WriteLine(heap.Remove());

            int[] numbers2 = { 5, 3, 8, 4, 1, 2 };
            var result = heap.KthLargestNumber(numbers2, 0);
            Console.WriteLine("2nd Largest number in { 5, 3, 8, 4, 1, 2 } is " + result);

            var heap2 = new ArrayLeetHeap(numbers2, false);
            Console.WriteLine("Is Max Heap: " + heap2.IsMaxHeap());
        }

        static void RunTriesClass()
        {
            var tries = new LeetTries();
            tries.Insert("boy");
            tries.Insert("book");
            tries.Insert("border");
            tries.Insert("cat");

            var tries2 = new LeetTries();
            tries2.Insert("cat");
            tries2.Insert("can");
            tries2.Insert("canada");
            Console.WriteLine("Contains cat : " + tries2.Contains("cat"));
            Console.WriteLine("Contains canad : " + tries2.Contains("canad"));
            Console.WriteLine("Contains Empty String : " + tries2.Contains(String.Empty));
            Console.WriteLine("Contains Canada : " + tries2.Contains("Canada"));
            Console.WriteLine("Contains null : " + tries2.Contains(null));
            tries2.Print();
            Console.WriteLine("-----------------");

            var tries3 = new LeetTries();
            tries3.Insert("car");
            tries3.Insert("care");
            tries3.Print();
            Console.WriteLine("Removing car");
            tries3.Remove("car");
            tries3.Print();
            Console.WriteLine("Removing care");
            tries3.Remove("care");
            tries3.Print();
            Console.WriteLine("--------------");

            Console.WriteLine("--------------------Auto Complete-------------");
            var tries4 = new LeetTries();
            tries4.Insert("car");
            tries4.Insert("card");
            tries4.Insert("egg");
            tries4.Insert("care");
            tries4.Insert("careful");
            Console.WriteLine("Printing words in trie");
            tries4.Print();
            Console.WriteLine("Testing Now");

            var input1 = String.Empty;
            Console.WriteLine("Auto Complete Suggestions For '' : " + String.Join(',', tries4.AutoComplete(input1)));
            var input2 = "ca";
            Console.WriteLine("Auto Complete Suggestions For 'ca' : " + String.Join(',', tries4.AutoComplete(input2)));
            var input3 = "car";
            Console.WriteLine("Auto Complete Suggestions For 'car' : " + String.Join(',', tries4.AutoComplete(input3)));
            var input4 = "card";
            Console.WriteLine("Auto Complete Suggestions For 'card' : " + String.Join(',', tries4.AutoComplete(input4)));
            var input5 = "care";
            Console.WriteLine("Auto Complete Suggestions For 'care' : " + String.Join(',', tries4.AutoComplete(input5)));
            var input6 = "e";
            Console.WriteLine("Auto Complete Suggestions For 'e' : " + String.Join(',', tries4.AutoComplete(input6)));
            var input7 = "cargo";
            Console.WriteLine("Auto Complete Suggestions For 'cargo' : " + String.Join(',', tries4.AutoComplete(input7)));
            Console.WriteLine("--------------------------");
        }
    
        static void RunGraphClass()
        {
            var graph1 = new LeetGraphClass();
            graph1.AddNode("A");
            graph1.AddNode("B");
            graph1.AddNode("C");
            graph1.AddEdge("A", "B");
            //graph1.AddEdge("B", "A");
            graph1.AddEdge("A", "C");
            //graph1.RemoveEdge("A", "C");
            graph1.RemoveEdge("A", "D");
            graph1.RemoveNode("B");
            graph1.Print();

            var graph2 = new LeetGraphClass();
            graph2.AddNode("A");
            graph2.AddNode("B");
            graph2.AddNode("C");
            graph2.AddNode("D");
            graph2.AddNode("E");
            graph2.AddEdge("C", "A");
            graph2.AddEdge("C", "B");
            graph2.AddEdge("C", "D");
            graph2.AddEdge("D", "E");
            graph2.AddEdge("A", "B");
            graph2.AddEdge("A", "E");
            graph2.AddEdge("B", "E");
            Console.WriteLine("Breadth First Result C: " + String.Join(',', graph2.TraversePrint_BreadthFirst("C")));
            Console.WriteLine("Depth First Result C: " + String.Join(',', graph2.TraversePrint_DepthFirst("C")));

            var graph3 = new LeetGraphClass();
            graph3.AddNode("A");
            graph3.AddNode("B");
            graph3.AddNode("C");
            graph3.AddNode("D");
            graph3.AddEdge("A", "B");
            graph3.AddEdge("B", "D");
            graph3.AddEdge("D", "C");
            graph3.AddEdge("A", "C");
            Console.WriteLine("Depth First Result A: " + String.Join(',', graph3.TraversePrint_DepthFirst("A")));
            Console.WriteLine("Depth First Result C: " + String.Join(',', graph3.TraversePrint_DepthFirst("C")));
            Console.WriteLine("Depth First Result G: " + String.Join(',', graph3.TraversePrint_DepthFirst("G")));
            Console.WriteLine("Breadth First Result A: " + String.Join(',', graph3.TraversePrint_BreadthFirst("A")));
            Console.WriteLine("Breadth First Result C: " + String.Join(',', graph3.TraversePrint_BreadthFirst("C")));
            Console.WriteLine("Breadth First Result G: " + String.Join(',', graph3.TraversePrint_BreadthFirst("G")));

            var graph4 = new LeetGraphClass();
            graph4.AddNode("A");
            graph4.AddNode("B");
            graph4.AddNode("C");
            graph4.AddNode("D");
            graph4.AddEdge("A", "B");
            graph4.AddEdge("B", "C");
            graph4.AddEdge("A", "C");
            graph4.AddEdge("D", "A");
            Console.WriteLine("-------------------------");
            graph4.Print();
            Console.WriteLine("Do we detect cycle in graph: " + graph4.HasCycle());

            var graph5 = new LeetGraphClass();
            graph5.AddNode("A");
            graph5.AddNode("B");
            graph5.AddNode("C");
            graph5.AddNode("D");
            graph5.AddEdge("A", "B");
            graph5.AddEdge("B", "C");
            graph5.AddEdge("C", "A");
            graph5.AddEdge("D", "A");
            Console.WriteLine("-------------------------");
            graph5.Print();
            Console.WriteLine("Do we detect cycle in graph: " + graph5.HasCycle());
        }
    }
}
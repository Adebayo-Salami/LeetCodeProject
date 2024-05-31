using System.Text;

namespace LeetCodeProject.Problems
{
    public static class AddTwoNumbers
    {
        public static void Run()
        {
            Console.WriteLine("Running AddTwoNumbers Run");

            var input1 = LeetCodeAddTwoNumbers(CreateListNode([2, 4, 3]), CreateListNode([5, 6, 4]));
            Console.WriteLine("Result: " + ConvertNodeToString(input1));

            var input2 = LeetCodeAddTwoNumbers(CreateListNode([0]), CreateListNode([0]));
            Console.WriteLine("Result: " + ConvertNodeToString(input2));

            var input3 = LeetCodeAddTwoNumbers(CreateListNode([9, 9, 9, 9, 9, 9, 9]), CreateListNode([9, 9, 9, 9]));
            Console.WriteLine("Result: " + ConvertNodeToString(input3));

            var input4 = OptAddTwoNumbers(CreateListNode([1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1]), CreateListNode([5, 6, 4]));
            Console.WriteLine("Result: " + ConvertNodeToString(input4));
        }

        static ListNode CreateListNode(int[] arr)
        {
            var listNode = new ListNode(arr[0]);
            if(arr.Length > 1)
            {
                var nextNode = new ListNode(arr[1]);
                listNode.next = nextNode;
                for (int i = 2; i < arr.Length; i++)
                {
                    nextNode.next = new ListNode(arr[i]);
                    nextNode = nextNode.next;
                }
            }
            return listNode;
        }

        static ListNode OptAddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode();
            ListNode current = dummy;
            int carry = 0;

            while (l1 != null || l2 != null || carry > 0)
            {
                int sum = carry;
                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.next;
                }

                carry = sum / 10;
                current.next = new ListNode(sum % 10);
                current = current.next;
            }

            return dummy.next;
        }

        static ListNode LeetCodeAddTwoNumbers2(ListNode l1, ListNode l2)
        {
            var l1Str = Convert.ToDouble(ConvertNodeToString(l1));
            var l2Str = Convert.ToDouble(ConvertNodeToString(l2));
            var sum = l1Str + l2Str;
            //var startingNode = new ListNode(sum.)

            return null;
        }

        static ListNode LeetCodeAddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode();

            try
            {
                var l1Str = Convert.ToDouble(ReverseString(ConvertNodeToString(l1)));
                var l2Str = Convert.ToDouble(ReverseString(ConvertNodeToString(l2)));

                var sumUp = (l1Str + l2Str).ToString();
                sumUp = ReverseString(sumUp);
                result = new ListNode(Convert.ToInt32(sumUp[0].ToString()), (sumUp.Length > 1 ? new ListNode(Convert.ToInt32(sumUp[1].ToString())) : null));
                if(result.next != null && sumUp.Length > 2)
                {
                    var node = result.next;
                    int i = 2;
                    while(i < sumUp.Length)
                    {
                        node.next = new ListNode(Convert.ToInt32(sumUp[i].ToString()));
                        node = node.next;
                        i++;
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }

        static string ConvertNodeToString(ListNode listNode)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(listNode.val);
            while (listNode.next != null)
            {
                listNode = listNode.next;
                stringBuilder.Append(listNode.val);
            }

            return stringBuilder.ToString();
        }

        static string ReverseString(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = str.Length - 1; i >= 0; i--)
                stringBuilder.Append(str[i]);

            return stringBuilder.ToString();
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}

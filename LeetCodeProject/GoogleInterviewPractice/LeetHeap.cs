using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public class LeetHeap
    {
        private class TreeNode
        {
            private int _value { get; set; }
            private TreeNode? _left { get; set; }
            private TreeNode? _right { get; set; }

            public TreeNode(int value)
            {
                _value = value;
            }

            public int Value => _value;

            public TreeNode? Left => _left;

            public TreeNode? Right => _right;

            public void SetLeft(int value) => _left = new TreeNode(value);

            public void SetRight(int value) => _right = new TreeNode(value);

            public void SetLeftNode(TreeNode? node) => _left = node;

            public void SetRightNode(TreeNode? node) => _right = node;

            public void ClearRight() => _right = null;

            public void ClearLeft() => _left = null;

            public void SetValue(int value) => _value = value;

            public void MakeTreeNonBinarySearch()
            {
                _value = 20;
                _left = new TreeNode(10)
                {
                    _left = new TreeNode(6)
                    {
                        _left = new TreeNode(3),
                        _right = new TreeNode(8)
                    },
                    _right = new TreeNode(21)
                };
                _right = new TreeNode(30)
                {
                    _left = new TreeNode(4)
                };
            }
        }

        private enum HeapType
        {
            MaxHeap = 1,
            MinHeap
        }

        private enum ShortestSide
        {
            Left = 1,
            Right
        }

        private TreeNode? _tree;
        private HeapType _heapType;


        public LeetHeap()
        {
            _heapType = HeapType.MaxHeap;
        }

        public void Insert(int value)
        {
            if (_tree == null)
                _tree = new TreeNode(value);
            else
                Insert(_tree, value);
        }

        private void Insert(TreeNode node, int value)
        {
            var path = GetPath(node);
            if(path == ShortestSide.Left)
            {
                if (node.Left == null)
                {
                    if (value < node.Value)
                        node.SetLeft(value);
                    else
                    {
                        node.SetLeft(node.Value);
                        node.SetValue(value);
                    }
                }
                else
                    Insert(node.Left, value);

                if (node.Value < node.Left.Value)
                {
                    var temp = node.Left.Value;
                    node.Left.SetValue(node.Value);
                    node.SetValue(temp);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    if (value < node.Value)
                        node.SetRight(value);
                    else
                    {
                        node.SetRight(node.Value);
                        node.SetValue(value);
                    }
                }
                else
                    Insert(node.Right, value);

                if (node.Value < node.Right.Value)
                {
                    var temp = node.Right.Value;
                    node.Right.SetValue(node.Value);
                    node.SetValue(temp);
                }
            }
        }

        private ShortestSide GetPath(TreeNode node)
        {
            if (node.Left == null)
                return ShortestSide.Left;
            if (node.Right == null)
                return ShortestSide.Right;

            var leftHeight = Height(node.Left);
            var rightHeight = Height(node.Right);

            if (leftHeight > rightHeight)
            {
                if (IsComplete(node.Left, leftHeight - 1))
                    return ShortestSide.Right;
                else
                    return ShortestSide.Left;
            }
            else if(leftHeight == rightHeight)
            {
                if (IsComplete(node.Right, rightHeight - 1))
                    return ShortestSide.Left;
                else
                    return ShortestSide.Right;
            }

            // Should never reach here
            return ShortestSide.Left;
        }

        private int Height(TreeNode? node)
        {
            if (node == null)
                return -1;

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        private bool IsComplete(TreeNode? node, int height)
        {
            if (node == null)
                return false;

            if (height < 0)
                return node.Left == null && node.Right == null;

            if (height == 0)
                return node.Left != null && node.Right != null;

            return IsComplete(node.Left, height - 1) && IsComplete(node.Right, height - 1);
        }

        public int Remove()
        {
            if (_tree == null)
                throw new NullReferenceException();

            if (IsLeafNode(_tree))
            {
                int val = _tree.Value;
                _tree = null;
                return val;
            }

            return Remove(_tree);
        }

        private bool IsLeafNode(TreeNode node)
        {
            return node.Left == null && node.Right == null;
        }

        private int Remove(TreeNode node)  // Doesn't support removing when only one node exists on the tree
        {
            var val = node.Value;
            var lastNode = PluckLastNode(node, node, null, out var parentNode);
            if (parentNode?.Right == lastNode)
                parentNode.ClearRight();
            if (parentNode?.Left == lastNode)
                parentNode.ClearLeft();

            node.SetValue(lastNode.Value);
            ArrangeNode(node);
            return val;
        }

        private void ArrangeNode(TreeNode? node)
        {
            if (node == null)
                return;

            if(node.Left != null)
                if(node.Left.Value > node.Value)
                {
                    var temp = node.Value;
                    node.SetValue(node.Left.Value);
                    node.Left.SetValue(temp);
                    ArrangeNode(node.Left);
                }

            if(node.Right != null)
                if(node.Right.Value > node.Value)
                {
                    var temp = node.Value;
                    node.SetValue(node.Right.Value);
                    node.Right.SetValue(temp);
                    ArrangeNode(node.Right);
                }

        }

        private TreeNode GetLastNode(TreeNode? node, TreeNode lastNode)
        {
            if (node == null)
                return lastNode;

            var leftHeight = Height(node.Left);
            var rightHeight = Height(node.Right);
            if (leftHeight > rightHeight)
                return GetLastNode(node.Left, node);
            else if (leftHeight == rightHeight)
                return GetLastNode(node.Right, node);

            throw new Exception("Should never get here in a heap!");
        }

        private TreeNode PluckLastNode(TreeNode? node, TreeNode lastNode, TreeNode? pNode, out TreeNode? parentNode)
        {
            parentNode = pNode;
            if (node == null)
                return lastNode;

            var leftHeight = Height(node.Left);
            var rightHeight = Height(node.Right);
            
            if (leftHeight > rightHeight)
            {
                if (node.Left != null)
                    pNode = node;
                return PluckLastNode(node.Left, node, pNode, out parentNode);
            }
            else if (leftHeight == rightHeight)
            {
                if (node.Right != null)
                    pNode = node;
                return PluckLastNode(node.Right, node, pNode, out parentNode);
            }

            throw new Exception("Should never get here in a heap!");
        }

        public bool IsEmpty => _tree == null;

        public int KthLargestNumber(int[] array, int k)
        {
            int result = -1;
            if (k >= array.Length)
                return result;

            Heapify(array);
            for (int i = 0; i < k; i++)
                result = RemoveHeapify(array, out array);
            return result;
        }

        public void Heapify(int[] array)
        {
            for (int i = GetLastParentIndex(array.Length); i >= 0; i--)
                Heapify(array, i);
        }

        private void Heapify(int[] array, int index)
        {
            var largerIndex = index;
            var leftIndex = GetLeftChildIndex(index);
            if (leftIndex < array.Length)
                if (array[leftIndex] > array[index])
                    largerIndex = leftIndex;

            var rightChildIndex = GetRightChildIndex(index);
            if (rightChildIndex < array.Length)
                if (array[rightChildIndex] > array[index])
                    largerIndex = rightChildIndex;

            if (index == largerIndex)
                return;

            Swap(array, index, largerIndex);
            Heapify(array, largerIndex);
        }

        private int RemoveHeapify(int[] array, out int[] newArray)
        {
            int result = array[0];

            int lastValue = array[array.Length - 1];
            newArray = new int[array.Length - 1];
            newArray[0] = lastValue;
            for (int i = 1; i < array.Length - 1; i++)
                newArray[i] = array[i];

            Heapify(newArray, 0);
            return result;
        }

        private void Swap(int[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

        private int GetLeftChildIndex(int index) => (index * 2 + 1);

        private int GetRightChildIndex(int index) => (index * 2 + 2);

        private int GetLastParentIndex(int arraySize) => arraySize / 2 - 1;
    }
}

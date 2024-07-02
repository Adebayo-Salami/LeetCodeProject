using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public class LeetBinaryTree
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

        private TreeNode? _tree { get; set; }
        private int _size;
        public int Size => _size + 1;

        public LeetBinaryTree(int value)
        {
            _tree = new TreeNode(value);
        }

        public void Insert(int value)
        {
            if (_tree == null)
                _tree = new TreeNode(value);
            else
                InsertNode(_tree, value);

            _size++;
        }

        private void InsertNode(TreeNode node, int value)
        {
            if (value < node.Value)
            {
                if (node.Left == null)
                    node.SetLeft(value);
                else
                    InsertNode(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                    node.SetRight(value);
                else
                    InsertNode(node.Right, value);
            }
        }

        public bool Find(int value)
        {
            if (_tree == null)
                return false;
            if (_tree.Value == value)
                return true;

            return FindNode(_tree, value);
        }

        private bool FindNode(TreeNode tree, int value)
        {
            if (tree.Value == value)
                return true;

            if (value < tree.Value)
            {
                if (tree.Left != null)
                    return FindNode(tree.Left, value);
            }
            else
            {
                if (tree.Right != null)
                    return FindNode(tree.Right, value);
            }

            return false;
        }

        public void PrintBreadthFirst() // Same Level
        {
            for (var i = 0; i <= GetTreeHeight(); i++)
                PrintValuesAtDeptK(i);
        }

        public void PrintDepthFirstPreOrder()   // Root, Left, Right
        {
            if (_tree == null)
                return;

            TraverseDepthFirstPreOrder(_tree);
        }

        private void TraverseDepthFirstPreOrder(TreeNode tree)
        {
            Console.WriteLine(tree.Value);

            if (tree.Left != null)
                TraverseDepthFirstPreOrder(tree.Left);

            if (tree.Right != null)
                TraverseDepthFirstPreOrder(tree.Right);
        }

        public void PrintDepthFirstInOrder()   // Left, Root, Right
        {
            if (_tree == null)
                return;

            TraverseDepthFirstInOrder(_tree);
        }

        private void TraverseDepthFirstInOrder(TreeNode tree)
        {
            if (tree.Left != null)
                TraverseDepthFirstInOrder(tree.Left);

            Console.WriteLine(tree.Value);

            if (tree.Right != null)
                TraverseDepthFirstInOrder(tree.Right);
        }

        public void PrintDepthFirstPostOrder()   // Left, Right, Root
        {
            if (_tree == null)
                return;

            TraverseDepthFirstPostOrder(_tree);
        }

        private void TraverseDepthFirstPostOrder(TreeNode tree)
        {
            if (tree.Left != null)
                TraverseDepthFirstPostOrder(tree.Left);

            if (tree.Right != null)
                TraverseDepthFirstPostOrder(tree.Right);

            Console.WriteLine(tree.Value);
        }

        public int GetTreeHeight()
        {
            return TreeHeight(_tree);
        }

        private int TreeHeight(TreeNode? tree)
        {
            if (tree == null)
                return -1;

            if (IsLeafNode(tree))
                return 0;

            return 1 + Math.Max(TreeHeight(tree.Left), TreeHeight(tree.Right));
        }

        public int GetTreeMinimumValue()
        {
            return TreeMinimumValue(_tree);
        }

        private int TreeMinimumValue(TreeNode? tree)
        {
            if (tree == null)
                return int.MaxValue;

            if (IsLeafNode(tree))
                return tree.Value;

            var left = TreeMinimumValue(tree.Left);
            var right = TreeMinimumValue(tree.Right);
            return Math.Min(Math.Min(left, right), tree.Value);
        }

        private bool IsLeafNode(TreeNode node)
        {
            return node.Left == null && node.Right == null;
        }

        public bool IsEqual(LeetBinaryTree tree)
        {
            return IsTreeEqual(_tree, tree?._tree);
        }

        private bool IsTreeEqual(TreeNode? node, TreeNode? secondNode)
        {
            if (node == null && secondNode != null)
                return false;
            if (secondNode == null && node != null)
                return false;
            if (secondNode == null && node == null)
                return true;

            if (node.Value != secondNode.Value)
                return false;

            if (!IsTreeEqual(node.Left, secondNode.Left))
                return false;
            if (!IsTreeEqual(node.Right, secondNode.Right))
                return false;

            return true;
        }

        public void TestIsBinarySearchTree()
        {
            if (_tree == null)
                return;
            _tree.MakeTreeNonBinarySearch();
        }

        public bool IsBinarySearchTree()
        {
            return IsTreeBinarySearch(_tree, int.MaxValue, int.MinValue);
        }

        private bool IsTreeBinarySearch(TreeNode? node, int max, int min)
        {
            if (node == null)
                return true;

            if (node.Value <= min || node.Value >= max)
                return false;

            return IsTreeBinarySearch(node.Left, node.Value, min) && IsTreeBinarySearch(node.Right, max, node.Value);
        }

        public void PrintValuesAtDeptK(int k)
        {
            TraverseToDepthK(_tree, k);
        }

        private void TraverseToDepthK(TreeNode? node,  int depth)
        {
            if (node == null)
                return;

            if (depth == 0)
                Console.WriteLine(node.Value);
            else
            {
                depth--;
                TraverseToDepthK(node.Left, depth);
                TraverseToDepthK(node.Right, depth);
            }
        }

        public int CountLeaves()
        {
            return TraverseCountLeaves(_tree);
        }

        private int TraverseCountLeaves(TreeNode? node)
        {
            if (node == null)
                return 0;

            if (IsLeafNode(node))
                return 1;

            return TraverseCountLeaves(node.Left) + TraverseCountLeaves(node.Right);
        }

        public int Max()
        {
            if (_tree == null)
                return -1;

            return IsBinarySearchTree()
                ? TraverseMax_BinarySearchTree(_tree)
                : TraverseMax_BinaryTree(_tree, int.MinValue);
        }

        private int TraverseMax_BinaryTree(TreeNode? node, int maxValue)
        {
            if (node == null)
                return maxValue;

            if (node.Value > maxValue)
                maxValue = node.Value;

            maxValue = TraverseMax_BinaryTree(node.Left, maxValue);
            maxValue = TraverseMax_BinaryTree(node.Right, maxValue);
            return maxValue;
        }

        private int TraverseMax_BinarySearchTree(TreeNode node)
        {
            int maxValue = node.Value;
            if (node.Right != null)
                maxValue = TraverseMax_BinarySearchTree(node.Right);

            return maxValue;
        }

        public bool Contains(int value)
        {
            return TraverseContains(_tree, value);
        }

        private bool TraverseContains(TreeNode? node, int value)
        {
            if (node == null)
                return false;

            if (node.Value == value)
                return true;

            return TraverseContains(node.Left, value) || TraverseContains(node.Right, value);
        }

        public bool AreSiblings(int left, int right)
        {
            return TraverseAreSiblings(_tree, left, right);
        }

        private bool TraverseAreSiblings(TreeNode node, int left, int right)
        {
            if (node == null)
                return false;

            if (IsLeafNode(node))
                return false;

            if (node.Left == null || node.Right == null)
                return false;

            if (node.Left.Value == left && node.Right.Value == right)
                return true;

            return TraverseAreSiblings(node.Left, left, right) || TraverseAreSiblings(node.Right, left, right);
        }

        public List<int> GetAncestors(int value)
        {
            return TraverseAncestors(_tree, new List<int>(), value, out bool isFound);
        }

        private List<int> TraverseAncestors(TreeNode? node, List<int> ancestors, int value, out bool isFound)
        {
            isFound = false;
            if (node == null)
            {
                ancestors = new List<int>();
                return ancestors;
            }

            if (node.Value == value)
            {
                isFound = true;
                return ancestors;
            }

            if (IsLeafNode(node))
            {
                ancestors = new List<int>();
                return ancestors;
            }

            //ancestors.Add(node.Value);
            var leftAncestors = TraverseAncestors(node.Left, ancestors, value, out isFound);
            if (isFound)
            {
                leftAncestors.Add(node.Value);
                return leftAncestors;
            }

            var rightAncestors = TraverseAncestors(node.Right, ancestors, value, out isFound);
            if (isFound)
                rightAncestors.Add(node.Value);

            return rightAncestors;
        }

        private bool IsCousins(TreeNode root, int x, int y)
        {

            var q = new Queue<TreeNode>();
            q.Enqueue(root);


            var inLevel = new Dictionary<int, TreeNode>();


            //while (q.Count > 0)
            //{
            //    var size = q.Count();
            //    while (size > 0)
            //    {
            //        var node = q.Dequeue();
            //        if (node.left != null)
            //        {
            //            q.Enqueue(node.left);
            //            inLevel[node.left.val] = node;
            //        }
            //        if (node.right != null)
            //        {
            //            q.Enqueue(node.right);
            //            inLevel[node.right.val] = node;
            //        }
            //        size--;
            //    }
            //    if (inLevel.ContainsKey(x) && inLevel.ContainsKey(y) &&
            //       inLevel[x] != inLevel[y])
            //    {
            //        return true;
            //    }
            //    inLevel.Clear();
            //}


            return false;
        }
    }
}

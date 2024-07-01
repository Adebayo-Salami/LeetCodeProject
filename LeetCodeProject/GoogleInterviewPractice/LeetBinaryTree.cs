using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        private TreeNode? _tree { get; set; }

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
            if (_tree == null)
                return;

            TraverseBreadthFirst(_tree);
        }

        private void TraverseBreadthFirst(TreeNode tree)
        {
            Console.WriteLine(tree.Value);

            if (tree.Left != null)
                TraverseBreadthFirst(tree.Left);

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
    }
}

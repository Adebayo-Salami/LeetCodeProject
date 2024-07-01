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
    }
}

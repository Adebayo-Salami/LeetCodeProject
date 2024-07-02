using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public class LeetAVLBinaryTree
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

        public LeetAVLBinaryTree()
        {

        }

        public void Insert(int value)
        {
            if (_tree == null)
                _tree = new TreeNode(value);
            else
                Insert(_tree, value);

            _tree = BalanceTree(_tree, out bool isSkewed);
        }

        private void Insert(TreeNode node, int value)
        {
            if(value < node.Value)
            {
                if (node.Left == null)
                    node.SetLeft(value);
                else
                    Insert(node.Left, value);
            }
            else
            {
                if (node.Right == null)
                    node.SetRight(value);
                else
                    Insert(node.Right, value);
            }
        }

        private TreeNode? BalanceTree(TreeNode? node, out bool isSkewed)
        {
            isSkewed = false;
            if (node == null)
                return node;

            var balanceFactor = Height(node?.Left) - Height(node?.Right);
            if (balanceFactor >= -1 && balanceFactor <= 1)
                return node;

            node?.SetRightNode(BalanceTree(node?.Right, out isSkewed));
            node?.SetLeftNode(BalanceTree(node?.Left, out isSkewed));

            balanceFactor = Height(node?.Left) - Height(node?.Right);
            if (balanceFactor >= -1 && balanceFactor <= 1)
                return node;

            if (balanceFactor < 1)   // Left Side is lacking
            {
                if (!isSkewed)
                {
                    var nextRightNode = node?.Right;
                    node?.ClearRight();
                    nextRightNode?.SetLeftNode(node);
                    node = nextRightNode;
                }
            }
            else // Right Side is lacking
            {
                if (!isSkewed)
                {
                    var nextLeftNode = node?.Left;
                    node?.ClearLeft();
                    nextLeftNode?.SetRightNode(node);
                    node = nextLeftNode;
                }
                
            }
            return node;
        }

        private int Height(TreeNode? node)
        {
            if (node == null)
                return -1;

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }
    }
}

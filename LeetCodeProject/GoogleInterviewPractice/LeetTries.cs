using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public class LeetTries
    {
        private class LeetTriesNode
        {
            public char Value { get; set; }
            public bool IsEndOfWord { get; set; }
            public Dictionary<char, LeetTriesNode> Children { get; set; }

            public LeetTriesNode(char value, bool isEndOfWord = false)
            {
                Value = value;
                IsEndOfWord = isEndOfWord;
                Children = new Dictionary<char, LeetTriesNode>();
            }

            public int Size => Children.Count;
        }

        private LeetTriesNode _root;

        public LeetTries()
        {
            _root = new LeetTriesNode(' ');
        }

        public void Insert(string word)
        {
            Insert(_root, word.Trim().ToUpper().ToCharArray(), 0);
        }

        private void Insert(LeetTriesNode node, char[] word, int index)
        {
            if (word.Length == 0)
                return;

            if (index >= word.Length)
                return;

            bool isEndOfWord = index == (word.Length - 1);
            char letter = word[index];
            node.Children.TryGetValue(letter, out LeetTriesNode? item);
            if (item == null)
            {
                node.Children.Add(letter, new LeetTriesNode(letter, isEndOfWord));
                Insert(node.Children[letter], word, ++index);
            }
            else
            {
                if (isEndOfWord) item.IsEndOfWord = true;
                Insert(item, word, ++index);
            }
        }
    }
}

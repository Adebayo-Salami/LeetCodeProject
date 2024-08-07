﻿using System;
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

            public LeetTriesNode? GetChild(char c)
            {
                Children.TryGetValue(c, out LeetTriesNode? child);
                return child;
            }
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

        public bool Contains(string word)
        {
            if (String.IsNullOrWhiteSpace(word))
                return false;
            return Contains(_root, word.Trim().ToUpper().ToCharArray(), 0);
        }

        private bool Contains(LeetTriesNode node, char[] word, int index)
        {
            if (word.Length == 0)
                return false;

            if (index >= word.Length)
                return false;

            bool isEndOfWord = index == (word.Length - 1);
            char letter = word[index];
            node.Children.TryGetValue(letter, out LeetTriesNode? item);
            if (item == null)
                return false;
            else
            {
                if (isEndOfWord && item.IsEndOfWord) return true;
                return Contains(item, word, ++index);
            }
        }

        public void Print()
        {
            Print(_root, "");
        }

        private void Print(LeetTriesNode node, string word)
        {
            if (node == null)
                return;

            word = word + node.Value;
            if (node.IsEndOfWord)
                Console.WriteLine("Word found: " + word);

            foreach (var child in node.Children.Values)
                Print(child, word);
        }

        public void Remove(string word)
        {
            if (String.IsNullOrWhiteSpace(word))
                return;

            Remove(_root, word.Trim().ToUpper().ToCharArray(), 0);
        }

        private bool Remove(LeetTriesNode node, char[] word, int index)
        {
            if (node == null)
                return false;

            if (index >= word.Length)
                return false;

            bool isEndOfWord = index == (word.Length - 1);
            char letter = word[index];
            node.Children.TryGetValue(letter, out LeetTriesNode? item);
            if (item == null)
                return false;
            else
            {
                if (isEndOfWord)
                {
                    if (!item.IsEndOfWord)
                        return false;

                    item.IsEndOfWord = false;
                    return !item.Children.Any();
                }
                bool cleanUp = Remove(item, word, ++index);
                if (cleanUp)
                    item.Children.Remove(word[index]);
                if (node == _root && cleanUp)
                    node.Children.Remove(letter);
            }

            return !item.Children.Any();
        }

        public List<string> AutoComplete(string word)
        {
            if (String.IsNullOrWhiteSpace(word))
                return new List<string>();

            List<string> autoCompletedWords = new();
            var wordChar = word.Trim().ToUpper().ToCharArray();
            var nodeChild = _root.GetChild(wordChar[0]);
            if (nodeChild != null)
                AutoComplete(nodeChild, wordChar, 0, autoCompletedWords, "");

            return autoCompletedWords;
        }

        private List<String> AutoComplete(LeetTriesNode node, char[] words,int index, List<string> autoCompletedWords, string word)
        {
            if (node == null)
                return autoCompletedWords;

            char letter = node.Value;
            word = word + letter;
            if(index < (words.Length - 1))
            {
                char wordLetter = words[index];
                if (wordLetter == letter)
                {
                    char nextWordLetter = words[index + 1];
                    var nextNode = node.GetChild(nextWordLetter);
                    if (nextNode != null)
                        return AutoComplete(nextNode, words, ++index, autoCompletedWords, word);
                    else
                        return autoCompletedWords;
                }
                else
                    return autoCompletedWords;
            }
            else
            {
                if (node.IsEndOfWord)
                    autoCompletedWords.Add(word);

                foreach (var child in node.Children.Values)
                    AutoComplete(child, [], 0, autoCompletedWords, word);
            }

            return autoCompletedWords;
        }
    }
}

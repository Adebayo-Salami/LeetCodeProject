using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public static class LeetStack
    {
        private static Dictionary<char, char> _characterPairs = new()
        {
            //{ '{', '}'},
            ['{'] = '}',
            ['['] = ']',
            ['('] = ')',
            ['<'] = '>',
        };

        public static bool IsBalancedEpression(string word)
        {
            var wordChars = word.ToCharArray();
            var wordStack = new Stack<char>();
            foreach (char ch in wordChars)
            {
                if (_characterPairs.ContainsKey(ch))
                    wordStack.Push(ch);
                if (_characterPairs.ContainsValue(ch))
                {
                    if (wordStack.Count == 0) return false;
                    var openingChar = wordStack.Pop();
                    if (_characterPairs[openingChar] != ch)
                        return false;
                }
            }

            return wordStack.Count == 0;
        }
    }

    public class LeetStack2
    {
        private Queue<int> _queue1 = new();
        private Queue<int> _queue2 = new();
        private int _size = 0;
        private int _lastItem;

        public LeetStack2()
        {
        }

        public void Push(int item)
        {
            _queue1.Enqueue(item);
            _lastItem = item;
            _size++;
        }

        public void Pop()
        {
            for(int i = 1; i < _size; i++)
            {
                _lastItem = _queue1.Dequeue();
                _queue2.Enqueue(_lastItem);
            }
            _queue1.Dequeue();
            while (_queue2.Count > 0)
                _queue1.Enqueue(_queue2.Dequeue());

            _size--;
        }

        public int Peek => _lastItem;

        public int Size => _size;

        public bool IsEmpty => _size == 0;

    }
}

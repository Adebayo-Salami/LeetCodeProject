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

    }
}

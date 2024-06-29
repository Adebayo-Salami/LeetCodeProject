using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public static class LeetDictionary
    {
        public static void FirstNonRepeatingChar(string word)
        {
            var wordChars = word.ToCharArray();
            var dictionary = new Dictionary<char, int>();
            char? nonRepeatingChar = null;
            foreach (char c in wordChars)
            {
                if (c == ' ') continue;
                if(!dictionary.TryAdd(c, 1))
                    dictionary[c] = dictionary[c] + 1;
            }
            foreach (var item in dictionary)
                if(item.Value == 1)
                {
                    nonRepeatingChar = item.Key;
                    break;
                }

            Console.WriteLine("First non-repeating char in " + word + " is " + (nonRepeatingChar ?? char.MinValue));
        }
        
        public static void FirstRepeatedChar(string word)
        {
            var wordChars = word.ToCharArray();
            var dictSet = new HashSet<char>();
            foreach(char c in wordChars)
            {
                if (c == ' ') continue;
                if (!dictSet.Add(c))
                {
                    Console.WriteLine("First repeating char in " + word + " is " + c);
                    break;
                }
            }
        }

        public static int FindMostFrequentValue(int[] numbers)
        {
            var dict = new Dictionary<int, int>();
            int mostFrequent = -1;
            for(int i = 0; i < numbers.Length; i++)
            {
                if(!dict.TryAdd(numbers[i], 1))
                {
                    dict[numbers[i]] = dict[numbers[i]] + 1;
                }

                if (dict[numbers[i]] > mostFrequent)
                    mostFrequent = numbers[i];
            }

            return mostFrequent;
        }

        public static int FindNumberOfPairsWithKthDiff(int[] numbers, int k)
        {
            int count = 0;
            var dict = new HashSet<int>();
            for (int i = 0; i < numbers.Length; i++)
                dict.Add(numbers[i]);

            foreach (var pair in dict)
                if (dict.Contains(pair + 2))
                    count++;

            return count;
        }

        public static int[] FindTwoSum(int[] numbers, int k)
        {
            var dict = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < numbers.Length; i++)
                if (!dict.TryAdd(numbers[i], new HashSet<int>() { i }))
                    dict[numbers[i]].Add(i);

            foreach (var pair in dict)
            {
                var partner = k - pair.Key;
                var pairIndex = pair.Value.First();
                var partnerPair = dict.FirstOrDefault(x => x.Key == partner);
                if (partnerPair.Value != null)
                    if (partnerPair.Value.Any(x => x != pairIndex))
                        return [pairIndex, partnerPair.Value.FirstOrDefault(x => x != pairIndex)];
            }

            return [];
        }
    }

    public class LeetHashTable
    {
        private class HashValueEntry
        {
            private int _key;
            private string _value;

            public HashValueEntry(int key, string value)
            {
                _key = key;
                _value = value;
            }

            public int Key => _key;
            public string Value => _value;
            public void SetValue(string value) => _value = value;
        }

        private LinkedList<HashValueEntry>[] _array = new LinkedList<HashValueEntry>[5];

        public LeetHashTable() { }

        private int HashFunction(int key) => key % _array.Length;

        public void Put(int key, string value)
        {
            key = Math.Abs(key);
            int index = HashFunction(key);
            
            if (_array[index] == null)
                _array[index] = new LinkedList<HashValueEntry>();

            var list = _array[index];
            var item = list.FirstOrDefault(x => x.Key == key);
            if (item != null)
            {
                item.SetValue(value);
                return;
            }

            list.AddLast(new HashValueEntry(key, value));
        }

        public string Get(int key)
        {
            key = Math.Abs(key);
            int index = HashFunction(key);
            var list = _array[index];
            if (list != null)
                return list.FirstOrDefault(x => x.Key == key)?.Value ?? String.Empty;

            return String.Empty;
        }

        public void Remove(int key)
        {
            key = Math.Abs(key);
            int index = HashFunction(key);
            var list = _array[index];
            if (list == null)
                throw new InvalidOperationException();

            var item = list.FirstOrDefault(x => x.Key == key);
            if (item != null)
                list.Remove(item);
        }

        public string GetMostFrequentValue()
        {


            return String.Empty;
        }

    }

    public class LeetHashTableProbing   // Linear Probing Strategy For Handling Collision
    {
        private string[] _array = new string[5];
        private int _size = 0;

        public LeetHashTableProbing() { }

        private int HashFunction(int key) => key % _array.Length;

        public void Put(int key, string value)
        {
            if (_size == _array.Length)
                throw new Exception("Table is Full");
            key = Math.Abs(key);
            int index = HashFunction(key);

            if (_array[index] == null)
                _array[index] = value;
            else
            {
                int i = index;
                while (_array[i] != null)
                    if ((i + 1) >= _array.Length)
                        i = (i + 1) % _array.Length;
                    else
                        i++;
                _array[i] = value;
            }

            _size++;
        }

        public string Get(int key) => _array[HashFunction(Math.Abs(key))];

        public void Remove(int key) => _array[HashFunction(Math.Abs(key))] = null;

        public int Size => _size;
    }
}

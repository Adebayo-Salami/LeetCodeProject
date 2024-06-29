using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public class LeetQueue
    {
        private int[] _array = new int[5];
        private int _count = 0;

        public LeetQueue() 
        {
            
        }

        public void Enqueue(int item)
        {
            if (IsFull())
                throw new Exception("Queue is Full");

            _array[_count++] = item;
        }

        public void Reverse(int k)
        {
            for(int i = 0, j = (k - 1); i < k; i++, j--)
            {
                var temp = _array[i];
                _array[i] = _array[j];
                _array[j] = temp;
                if (i == j)
                    break;
            }
        }

        public void Print()
        {
            Console.WriteLine("Printing Items In Queue");
            for (int i = 0; i < _count; i++)
                Console.WriteLine(_array[i]);
            Console.WriteLine("End Printing");
        }

        public bool IsFull()
        {
            return _count == _array.Length;
        }
        
    }

    public class LeetQueue2
    {
        private class LeetQueueNode
        {
            private int _value;
            private LeetQueueNode? _next;
            private LeetQueueNode? _prev;

            public LeetQueueNode(int value)
            {
                _value = value;
            }

            public int Value => _value;

            public LeetQueueNode? Next => _next;

            public LeetQueueNode? Prev => _prev;

            public void AddNext(LeetQueueNode? item) => _next = item;
            public void AddPrev(LeetQueueNode? item) => _prev = item;
        }

        private LeetQueueNode? _first;
        private LeetQueueNode? _last;
        private int _size;

        public LeetQueue2() { }

        public int Size => _size;

        public bool IsEmpty => _size == 0;

        public int Peek => _last?.Value ?? throw new NullReferenceException();

        public void Enqueue(int item)
        {
            if (IsEmpty)
                _first = _last = new LeetQueueNode(item);
            else
            {
                var next = new LeetQueueNode(item);
                _last?.AddNext(next);
                next.AddPrev(_last);
                _last = next;

            }
            _size++;
        }

        public void Dequeue()
        {
            if (IsEmpty)
                return;

            _last = _last?.Prev;
            _last?.AddNext(null);

            _size--;
        }

        public void Print()
        {
            Console.WriteLine("Printing values in the queue");
            var current = _first;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
            Console.WriteLine("Done priniting");
        }
    }
}

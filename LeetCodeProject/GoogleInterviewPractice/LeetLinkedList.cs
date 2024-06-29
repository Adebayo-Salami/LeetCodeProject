﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public class LeetLinkedList
    {
        private LeetNode? _first;
        private LeetNode? _last;
        private int _size = 0;
        public int Size => _size;

        public LeetLinkedList() 
        {
            
        }

        public void AddFirst(int value)
        {
            if (_first == null)
                _first = new LeetNode(value);
            else
            {
                var prevFirst = _first;
                _first = new LeetNode(value);
                _first.SetNext(prevFirst);
            }

            if (_last == null)
                _last = _first;

            _size++;
        }

        public void AddLast(int value)
        {
            if( _last == null)
                _last = new LeetNode(value);
            else
            {
                _last.SetNext(new LeetNode(value));
                _last = _last.Next;
            }

            if (_first == null)
                _first = _last;

            _size++;
        }

        public void DeleteFirst()
        {
            if (_first == null)
                throw new Exception("Empty List");

            var nextFirst = _first.Next;
            if (_last == _first)
                _last = nextFirst;
            _first.ClearNext();
            _first = nextFirst;

            _size--;
        }

        public void DeleteLast()
        {
            if (_first == null)
                throw new Exception("Empty List");

            if (_first == _last)
                _first = _last = null;
            else
            {
                var current = _first;
                while (current.Next != _last)
                    current = current.Next;

                _last = current;
                _last.ClearNext();
            }

            _size--;
        }

        public bool Contains(int value)
        {
            var current = _first;
            while (current != null)
            {
                if (current.Value == value) return true;
                current = current.Next;
            }

            return false;
        }

        public int IndexOf(int value) 
        {
            int index = 0;
            var current = _first;
            while(current != null)
            {
                if (current.Value == value)
                    return index;

                current = current.Next;
                index++;
            }

            return -1;
        }

        public int[] ToArray()
        {
            int[] array = new int[_size];

            var current = _first;
            int i = 0;
            while (current != null) 
            {
                array[i++] = current.Value;
                current = current.Next;
            }

            return array;
        }

        public void Print()
        {
            Console.WriteLine("Printing Values In Linked List");
            var current = _first;
            while(current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
            Console.WriteLine("Done Printing Values In Linked List");
        }
    }

    public class LeetNode
    {
        private int _value;
        private LeetNode? _next;

        public LeetNode(int value) 
        {
            _value = value;
        }

        public int Value => _value;

        public void SetNext(LeetNode next) => _next = next;

        public LeetNode? Next => _next;

        public void ClearNext() => _next = null;
    }
}

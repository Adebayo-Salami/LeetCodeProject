using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.GoogleInterviewPractice
{
    public class LeetArray
    {
        public int _count = 0;
        int[] _array;

        public LeetArray(int size) 
        {
            _array = new int[size];
        }

        public void Insert(int value)
        {
            if (_count == _array.Length)
                Resize();

            _array[_count++] = value;
        }

        public void RemoveAt(int index) 
        {
            if (index >= _count || index < 0)
                throw new IndexOutOfRangeException();

            for (int i = index; i < (_count - 1); i++)
                _array[i] = _array[i + 1];

            _count--;
        }

        private void Resize()
        {
            if(_count == _array.Length)
            {
                int[] resizedArray = new int[_array.Length * 2];
                for (int i = 0; i < _array.Length; i++)
                    resizedArray[i] = _array[i];
                _array = resizedArray;
            }
        }

        public void Print()
        {
            for (int i = 0; i < _count; ++i)
                Console.WriteLine(_array[i]);
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _count; i++)
                if (_array[i] == item)
                    return i;

            return -1;
        }

        public int ValueOf(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            return _array[index];
        }

        public int Max()
        {
            int max = _array[0];

            for (int i = 0; i < _count; i++)
                if (_array[i] > max)
                    max = _array[i];

            return max;
        }

        public LeetArray Intersect(LeetArray array)
        {
            int smallestSize = _count > array._count ? array._count : _count;
            LeetArray newArray = new LeetArray(smallestSize);

            for (int i = 0; i < array._count; i++)
                if (IndexOf(array.ValueOf(i)) != -1)
                    newArray.Insert(array.ValueOf(i));

            return newArray;
        }

        public void Reverse()
        {
            int[] reversedArray = new int[_count];
            for (int i = (_count - 1), j = 0; i >= 0; i--)
                reversedArray[j++] = _array[i];
            _array = reversedArray;
        }

        public void InsertAt(int item, int index)
        {
            if (index >= _count || index < 0)
                throw new IndexOutOfRangeException();

            if ((_count + 1) > _array.Length)
                Resize();

            for (int i = _count; i >= index; i--)
                if (i == index)
                    _array[i] = item;
                else
                    _array[i] = _array[i - 1];
            _count++;
        }
    }
}

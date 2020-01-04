using System;
using System.Collections;

namespace ArrayTest1
{
    class Array : IArray, IEnumerable
    {
        private object[] _array;
        private const int GROW = 5;

        public Array()
        {
            _array = new object[GROW];
        }

        public void ShiftItems(int indexFrom)
        {
            if (indexFrom >= Length)
            {
                ResizeArray(ref _array, GROW);

            }
            if (_array[indexFrom] != null)
            {
                for (int i = Length - 1; i >= indexFrom; i--)
                {
                    _array[i] = _array[i - 1];

                }
                _array[indexFrom] = null;
            }

        }

        public void Insert(object value, int position)
        {

            if (position < 0) throw new ArgumentOutOfRangeException("position", "Parametr musí být kladné číslo.");

            if (position >= Length) ResizeArray(ref _array, position + GROW);

            if (Get(position) != null) ShiftItems(position);

            _array[position] = value;

        }

        private static void ResizeArray(ref object[] oldArray, int newSize)
        {
            if (newSize <= 0) throw new ArgumentOutOfRangeException("newSize", "Parametr musí být kladné číslo.");

            object[] newArr = new object[newSize];
            for (int i = 0; i < Math.Min(oldArray.Length, newArr.Length); i++)
            {
                newArr[i] = oldArray[i];
            }
            oldArray = newArr;
        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (var item in _array)
                {
                    if (!(item is null)) count++;
                }
                return count;
            }
        }

        public int Length => _array.Length;

        private static int GetFirstIndexOfNull(object[] array, int fromIndex = 0)
        {
            for (int i = fromIndex; i < array.Length; i++)
            {
                if (array[i] is null) return i;
            }
            return -1;
        }

        public object Get(int position)
        {
            return _array[position];
        }

        public object[] GetAll()
        {
            object[] result = new object[Count];
            int i = 0;
            foreach (var item in this)
            {
                result[i++] = item;
            }
            return result;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in _array)
            {
                yield return item;
            }
        }

        public void Add(object value)
        {
            int insertPosition = GetFirstIndexOfNull(_array);
            if (insertPosition == -1) insertPosition = Length;
            Insert(value, insertPosition);
        }

        public bool Delete(object value)
        {
            bool result = false;

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].Equals(value))
                {
                    result = true;
                    _array[i] = null;
                }
            }

            return result;
        }

        public void Delete(int position)
        {
            if (position < 0 || position >= Length) return;

            _array[position] = null;
        }
    }
}

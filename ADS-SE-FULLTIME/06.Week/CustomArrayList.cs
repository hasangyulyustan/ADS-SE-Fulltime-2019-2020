using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Week
{
    public class CustomArrayList
    {

        private object[] arr;

        private int count;

        public int Count
        {
            get
            {
                return count;
            }
        }

        private static readonly int INITIAL_CAPACITY = 4;

        public CustomArrayList()
        {
            arr = new object[INITIAL_CAPACITY];
            count = 0;
        }

        public void Add(object item)
        {
            Insert(count, item);
        }

        public void Insert(int index, object item)
        {
            if (index > count || index < 0)
            {
                throw new IndexOutOfRangeException("Invalid index: " + index);
            }

            object[] extendedArr = arr;

            if (count + 1 == arr.Length)
            {
                extendedArr = new object[arr.Length * 2];
            }

            Array.Copy(arr, extendedArr, index);
            count++;
            Array.Copy(arr, index, extendedArr, index + 1, count - index - 1);
            extendedArr[index] = item;
            arr = extendedArr;
        }

        public int IndexOf(object item)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (item == arr[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public void Clear()
        {
            arr = new object[INITIAL_CAPACITY];
            count = 0;
        }


        public bool Contains(object item)
        {
            int index = IndexOf(item);
            bool found = (index != -1);
            return found;
        }


        public object this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }

                return arr[index];
            }

            set
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }

                arr[index] = value;
            }
        }

        public object Remove(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }

            object item = arr[index];
            Array.Copy(arr, index + 1, arr, index, count - index + 1);
            arr[count - 1] = null;
            count--;

            return item;
        }

        public int Remove(object item)
        {
            int index = IndexOf(item);

            if (index == -1)
            {
                return index;
            }

            Array.Copy(arr, index + 1, arr, index, count - index + 1);
            count--;

            return index;
        }
    }

    public class ArrayList<T>
    {
        private const int DefaultCapacity = 2;

        private T[] data;

        public ArrayList()
        {
            this.data = new T[DefaultCapacity];
        }

        public ArrayList(T[] data)
        {
            this.data = data;
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.data[index];
            }

            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.data[index] = value;
            }
        }

        public void Add(T item)
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }

            this.data[Count++] = item;
        }

        public T RemoveAt(int index)
        {
            if (this.Count < this.data.Length / 4)
            {
                this.Resize();
            }

            var removedElement = this[index];

            this.Count--;

            for (int i = index; i < this.Count; i++)
            {
                this.data[i] = this.data[i + 1];
            }

            return removedElement;
        }

        private void Resize()
        {
            Array.Resize(ref this.data, this.Count * 2);
        }
    }
}

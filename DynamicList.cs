using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListProject
{
    class DynamicList<T> : IEnumerable<T>
    {

        private int count;
        private int increment;
        private T[] array;

        public DynamicList()
        {

            count = 0;
            array = new T[10];
            increment = 10;

        }      
        
        public DynamicList(T[] arr)
        {
            count = arr.Length;
            array = arr;
            increment = 10;
        }

        public DynamicList(int capacity)
        {

            if(capacity < 0)
            {
                throw new ArgumentException("List size cannot be set less than zero");
            }

            count = 0;
            array = new T[capacity];
            increment = 10;
        }

        public DynamicList(int capacity, int increment)
        {

            if (capacity < 0)
            {
                throw new ArgumentException("List size cannot be set less than zero");
            }

            if(increment <= 0)
            {
                throw new ArgumentException("Increment must be set greater than 0");
            }

            count = 0;
            array = new T[capacity];
            this.increment = increment;
        }

        public int Count { get => count; }

        public void Add(T element)
        {
            if(count >= array.Length)
            {
                T[] arr = new T[array.Length + increment];
                Array.Copy(array, 0, arr, 0, array.Length);
                array = arr;
            }

            array[count] = element;
            count++;
        }

        public T this[int index]
        {            
            get 
            { 
                if(index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException("Index out of bounds of list");
                }
                return array[index]; 
            }
            set 
            {
                if (index < 0 || index >= count)
                {
                    throw new ArgumentOutOfRangeException("Index out of bounds of list");
                }
                array[index] = value; 
            }
        }

        public bool Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException("Index out of bounds of list");
            }            

            if(index == count - 1)
            {
                count--;
                return true;
            }

            T[] arr = new T[array.Length - 1];

            if(index == 0)
            {
                Array.Copy(array, 1, arr, 0, count - 1);
            }
            else
            {
                Array.Copy(array, 0, arr, 0, index);
                Array.Copy(array, index + 1, arr, index, count - 1 - index);
            }

            array = arr;
            count--;

            return true;
            
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if(index == -1)
            {
                return false;
            }

            return Remove(index);
        }

        public bool Contains(T item)
        {
            for(int i = 0; i < count; i++)
            {
                if (item.Equals(array[i]))
                {                    
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            if (!Contains(item))
            {
                return -1;
            }

            for(int i = 0; i < count; i++)
            {
                if (array[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Clear()
        {
            array = new T[10];
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < count; i++){
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}

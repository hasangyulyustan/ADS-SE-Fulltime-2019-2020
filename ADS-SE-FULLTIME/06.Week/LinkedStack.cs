using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Week
{

    public class Node<T>
    {
        public Node(T value, Node<T> nextNode = null)
        {
            this.Value = value;
            this.NextNode = nextNode;
        }

        public Node<T> NextNode { get; set; }

        public T Value { get; set; }
    }
    public class LinkedStack<T>
    {
        private Node<T> firstNode;

        public int Count { get; private set; }

        public void Push(T element)
        {
            this.firstNode = new Node<T>(element, this.firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var removedNode = this.firstNode;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;

            return removedNode.Value;
        }

        public T[] ToArray()
        {
            var currentNode = this.firstNode;

            var array = new T[this.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return array;
        }

    }
}

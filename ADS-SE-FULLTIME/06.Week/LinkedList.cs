using System;
namespace _06.Week
{
    public class LinkedListNode<T>
    {
        /// Елемент
        private T element;
        public T Element
        {
            get { return this.element; }
            set { this.element = value; }
        }

        /// Следващ елемент
        private LinkedListNode<T> next;
        public LinkedListNode<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }


        /// Конструктор
        public LinkedListNode(T element, LinkedListNode<T> prevLinkedListNode)
        {
            this.element = element;
            prevLinkedListNode.next = this;
        }

        /// Конструктор
        public LinkedListNode(T element)
        {
            this.element = element;
            next = null;
        }
    }

    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;

        // Конструктор
        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        /// Брой
        private int count;
        public int Count
        {
            get { return this.count; }
            private set { this.count = value; }
        }

        /// Добавяне
        public void Add(T item)
        {
            if (this.head == null)
            {
                // Първи елемент
                LinkedListNode<T> next = new LinkedListNode<T>(item);
                this.head = next;
                this.tail = next;
            }
            else
            {
                // Всеки следващ елемент
                LinkedListNode<T> next = new LinkedListNode<T>(item, tail);
                this.tail = next;
            }
            this.count++;
        }


        /// Връщане на индекс на елемент
        public int IndexOf(T item)
        {
            LinkedListNode<T> current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Element.Equals(item)) return index;
                index++;
                current = current.Next;
            }
            return -1; // Not Found
        }


        /// Премахване
        public T RemoveAt(int index)
        {
            T item = default(T);
            LinkedListNode<T> current = head;
            LinkedListNode<T> previous = null;
            int i = 0;
            while (current != null)
            {
                if (index == i)
                {
                    item = current.Element;
                    previous.Next = current.Next;
                    break;
                }
                i++;
                previous = current;
                current = current.Next;
            }
            return item;
        }


        /// Премахване
        public int Remove(T item)
        {
            int index = 0;
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if (current.Element.Equals(item))
                {
                    RemoveAt(index);
                    return index;
                }
                index++;
                current = current.Next;
            }
            return -1; // Not Found
        }


        /// Съдържа ли се
        public bool Contains(T item)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if (current.Element.Equals(item)) return true;
                current = current.Next;
            }
            return false;
        }

        // Достъпване до елементите
        public T this[int index]
        {
            get
            {
                LinkedListNode<T> current = head;
                int i = 0;
                while (current != null)
                {
                    if (i == index)
                    {
                        return current.Element;
                    }
                    i++;
                    current = current.Next;
                }
                return default(T); // Not Found
            }
            set
            {
                LinkedListNode<T> current = head;
                int i = 0;
                while (current != null)
                {
                    if (i == index)
                    {
                        current.Element = value;
                        break;
                    }
                    i++;
                    current = current.Next;
                }
            }
        }
    }
}

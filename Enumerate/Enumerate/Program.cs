using System;

namespace Enumerate
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = PrepareDummyList();
            var nodes = list.GetEnumerator();
            foreach(var node in nodes)
            {
                Console.WriteLine(node);
            }
           
        }

        static LinkedList<string> PrepareDummyList()
        {
            LinkedList<string> list = new LinkedList<string>();

            // list -> null
            LinkedListNode<string> node1 = new LinkedListNode<string>("Value-1");
            list.Head = node1;
            list.Count++;

            // list -> Value-1
            LinkedListNode<string> node2 = new LinkedListNode<string>("Value-2");
            node1.Next = node2;
            list.Count++;

            // list -> Value-1 -> Value-2
            LinkedListNode<string> node3 = new LinkedListNode<string>("Value-3");
            node2.Next = node3;
            list.Count++;

            // list -> Value-1 -> Value-2 -> Value-3
            LinkedListNode<string> node4 = new LinkedListNode<string>("Value-4");
            node3.Next = node4;
            list.Count++;

            // list -> Value-1 -> Value-2 -> Value-3 -> Value-4
            LinkedListNode<string> node5 = new LinkedListNode<string>("Value-5");
            list.Tail = node4.Next = node5;
            list.Count++;

            return list;
        }
    }

    class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }
    }

    class LinkedList<T>
    {
        public LinkedListNode<T> Head { get;  set; }
        public LinkedListNode<T> Tail { get; set; }
        public int Count { get; set; }
        public System.Collections.Generic.IEnumerable<T> GetEnumerator()

        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }
}

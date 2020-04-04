using System;

namespace RemoveFirst
{
    class Program
    {
        static void Main(string[] args)
        {

            // The Method call will create a dummy list.
            // Add operation could also be used. See https://medium.com/@tarunbhatt9784/linked-list-can-you-add-a-professional-node-please-4387215baa5a
            // GitHub Code for Add Operation https://github.com/tarunbhatt9784/LinkedList/tree/master/LinkedListAddToFront
            LinkedList<string> list = PrepareDummyList();

            // We will remove nodes one by one
            for (int i = 0; i < 5; i++)
            {
                // Print List 
                PrintList(list);
                list.RemoveFromFront();
            }

            // Print final version of the list
            PrintList(list);
        }

        static void PrintList(LinkedList<string> list)
        {
            // Print List
            LinkedListNode<string> ptr = list.Head;
            string listString = "";
            for (int j = 0; j < list.Count; j++)
            {
                listString = $"{listString}{ptr.Value} --> ";
                ptr = ptr.Next;
            }
            Console.WriteLine($"{listString}null");

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
        public LinkedListNode<T> Head { get; set; }
        public LinkedListNode<T> Tail { get; set; }
        public int Count { get; set; }
        public void RemoveFromFront()
        {
            LinkedListNode<T> temp = Head;
            Head = Head.Next;
            Count--;
            if (Count == 0) Tail = null;
            
            // Make the object available for Garbage Collection
            temp = null;
        }
    }
}

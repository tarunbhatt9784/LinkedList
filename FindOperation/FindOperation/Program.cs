using System;

namespace Enumerate
{
    class FindOperation
    {
        static void Main(string[] args)
        {
            LinkedList<string> list = PrepareDummyList();
            Console.WriteLine("List Contains 'Value=1': " + list.Contains("Value-1"));
            Console.WriteLine("List Contains 'Value=99': " + list.Contains("Value-99"));
            Console.WriteLine("Node with value 'Value-1' points to the next node with value as: " + list.GetNode("Value-1").Next.Value);
            Console.WriteLine("Value of 2nd Node is: " + list.GetNodeAt(2-1).Value);
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
        public bool Contains(T value)
        {
            LinkedListNode<T> current = Head;
            bool doExist = false;
            while (current!= null)
            {
                if (current.Value.Equals(value)) doExist = true;
                current = current.Next;
            }
            return doExist;
        }

        public LinkedListNode<T> GetNode(T value)
        {
            LinkedListNode<T> current = Head;
            while (current != null && Contains(value))
            {
                if (current.Value.Equals(value)) return current;
                current = current.Next;
            }
            return null;
        }

        public LinkedListNode<T> GetNodeAt(int index)
        {
            LinkedListNode<T> current = Head;
            int indexLoc = 0;
            while (current != null && Count-1 >= index)
            {
                if (indexLoc == 0) return current;
                indexLoc++;
                current = current.Next;
            }
            return null;
        }
    }
}

using System;

namespace LinkedListAddToFront
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedListNode<string> node;
            LinkedList<string> list = new LinkedList<string>();

            /* 
             * Ignore the logic in the for loop.
             * A lot of it has been written to display the contents of the 
             * Linked List in a presentable format
             * The Logic below adds 5 element to an empty 
             * Linked List one after another
             * 
             * The most important function in this project is AddToFront()
             * in the LinkedList class
             */
            for (int i = 0; i < 5; i++){
                Console.WriteLine($"Add node with Data Field as 'Value -{ i}'");
                node = new LinkedListNode<string>($"Value-{i}");
                list.AddToFront(node);
                string listString = "";
                LinkedListNode<string> ptr = list.Head;
                for (int j = 0; j<list.Count; j++)
                {
                    listString = $"{listString}{ptr.Value} --> ";
                    ptr = ptr.Next;
                }
                Console.WriteLine($"{listString}null");
                Console.WriteLine($"Data field of Head --> '{list.Head.Value}' & Data field of Tail --> '{list.Tail.Value}'");
                Console.WriteLine();
            }
        }
    }

    class LinkedListNode<T>
    {
        public LinkedListNode(T value){
            Value = value;
        }
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }
    }

    class LinkedList<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }
        public int Count { get; set; }
        public void AddToFront(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Head;
            Head = node;
            Head.Next = temp;
            Count++;
            if (Count == 1) Tail = Head;
        }
    }
}
